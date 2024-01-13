#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OAuth_Implementation/OAuth_Implementation.csproj", "OAuth_Implementation/"]
RUN dotnet restore "OAuth_Implementation/OAuth_Implementation.csproj"
COPY . .
WORKDIR "/src/OAuth_Implementation"
RUN dotnet build "OAuth_Implementation.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OAuth_Implementation.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OAuth_Implementation.dll"]