FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /App

COPY . ./
RUN dotnet restore
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
ENV ConnectionStrings__DefaultConnection="server=mysql;database=ecommerce;user=root;password=password"
COPY --from=build /App/out .
ENTRYPOINT ["dotnet", "ecommerce-v2.dll"]