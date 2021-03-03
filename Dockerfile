FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000
EXPOSE 5001

ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["labo02.csproj", "./"]
RUN dotnet restore "labo02.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "labo02.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "labo02.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "labo02.dll"]
