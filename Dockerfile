#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM microsoft/dotnet:2.1-runtime-nanoserver-1709 AS base
WORKDIR /app

#FROM microsoft/dotnet:2.1-sdk-nanoserver-1709 AS build
#WORKDIR /src
#COPY Startup/Startup.csproj Startup/
#COPY JobScheduler/Job.csproj JobScheduler/
#COPY CSV/CSV.csproj CSV/
#COPY Email/Email.csproj Email/
#RUN dotnet restore Startup/Startup.csproj
#COPY . .
#WORKDIR /src/Startup
#RUN dotnet build Startup.csproj -c Release -o /app
#
#FROM build AS publish
#RUN dotnet publish Startup.csproj -c Release -o /app
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Startup.dll"]
