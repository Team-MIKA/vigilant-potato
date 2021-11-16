#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
#ENV ASPNETCORE_ENVIRONMENT "Development"
#ENV ASPNETCORE_URLS "https://+:443;http://+:80"
#ENV ASPNETCORE_URLS "http://+:80"

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Integrator/Integrator.csproj", "Integrator/"]
RUN dotnet restore "Integrator/Integrator.csproj"
COPY . .
WORKDIR "/src/Integrator"
RUN dotnet build "Integrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Integrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Integrator.dll"]