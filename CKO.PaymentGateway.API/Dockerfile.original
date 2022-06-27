#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CKO.PaymentGateway.API/CKO.PaymentGateway.API.csproj", "CKO.PaymentGateway.API/"]
COPY ["CKO.PaymentGateway.Contracts/CKO.PaymentGateway.Contracts.csproj", "CKO.PaymentGateway.Contracts/"]
COPY ["CKO.BankSimulator/CKO.BankSimulator.csproj", "CKO.BankSimulator/"]
RUN dotnet restore "CKO.PaymentGateway.API/CKO.PaymentGateway.API.csproj"
COPY . .
WORKDIR "/src/CKO.PaymentGateway.API"
RUN dotnet build "CKO.PaymentGateway.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CKO.PaymentGateway.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CKO.PaymentGateway.API.dll"]