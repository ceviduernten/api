FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY DUR.Api.Web/DUR.Api.Web.csproj DUR.Api.Web/
COPY DUR.Api.Presentation/DUR.Api.Presentation.csproj DUR.Api.Presentation/
COPY DUR.Api.Entities/DUR.Api.Entities.csproj DUR.Api.Entities/
COPY DUR.Api.Services/DUR.Api.Services.csproj DUR.Api.Services/
COPY DUR.Api.Repo.Nextcloud/DUR.Api.Repo.Nextcloud.csproj DUR.Api.Repo.Nextcloud/
COPY DUR.Api.Repo.Database/DUR.Api.Repo.Database.csproj DUR.Api.Repo.Database/
COPY DUR.Api.Settings/DUR.Api.Settings.csproj DUR.Api.Settings/
RUN dotnet restore "DUR.Api.Web/DUR.Api.Web.csproj"
COPY . .
WORKDIR "/src/DUR.Api.Web"
RUN dotnet build "DUR.Api.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DUR.Api.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DUR.Api.Web.dll"]
