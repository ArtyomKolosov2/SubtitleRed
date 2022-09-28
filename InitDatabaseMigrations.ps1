dotnet ef migrations add InitialIdentityMigration --context IdentityDatabaseContext --startup-project .\SubtitleRed\SubtitleRed.csproj --project .\SubtitleRed.Infrastructure\SubtitleRed.Infrastructure.csproj
dotnet ef database Update --context IdentityDatabaseContext --startup-project .\SubtitleRed\SubtitleRed.csproj --project .\SubtitleRed.Infrastructure\SubtitleRed.Infrastructure.csproj
dotnet ef migrations add InitialDatabaseMigration --context DatabaseContext --startup-project .\SubtitleRed\SubtitleRed.csproj --project .\SubtitleRed.Infrastructure\SubtitleRed.Infrastructure.csproj
dotnet ef database Update --context DatabaseContext --startup-project .\SubtitleRed\SubtitleRed.csproj --project .\SubtitleRed.Infrastructure\SubtitleRed.Infrastructure.csproj
