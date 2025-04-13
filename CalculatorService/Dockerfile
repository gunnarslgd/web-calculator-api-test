# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY CalculatorService.csproj ./  # This will copy the CalculatorService.csproj to the Docker image
RUN dotnet restore CalculatorService.csproj

# Copy the rest of the code and publish
COPY . ./  # This copies the entire CalculatorService folder (current context)
WORKDIR /app
RUN dotnet publish -c Release -o /out

# Use a runtime image for the final output
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /out ./
ENTRYPOINT ["dotnet", "CalculatorService.dll"]