#####################
# Build environment #
#####################
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build-env

WORKDIR /app

COPY Application/*.csproj ./Application/
COPY Data/*.csproj ./Data/

RUN dotnet restore "./Application/Application.csproj"

COPY . .

RUN dotnet publish "./Application/Application.csproj" -c Release -o out

#################
# Build runtime #
#################
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine

WORKDIR /app

COPY --from=build-env /app/out .

RUN apk add --no-cache icu-libs

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV ASPNETCORE_URLS=http://+:8080

EXPOSE 8080

ENTRYPOINT ["dotnet", "Application.dll"]