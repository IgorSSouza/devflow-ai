using DevFlowAI.API.Extensions;
using DevFlowAI.Application.DependencyInjection;
using DevFlowAI.Infrastructure.DependencyInjection;
using DevFlowAI.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services
    .AddApplication()
    .AddInfrastructure();

var app = builder.Build();

// Middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseAuthorization();

app.MapControllers();


app.Run();