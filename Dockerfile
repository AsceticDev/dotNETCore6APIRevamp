FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["dotNETCoreAPIRevamp.csproj", "./"]
RUN dotnet restore "./dotNETCoreAPIRevamp.csproj"
COPY . .
RUN dotnet build "dotNETCoreAPIRevamp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "dotNETCoreAPIRevamp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

ENTRYPOINT ["dotnet", "dotNETCoreAPIRevamp.dll"]

