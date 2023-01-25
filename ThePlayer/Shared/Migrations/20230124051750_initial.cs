using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ThePlayer.Shared.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Albums",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false),
                    ArtistId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Albums", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AudioFiles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AudioFiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SongGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    ArtistId = table.Column<int>(type: "INTEGER", nullable: false),
                    GenreId = table.Column<int>(type: "INTEGER", nullable: false),
                    AlbumId = table.Column<int>(type: "INTEGER", nullable: false),
                    AudioFileId = table.Column<int>(type: "INTEGER", nullable: false),
                    MimeType = table.Column<string>(type: "TEXT", nullable: true),
                    FileSize = table.Column<long>(type: "INTEGER", nullable: true),
                    BitRate = table.Column<long>(type: "INTEGER", nullable: true),
                    SampleRate = table.Column<long>(type: "INTEGER", nullable: true),
                    TrackNumber = table.Column<long>(type: "INTEGER", nullable: true),
                    TrackCount = table.Column<long>(type: "INTEGER", nullable: true),
                    DiscNumber = table.Column<long>(type: "INTEGER", nullable: true),
                    DiscCount = table.Column<long>(type: "INTEGER", nullable: true),
                    Duration = table.Column<long>(type: "INTEGER", nullable: true),
                    Year = table.Column<long>(type: "INTEGER", nullable: true),
                    HasLyrics = table.Column<long>(type: "INTEGER", nullable: true),
                    DateAdded = table.Column<long>(type: "INTEGER", nullable: false),
                    DateFileCreated = table.Column<long>(type: "INTEGER", nullable: false),
                    DateLastSynced = table.Column<long>(type: "INTEGER", nullable: false),
                    DateFileModified = table.Column<long>(type: "INTEGER", nullable: false),
                    NeedsIndexing = table.Column<long>(type: "INTEGER", nullable: true),
                    NeedsAlbumArtworkIndexing = table.Column<long>(type: "INTEGER", nullable: true),
                    IndexingSuccess = table.Column<long>(type: "INTEGER", nullable: true),
                    IndexingFailureReason = table.Column<string>(type: "TEXT", nullable: true),
                    Rating = table.Column<long>(type: "INTEGER", nullable: true),
                    Love = table.Column<long>(type: "INTEGER", nullable: true),
                    PlayCount = table.Column<long>(type: "INTEGER", nullable: true),
                    SkipCount = table.Column<long>(type: "INTEGER", nullable: true),
                    DateLastPlayed = table.Column<long>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songs", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Albums",
                columns: new[] { "Id", "ArtistId", "GenreId", "Name" },
                values: new object[] { 1, 1, 1, "Head Above Water" });

            migrationBuilder.InsertData(
                table: "Artists",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Avril Lavigne" });

            migrationBuilder.InsertData(
                table: "AudioFiles",
                columns: new[] { "Id", "Path" },
                values: new object[] { 1L, "/testmusic/head above water.mp3" });

            migrationBuilder.InsertData(
                table: "SongGenres",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Alternative Rock" });

            migrationBuilder.InsertData(
                table: "Songs",
                columns: new[] { "Id", "AlbumId", "ArtistId", "AudioFileId", "BitRate", "DateAdded", "DateFileCreated", "DateFileModified", "DateLastPlayed", "DateLastSynced", "DiscCount", "DiscNumber", "Duration", "FileSize", "GenreId", "HasLyrics", "IndexingFailureReason", "IndexingSuccess", "Love", "MimeType", "Name", "NeedsAlbumArtworkIndexing", "NeedsIndexing", "PlayCount", "Rating", "SampleRate", "SkipCount", "TrackCount", "TrackNumber", "Year" },
                values: new object[] { 1L, 1, 1, 1, null, 0L, 0L, 0L, null, 0L, null, null, null, null, 1, null, null, null, null, null, "Head Above Water", null, null, null, null, null, null, null, null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Albums");

            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "AudioFiles");

            migrationBuilder.DropTable(
                name: "SongGenres");

            migrationBuilder.DropTable(
                name: "Songs");
        }
    }
}
