# Usando a imagem base do .NET SDK para construir o aplicativo
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /app

# Copia o arquivo de projeto e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o restante do código e publica o aplicativo
COPY . ./
RUN dotnet publish -c Release -o /out

# Usando uma imagem base do .NET Runtime para rodar o aplicativo
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /out .

# Exponha a porta usada pelo aplicativo
EXPOSE 80

# Comando para rodar o aplicativo
ENTRYPOINT ["dotnet", "SistemaAPI.dll"]

