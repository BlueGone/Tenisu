FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

COPY . .

RUN dotnet restore
RUN dotnet publish -o out

###

FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS run
WORKDIR /app

COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "Tenisu.Web.dll"]