#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV SimpleProperty = "hello-from-base-docerfile"

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CarvedRock.API/CarvedRock.API.csproj", "CarvedRock.API/"]
RUN dotnet restore "CarvedRock.API/CarvedRock.API.csproj"
COPY . .
WORKDIR "/src/CarvedRock.API"
RUN dotnet build "CarvedRock.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CarvedRock.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV SimpleProperty = "hellow-from-final-dockerfile"
ENTRYPOINT ["dotnet", "CarvedRock.API.dll"]