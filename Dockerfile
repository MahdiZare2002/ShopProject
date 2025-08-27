# ===== Build =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy just sln + csproj for cached restore
COPY *.sln ./
COPY ShopProject.Domain/*.csproj ./ShopProject.Domain/
COPY ShopProject.Application/*.csproj ./ShopProject.Application/
COPY ShopProject.Infrustructure/*.csproj ./ShopProject.Infrustructure/
COPY ShopProject.WebApi/*.csproj ./ShopProject.WebApi/

RUN dotnet restore

# Copy the rest
COPY . .

# Publish
RUN dotnet publish ShopProject.WebApi/ShopProject.WebApi.csproj -c Release -o /app /p:UseAppHost=false

# ===== Runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app ./

ENV ASPNETCORE_URLS=http://0.0.0.0:8080
EXPOSE 8080

# (Optional) remove or adapt if no /health
# HEALTHCHECK --interval=30s --timeout=3s --start-period=20s CMD curl -f http://localhost:8080/health || exit 1

ENTRYPOINT ["dotnet", "ShopProject.WebApi.dll"]
