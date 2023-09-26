FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["VulnerableQuestions/VulnerableQuestions.csproj", "VulnerableQuestions/"]
RUN dotnet restore "VulnerableQuestions/VulnerableQuestions.csproj"
COPY . .
WORKDIR "/src/VulnerableQuestions"
RUN dotnet build "VulnerableQuestions.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VulnerableQuestions.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VulnerableQuestions.dll"]
