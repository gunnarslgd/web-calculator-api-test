# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Ensure the working directory exists
WORKDIR /app

# Copy the .csproj file into the container's /app directory
COPY CalculatorService.csproj ./ 

# Restore dependencies
RUN dotnet restore CalculatorService.csproj

# Copy the rest of the application into the container
COPY . ./ 

# Publish the application to /out
RUN dotnet publish -c Release -o /out

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Set the working directory to /app in the runtime container
WORKDIR /app

# Copy the published application from the build stage to the runtime container
COPY --from=build /out .

# Set entry point for the container to run the application
ENTRYPOINT ["dotnet", "CalculatorService.dll"]
