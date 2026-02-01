# build stage
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/publish .

# Render PORT beradi, shuni tinglaymiz
ENV ASPNETCORE_URLS=http://0.0.0.0:${PORT}

CMD ["dotnet", "TASK3.dll"]
