#####################
# Build environment #
#####################
FROM mcr.microsoft.com/dotnet/sdk:9.0-alpine AS build

WORKDIR /app

COPY Worker/*.csproj ./Worker/
COPY Application/*.csproj ./Application/
COPY Data/*.csproj ./Data/

RUN dotnet restore "./Worker/Worker.csproj"

COPY . .

RUN dotnet publish "./Worker/Worker.csproj" -c Release -o /app/out

#################
# Build runtime #
#################
FROM mcr.microsoft.com/dotnet/aspnet:9.0-alpine AS final

WORKDIR /app

COPY --from=build /app/out .

RUN apk add --no-cache icu-libs

ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
ENV DOTNET_ENVIRONMENT=Production
ENV JOB=process-monitoring
ENV JOB_INTERVAL_SEC=60

ENTRYPOINT ["dotnet", "Worker.dll"]