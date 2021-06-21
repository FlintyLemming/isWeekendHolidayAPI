FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app
EXPOSE 5000

# Restore
WORKDIR /src
COPY . .
RUN dotnet restore "isWeekendHolidayAPI/isWeekendHolidayAPI.csproj"

# Build
WORKDIR "/src/isWeekendHolidayAPI"
RUN dotnet build "isWeekendHolidayAPI.csproj" --no-restore -c Release -o /app/build

# Publish
RUN dotnet publish "isWeekendHolidayAPI.csproj" -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
COPY --from=build-env /app/publish .
ENTRYPOINT ["dotnet", "isWeekendHolidayAPI.dll"] 

#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#WORKDIR /app
#EXPOSE 5000
#
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY ["isWeekendHolidayAPI/isWeekendHolidayAPI.csproj", "isWeekendHolidayAPI/"]
#RUN dotnet restore "isWeekendHolidayAPI/isWeekendHolidayAPI.csproj"
#COPY . .
#WORKDIR "/src/isWeekendHolidayAPI"
#RUN dotnet build "isWeekendHolidayAPI.csproj" -c Release -o /app/build
#
#FROM build AS publish
#RUN dotnet publish "isWeekendHolidayAPI.csproj" -c Release -o /app/publish
#
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "isWeekendHolidayAPI.dll"]
