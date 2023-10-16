using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStore.DB.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ensemble",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Type = table.Column<string>(type: "longchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ensemble", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManufactoringCompany",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "longchar", nullable: false),
                    ShortName = table.Column<string>(type: "longchar", nullable: true),
                    Address = table.Column<string>(type: "longchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufactoringCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musicant",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicalInstrument = table.Column<string>(type: "longchar", nullable: false),
                    FirstName = table.Column<string>(type: "longchar", nullable: false),
                    SecondName = table.Column<string>(type: "longchar", nullable: false),
                    Patronomyc = table.Column<string>(type: "longchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musicant", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Songwriter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "longchar", nullable: false),
                    SecondName = table.Column<string>(type: "longchar", nullable: false),
                    Patronomyc = table.Column<string>(type: "longchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songwriter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EnsambleMusicant",
                columns: table => new
                {
                    EnsemblesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicantsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnsambleMusicant", x => new { x.EnsemblesId, x.MusicantsId });
                    table.ForeignKey(
                        name: "FK_EnsambleMusicant_Ensemble_EnsemblesId",
                        column: x => x.EnsemblesId,
                        principalTable: "Ensemble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnsambleMusicant_Musicant_MusicantsId",
                        column: x => x.MusicantsId,
                        principalTable: "Musicant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Music",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "longchar", nullable: false),
                    Genre = table.Column<string>(type: "longchar", nullable: false),
                    AuthorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Music_Songwriter_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Songwriter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompactDisk",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "longchar", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RetailPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WhosalerPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountInStock = table.Column<int>(type: "integer", nullable: false),
                    CountSoldPreviousYear = table.Column<int>(type: "integer", nullable: true),
                    CountSoldCurrentYear = table.Column<int>(type: "integer", nullable: false),
                    MusicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManufacturingCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompactDisk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompactDisk_ManufactoringCompany_ManufacturingCompanyId",
                        column: x => x.ManufacturingCompanyId,
                        principalTable: "ManufactoringCompany",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompactDisk_Music_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Music",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Performance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Place = table.Column<string>(type: "longchar", nullable: false),
                    Name = table.Column<string>(type: "longchar", nullable: false),
                    EnsembleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicalMetadataId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Performance_Ensemble_Id",
                        column: x => x.Id,
                        principalTable: "Ensemble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Performance_Music_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Music",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicalMetadata",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Duration = table.Column<double>(type: "double", nullable: false),
                    Tempo = table.Column<int>(type: "integer", nullable: false),
                    Interpretation = table.Column<string>(type: "longchar", nullable: false),
                    PerformanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicalMetadata", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicalMetadata_Performance_PerformanceId",
                        column: x => x.PerformanceId,
                        principalTable: "Performance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompactDisk_ManufacturingCompanyId",
                table: "CompactDisk",
                column: "ManufacturingCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompactDisk_MusicId",
                table: "CompactDisk",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_EnsambleMusicant_MusicantsId",
                table: "EnsambleMusicant",
                column: "MusicantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Music_AuthorId",
                table: "Music",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicalMetadata_PerformanceId",
                table: "MusicalMetadata",
                column: "PerformanceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Performance_MusicId",
                table: "Performance",
                column: "MusicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompactDisk");

            migrationBuilder.DropTable(
                name: "EnsambleMusicant");

            migrationBuilder.DropTable(
                name: "MusicalMetadata");

            migrationBuilder.DropTable(
                name: "ManufactoringCompany");

            migrationBuilder.DropTable(
                name: "Musicant");

            migrationBuilder.DropTable(
                name: "Performance");

            migrationBuilder.DropTable(
                name: "Ensemble");

            migrationBuilder.DropTable(
                name: "Music");

            migrationBuilder.DropTable(
                name: "Songwriter");
        }
    }
}
