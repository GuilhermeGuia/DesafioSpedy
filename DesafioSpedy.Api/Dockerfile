FROM mcr.microsoft.com/dotnet/sdk:8.0

WORKDIR /app

COPY . .

RUN dotnet restore "./DesafioSpedy.Api/DesafioSpedy.Api.csproj"
RUN dotnet build "./DesafioSpedy.Api/DesafioSpedy.Api.csproj"

EXPOSE 8080
EXPOSE 8081

CMD ["dotnet", "run", "--project", "DesafioSpedy.Api/DesafioSpedy.Api.csproj"]
