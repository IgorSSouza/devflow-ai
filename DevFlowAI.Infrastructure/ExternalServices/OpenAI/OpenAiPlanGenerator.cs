using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using DevFlowAI.Application.Features.AI.DTOs;
using DevFlowAI.Application.Features.AI.Services;
using Microsoft.Extensions.Options;

namespace DevFlowAI.Infrastructure.ExternalServices.OpenAI;

public class OpenAiPlanGenerator : IAiPlanGenerator
{
    private readonly HttpClient _httpClient;
    private readonly OpenAiOptions _options;

    public OpenAiPlanGenerator(HttpClient httpClient, IOptions<OpenAiOptions> options)
    {
        _httpClient = httpClient;
        _options = options.Value;
    }

    public async Task<List<GeneratedTaskDto>> GenerateTasksFromGoalAsync(
        string goal,
        CancellationToken cancellationToken)
    {
        if (string.IsNullOrWhiteSpace(_options.ApiKey))
            throw new InvalidOperationException("A chave da OpenAI não foi configurada.");

        var prompt = $@"
            Você é um assistente que transforma objetivos em tarefas práticas.
            
            Gere entre 3 e 6 tarefas com base no objetivo abaixo.
            
            Objetivo:
            {goal}
            
            Responda SOMENTE em JSON válido, no formato:
            [
              {{
                ""title"": ""string"",
                ""description"": ""string""
              }}
            ]";

        var requestBody = new
        {
            model = "gpt-4.1-mini",
            input = prompt,
            text = new
            {
                format = new
                {
                    type = "json_object"
                }
            }
        };

        using var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/responses");
        request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", _options.ApiKey);
        request.Content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json");

        using var response = await _httpClient.SendAsync(request, cancellationToken);
        var rawResponse = await response.Content.ReadAsStringAsync(cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            throw new InvalidOperationException(
                $"Erro ao chamar OpenAI: {(int)response.StatusCode} - {response.ReasonPhrase} - {rawResponse}");
        }

        if (!response.IsSuccessStatusCode)
            throw new InvalidOperationException($"Erro ao chamar OpenAI: {response.StatusCode} - {rawResponse}");

        using var document = JsonDocument.Parse(rawResponse);

        var outputText = document.RootElement
            .GetProperty("output")[0]
            .GetProperty("content")[0]
            .GetProperty("text")
            .GetString();

        if (string.IsNullOrWhiteSpace(outputText))
            throw new InvalidOperationException("A OpenAI retornou uma resposta vazia.");

        var tasks = JsonSerializer.Deserialize<List<GeneratedTaskDto>>(
            outputText,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        if (tasks is null || tasks.Count == 0)
            throw new InvalidOperationException("A OpenAI não retornou tarefas válidas.");

        return tasks;
    }
}