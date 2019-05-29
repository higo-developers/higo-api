#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 52025
EXPOSE 44361

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["Higo-Api/Higo-Api.csproj", "Higo-Api/"]
RUN dotnet restore "Higo-Api/Higo-Api.csproj"
COPY . .
WORKDIR "/src/Higo-Api"
RUN dotnet build "Higo-Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Higo-Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Higo-Api.dll"]