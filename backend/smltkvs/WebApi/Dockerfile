FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["smltkvs/smltkvs.csproj", "smltkvs/"]
RUN dotnet restore "smltkvs/smltkvs.csproj"
COPY . .
WORKDIR "/src/smltkvs"
RUN dotnet build "smltkvs.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "smltkvs.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "smltkvs.dll"]
