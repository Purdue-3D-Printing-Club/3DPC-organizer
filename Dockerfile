FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Setup database
ENV PATH="$PATH:/root/.dotnet/tools"
RUN dotnet tool install --global dotnet-ef --version 8.0.4
RUN dotnet ef database update --project ./Server/Organizer.Server.csproj

# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .

# Copy the database to the volume
VOLUME /3dpc-org-db
COPY --from=build-env /App/Server/Database/db/ /3dpc-org-db

# Set the ASPNETCORE_URLS environment variable
ENV ASPNETCORE_URLS=http://+:9998

# Expose port for incoming connections
EXPOSE 9998
ENTRYPOINT ["dotnet", "Organizer.Server.dll"]
