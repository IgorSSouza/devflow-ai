FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["DevFlowAI.API/DevFlowAI.API.csproj", "DevFlowAI.API/"]
COPY ["DevFlowAI.Application/DevFlowAI.Application.csproj", "DevFlowAI.Application/"]
COPY ["DevFlowAI.Domain/DevFlowAI.Domain.csproj", "DevFlowAI.Domain/"]
COPY ["DevFlowAI.Infrastructure/DevFlowAI.Infrastructure.csproj", "DevFlowAI.Infrastructure/"]

RUN dotnet restore "DevFlowAI.API/DevFlowAI.API.csproj"

COPY . .
WORKDIR "/src/DevFlowAI.API"
RUN dotnet publish "DevFlowAI.API.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 8080

ENTRYPOINT ["dotnet", "DevFlowAI.API.dll"]