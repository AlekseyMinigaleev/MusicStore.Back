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
<<<<<<<< HEAD:MusicStore.DB/Migrations/20231010115809_init.cs
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronomyc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileLink = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusicalInstrument = table.Column<string>(type: "nvarchar(max)", nullable: true)
========
                    FirstName = table.Column<string>(type: "longchar", nullable: false),
                    LastName = table.Column<string>(type: "longchar", nullable: false),
                    Patronomyc = table.Column<string>(type: "longchar", nullable: true),
                    ProfileLink = table.Column<string>(type: "longchar", nullable: false),
                    Discriminator = table.Column<string>(type: "longchar", nullable: false),
                    MusicalInstrument = table.Column<string>(type: "longchar", nullable: true)
>>>>>>>> parent of 6a91074 (#normalize database):MusicStore.DB/Migrations/20231016125344_init.cs
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
<<<<<<<< HEAD:MusicStore.DB/Migrations/20231010115809_init.cs
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShortName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
========
                    Name = table.Column<string>(type: "longchar", nullable: false),
                    ShortName = table.Column<string>(type: "longchar", nullable: true),
                    Address = table.Column<string>(type: "longchar", nullable: false),
>>>>>>>> parent of 6a91074 (#normalize database):MusicStore.DB/Migrations/20231016125344_init.cs
                    WhosalerPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturings", x => x.Id);
                });

            migrationBuilder.CreateTable(
<<<<<<<< HEAD:MusicStore.DB/Migrations/20231010115809_init.cs
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
========
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
>>>>>>>> parent of 6a91074 (#normalize database):MusicStore.DB/Migrations/20231016125344_init.cs
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
<<<<<<<< HEAD:MusicStore.DB/Migrations/20231010115809_init.cs
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MusicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManufacturingCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RetailPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WhosalerPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountInStock = table.Column<int>(type: "int", nullable: false),
                    CountSoldPreviousYear = table.Column<int>(type: "int", nullable: true),
                    CountSoldCurrentYear = table.Column<int>(type: "int", nullable: false)
========
                    Name = table.Column<string>(type: "longchar", nullable: false),
                    MusicId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManufacturingCompanyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    RetailPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    WhosalerPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CountInStock = table.Column<int>(type: "integer", nullable: false),
                    CountSoldPreviousYear = table.Column<int>(type: "integer", nullable: true),
                    CountSoldCurrentYear = table.Column<int>(type: "integer", nullable: false)
>>>>>>>> parent of 6a91074 (#normalize database):MusicStore.DB/Migrations/20231016125344_init.cs
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
<<<<<<<< HEAD:MusicStore.DB/Migrations/20231010115809_init.cs
                name: "EnsambleMusicant",
========
                name: "EnsembleMusicant",
>>>>>>>> parent of 6a91074 (#normalize database):MusicStore.DB/Migrations/20231016125344_init.cs
                columns: table => new
                {
                    MusicantEnsemblesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MusicantsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
<<<<<<<< HEAD:MusicStore.DB/Migrations/20231010115809_init.cs
                    table.PrimaryKey("PK_EnsambleMusicant", x => new { x.MusicantEnsemblesId, x.MusicantsId });
                    table.ForeignKey(
                        name: "FK_EnsambleMusicant_EnsembleMembers_MusicantsId",
========
                    table.PrimaryKey("PK_EnsembleMusicant", x => new { x.MusicantEnsemblesId, x.MusicantsId });
                    table.ForeignKey(
                        name: "FK_EnsembleMusicant_EnsembleMembers_MusicantsId",
>>>>>>>> parent of 6a91074 (#normalize database):MusicStore.DB/Migrations/20231016125344_init.cs
                        column: x => x.MusicantsId,
                        principalTable: "EnsembleMembers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
<<<<<<<< HEAD:MusicStore.DB/Migrations/20231010115809_init.cs
                        name: "FK_EnsambleMusicant_Ensemble_MusicantEnsemblesId",
                        column: x => x.MusicantEnsemblesId,
                        principalTable: "Ensemble",
========
                        name: "FK_EnsembleMusicant_Ensembles_MusicantEnsemblesId",
                        column: x => x.MusicantEnsemblesId,
                        principalTable: "Ensembles",
>>>>>>>> parent of 6a91074 (#normalize database):MusicStore.DB/Migrations/20231016125344_init.cs
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
<<<<<<<< HEAD:MusicStore.DB/Migrations/20231010115809_init.cs
                name: "Performance",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
========
                name: "Performances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Place = table.Column<string>(type: "longchar", nullable: false),
                    Name = table.Column<string>(type: "longchar", nullable: false),
>>>>>>>> parent of 6a91074 (#normalize database):MusicStore.DB/Migrations/20231016125344_init.cs
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
<<<<<<<< HEAD:MusicStore.DB/Migrations/20231010115809_init.cs
                    Duration = table.Column<double>(type: "float", nullable: false),
                    Tempo = table.Column<int>(type: "int", nullable: false),
                    Arrangement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dynamics = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Interpretation = table.Column<string>(type: "nvarchar(max)", nullable: false),
========
                    Duration = table.Column<double>(type: "double", nullable: false),
                    Tempo = table.Column<int>(type: "integer", nullable: false),
                    Arrangement = table.Column<string>(type: "longchar", nullable: false),
                    Dynamics = table.Column<string>(type: "longchar", nullable: false),
                    Interpretation = table.Column<string>(type: "longchar", nullable: false),
>>>>>>>> parent of 6a91074 (#normalize database):MusicStore.DB/Migrations/20231016125344_init.cs
                    PerformanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MusicalMetadatas", x => x.Id);
                    table.ForeignKey(
<<<<<<<< HEAD:MusicStore.DB/Migrations/20231010115809_init.cs
                        name: "FK_MusicalMetadatas_Performance_PerformanceId",
========
                        name: "FK_MusicalMetadatas_Performances_PerformanceId",
>>>>>>>> parent of 6a91074 (#normalize database):MusicStore.DB/Migrations/20231016125344_init.cs
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
<<<<<<<< HEAD:MusicStore.DB/Migrations/20231010115809_init.cs
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
========
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
>>>>>>>> parent of 6a91074 (#normalize database):MusicStore.DB/Migrations/20231016125344_init.cs
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
<<<<<<<< HEAD:MusicStore.DB/Migrations/20231010115809_init.cs
                name: "Performance");
========
                name: "Performances");

            migrationBuilder.DropTable(
                name: "Ensembles");
>>>>>>>> parent of 6a91074 (#normalize database):MusicStore.DB/Migrations/20231016125344_init.cs

            migrationBuilder.DropTable(
                name: "Musics");

            migrationBuilder.DropTable(
<<<<<<<< HEAD:MusicStore.DB/Migrations/20231010115809_init.cs
                name: "Music");

            migrationBuilder.DropTable(
========
>>>>>>>> parent of 6a91074 (#normalize database):MusicStore.DB/Migrations/20231016125344_init.cs
                name: "EnsembleMembers");
        }
    }
}
