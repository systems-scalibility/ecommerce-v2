FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["ecommerce-v1.csproj", "."]
RUN dotnet restore "ecommerce-v1.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "ecommerce-v1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ecommerce-v1.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ecommerce_v1.dll"]
