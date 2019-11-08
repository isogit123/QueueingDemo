# FROM mcr.microsoft.com/mssql/server:2017-latest AS db
# RUN cat /opt/mssql/mssql.conf

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /app
RUN curl -sL https://deb.nodesource.com/setup_13.x | bash -
RUN apt-get update
RUN apt-get install -y nodejs
# copy csproj and restore as distinct layers
COPY *.sln .
COPY QueueingDemo/*.csproj ./QueueingDemo/
RUN dotnet restore
# copy everything else and build app
COPY QueueingDemo/. ./QueueingDemo/
WORKDIR /app/QueueingDemo

RUN dotnet publish -c Release -o out


FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
EXPOSE 80 1433
COPY --from=build /app/QueueingDemo/out ./
CMD dotnet QueueingDemo.dll --urls=http://*:80
