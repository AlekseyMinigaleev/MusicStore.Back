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
                name: "EnsembleMembers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronomyc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusicalInstrument = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnsembleMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManufactoringCompany",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WhosalerPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManufactoringCompany", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Music",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genre = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Music", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ensemble",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ComposerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrchestraConductorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ensemble", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ensemble_EnsembleMembers_Composer",
                        column: x => x.ComposerId,
                        principalTable: "EnsembleMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ensemble_EnsembleMembers_Leader",
                        column: x => x.LeaderId,
                        principalTable: "EnsembleMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ensemble_EnsembleMembers_OrhestraConductor",
                        column: x => x.OrchestraConductorId,
                        principalTable: "EnsembleMembers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompactDisk",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManufacturingCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RetailPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WhosalerPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountInStock = table.Column<int>(type: "int", nullable: false),
                    CountSoldPreviousYear = table.Column<int>(type: "int", nullable: true),
                    CountSoldCurrentYear = table.Column<int>(type: "int", nullable: false)
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
                name: "EnsambleMusicant",
                columns: table => new
                {
                    MusicantEnsemblesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicantsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnsambleMusicant", x => new { x.MusicantEnsemblesId, x.MusicantsId });
                    table.ForeignKey(
                        name: "FK_EnsambleMusicant_EnsembleMembers_MusicantsId",
                        column: x => x.MusicantsId,
                        principalTable: "EnsembleMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnsambleMusicant_Ensemble_MusicantEnsemblesId",
                        column: x => x.MusicantEnsemblesId,
                        principalTable: "Ensemble",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Performance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
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
                name: "MusicalMetadatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Duration = table.Column<double>(type: "float", nullable: false),
                    Tempo = table.Column<int>(type: "int", nullable: false),
                    Arrangement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dynamics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interpretation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PerformanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicalMetadatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicalMetadatas_Performance_PerformanceId",
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
                name: "IX_Ensemble_ComposerId",
                table: "Ensemble",
                column: "ComposerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ensemble_LeaderId",
                table: "Ensemble",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Ensemble_OrchestraConductorId",
                table: "Ensemble",
                column: "OrchestraConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicalMetadatas_PerformanceId",
                table: "MusicalMetadatas",
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
                name: "MusicalMetadatas");

            migrationBuilder.DropTable(
                name: "ManufactoringCompany");

            migrationBuilder.DropTable(
                name: "Performance");

            migrationBuilder.DropTable(
                name: "Ensemble");

            migrationBuilder.DropTable(
                name: "Music");

            migrationBuilder.DropTable(
                name: "EnsembleMembers");
        }
    }
}
