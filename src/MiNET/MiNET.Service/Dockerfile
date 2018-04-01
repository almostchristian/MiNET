FROM microsoft/dotnet:2.0-runtime AS base
WORKDIR /app

FROM microsoft/dotnet:2.0-sdk AS build
WORKDIR /src
COPY MiNET.sln ./
COPY MiNET.Service/MiNET.Service.csproj MiNET.Service/
COPY MiNET/MiNET.csproj MiNET/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/MiNET.Service
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app


FROM base AS final
WORKDIR /app
COPY --from=publish /app .
EXPOSE 19132/udp
VOLUME /data
ENTRYPOINT ["dotnet", "MiNET.Service.dll"]
