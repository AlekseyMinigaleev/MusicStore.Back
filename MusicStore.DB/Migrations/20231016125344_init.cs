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
                    FirstName = table.Column<string>(type: "longchar", nullable: false),
                    LastName = table.Column<string>(type: "longchar", nullable: false),
                    Patronomyc = table.Column<string>(type: "longchar", nullable: true),
                    ProfileLink = table.Column<string>(type: "longchar", nullable: false),
                    Discriminator = table.Column<string>(type: "longchar", nullable: false),
                    MusicalInstrument = table.Column<string>(type: "longchar", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnsembleMembers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "longchar", nullable: false),
                    ShortName = table.Column<string>(type: "longchar", nullable: true),
                    Address = table.Column<string>(type: "longchar", nullable: false),
                    WhosalerPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Musics",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "longchar", nullable: false),
                    Genre = table.Column<string>(type: "longchar", nullable: false),
                    Autor = table.Column<string>(type: "longchar", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ensembles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaderId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ComposerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    OrchestraConductorId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Type = table.Column<string>(type: "longchar", nullable: false),
                    PerformanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ensembles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ensembles_EnsembleMembers_ComposerId",
                        column: x => x.ComposerId,
                        principalTable: "EnsembleMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ensembles_EnsembleMembers_LeaderId",
                        column: x => x.LeaderId,
                        principalTable: "EnsembleMembers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ensembles_EnsembleMembers_OrchestraConductorId",
                        column: x => x.OrchestraConductorId,
                        principalTable: "EnsembleMembers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CompactDisks",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "longchar", nullable: false),
                    MusicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManufacturingCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RetailPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WhosalerPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountInStock = table.Column<int>(type: "integer", nullable: false),
                    CountSoldPreviousYear = table.Column<int>(type: "integer", nullable: true),
                    CountSoldCurrentYear = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompactDisks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompactDisks_Manufacturings_ManufacturingCompanyId",
                        column: x => x.ManufacturingCompanyId,
                        principalTable: "Manufacturings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompactDisks_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EnsembleMusicant",
                columns: table => new
                {
                    MusicantEnsemblesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicantsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnsembleMusicant", x => new { x.MusicantEnsemblesId, x.MusicantsId });
                    table.ForeignKey(
                        name: "FK_EnsembleMusicant_EnsembleMembers_MusicantsId",
                        column: x => x.MusicantsId,
                        principalTable: "EnsembleMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EnsembleMusicant_Ensembles_MusicantEnsemblesId",
                        column: x => x.MusicantEnsemblesId,
                        principalTable: "Ensembles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Performances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Place = table.Column<string>(type: "longchar", nullable: false),
                    Name = table.Column<string>(type: "longchar", nullable: false),
                    MusicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Performances_Ensembles_Id",
                        column: x => x.Id,
                        principalTable: "Ensembles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Performances_Musics_MusicId",
                        column: x => x.MusicId,
                        principalTable: "Musics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MusicalMetadatas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Duration = table.Column<double>(type: "double", nullable: false),
                    Tempo = table.Column<int>(type: "integer", nullable: false),
                    Arrangement = table.Column<string>(type: "longchar", nullable: false),
                    Dynamics = table.Column<string>(type: "longchar", nullable: false),
                    Interpretation = table.Column<string>(type: "longchar", nullable: false),
                    PerformanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicalMetadatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MusicalMetadatas_Performances_PerformanceId",
                        column: x => x.PerformanceId,
                        principalTable: "Performances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompactDisks_ManufacturingCompanyId",
                table: "CompactDisks",
                column: "ManufacturingCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompactDisks_MusicId",
                table: "CompactDisks",
                column: "MusicId");

            migrationBuilder.CreateIndex(
                name: "IX_EnsembleMusicant_MusicantsId",
                table: "EnsembleMusicant",
                column: "MusicantsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ensembles_ComposerId",
                table: "Ensembles",
                column: "ComposerId");

            migrationBuilder.CreateIndex(
                name: "IX_Ensembles_LeaderId",
                table: "Ensembles",
                column: "LeaderId");

            migrationBuilder.CreateIndex(
                name: "IX_Ensembles_OrchestraConductorId",
                table: "Ensembles",
                column: "OrchestraConductorId");

            migrationBuilder.CreateIndex(
                name: "IX_MusicalMetadatas_PerformanceId",
                table: "MusicalMetadatas",
                column: "PerformanceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Performances_MusicId",
                table: "Performances",
                column: "MusicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompactDisks");

            migrationBuilder.DropTable(
                name: "EnsembleMusicant");

            migrationBuilder.DropTable(
                name: "MusicalMetadatas");

            migrationBuilder.DropTable(
                name: "Manufacturings");

            migrationBuilder.DropTable(
                name: "Performances");

            migrationBuilder.DropTable(
                name: "Ensembles");

            migrationBuilder.DropTable(
                name: "Musics");

            migrationBuilder.DropTable(
                name: "EnsembleMembers");
        }
    }
}
