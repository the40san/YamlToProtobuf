FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
COPY yaml ./yaml
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet
WORKDIR /app
COPY --from=build-env /app/out .
COPY --from=build-env /app/yaml yaml
VOLUME /app/out 
CMD ["dotnet", "YamlToProtobuf.dll"]
