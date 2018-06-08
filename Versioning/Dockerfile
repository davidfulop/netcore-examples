FROM microsoft/dotnet:2.1.300-sdk as builder
ARG version
ARG osruntime=ubuntu.16.04-x64
WORKDIR /src
COPY src/Versioning/Versioning.csproj .
RUN dotnet restore
COPY /src/Versioning/ .
# Using default/csproj-Version: 
# RUN dotnet publish -c Release --runtime $osruntime --output exe 
# Adding a Suffix to the csproj-VersionPrefix: 
# RUN dotnet publish -c Release --runtime $osruntime --version-suffix thisisaverylongversionsuffix --output exe 
# Overriding any version: 
RUN dotnet publish -c Release --runtime $osruntime /p:Version=$version --output exe 

FROM microsoft/dotnet:2.1-runtime
WORKDIR /app
RUN apt-get update && apt-get install -y libunwind-dev
COPY --from=builder /src/exe ./
ENTRYPOINT ["./Versioning"]
