FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR webapp

EXPOSE 80
EXPOSE 5002

COPY ./*.csproj ./
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/sdk:6.0
WORKDIR /webapp
COPY --from=build /webapp/out .
ENTRYPOINT ["dotnet", "Guia2-Unidad3-AlfredoAlas.dll", "--urls", "http://0.0.0.0:5002"]