# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
RUN mkdir /home/auth-backend
WORKDIR /home/auth-backend

# copy csproj and restore as distinct layers
COPY *.sln .
COPY Pets.Megastore.Auth.Api/*.csproj ./app/
RUN dotnet restore

# copy everything else and build app
COPY Pets.Megastore.Auth.Api/. ./app/
WORKDIR /home/auth-backend/app
RUN dotnet publish -c release -o ../release --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /home/auth-backend/release
COPY --from=build /home/auth-backend/release ./
ENTRYPOINT ["dotnet", "Authentication.dll"]
