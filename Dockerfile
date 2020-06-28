FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /source

COPY *.sln .
COPY DogHouseApi/*.csproj DogHouseApi/
RUN dotnet restore DogHouseApi/DogHouseApi.csproj

COPY DogHouseApi/. ./DogHouseApi/
WORKDIR /source/DogHouseApi
RUN dotnet publish -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "DogHouseApi.dll"]
