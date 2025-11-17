# builder
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o /app/publish

# runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .
# Use a shell entry so environment variables expand if you want to parametrize later
ENV APP_DLL=CycleStoreStarter.dll
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:${PORT:-8080}
ENTRYPOINT ["sh","-lc","dotnet $APP_DLL"]
