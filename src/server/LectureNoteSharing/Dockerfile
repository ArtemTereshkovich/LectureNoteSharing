FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 44466
EXPOSE 44370

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["server/LectureNoteSharing/LectureNoteSharing.csproj", "server/LectureNoteSharing/"]
RUN dotnet restore "server/LectureNoteSharing/LectureNoteSharing.csproj"
COPY . .
WORKDIR "/src/server/LectureNoteSharing"
RUN dotnet build "LectureNoteSharing.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "LectureNoteSharing.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "LectureNoteSharing.dll"]