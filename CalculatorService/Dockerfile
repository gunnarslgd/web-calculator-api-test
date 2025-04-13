# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY CalculatorService/CalculatorService.csproj ./  # Correct the path from the root
RUN dotnet restore CalculatorService.csproj

# Copy the rest of the source code and build
COPY CalculatorService/. ./
RUN dotnet publish -c Release -o /out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /out .

ENTRYPOINT ["dotnet", "CalculatorService.dll"]
