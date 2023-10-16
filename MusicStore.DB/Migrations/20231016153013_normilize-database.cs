using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStore.DB.Migrations
{
    /// <inheritdoc />
    public partial class normilizedatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnsambleMusicant_EnsembleMembers_MusicantsId",
                table: "EnsambleMusicant");

            migrationBuilder.DropForeignKey(
                name: "FK_EnsambleMusicant_Ensemble_MusicantEnsemblesId",
                table: "EnsambleMusicant");

            migrationBuilder.DropForeignKey(
                name: "FK_Ensemble_EnsembleMembers_Composer",
                table: "Ensemble");

            migrationBuilder.DropForeignKey(
                name: "FK_Ensemble_EnsembleMembers_Leader",
                table: "Ensemble");

            migrationBuilder.DropForeignKey(
                name: "FK_Ensemble_EnsembleMembers_OrhestraConductor",
                table: "Ensemble");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicalMetadatas_Performance_PerformanceId",
                table: "MusicalMetadatas");

            migrationBuilder.DropIndex(
                name: "IX_Ensemble_ComposerId",
                table: "Ensemble");

            migrationBuilder.DropIndex(
                name: "IX_Ensemble_LeaderId",
                table: "Ensemble");

            migrationBuilder.DropIndex(
                name: "IX_Ensemble_OrchestraConductorId",
                table: "Ensemble");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicalMetadatas",
                table: "MusicalMetadatas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnsembleMembers",
                table: "EnsembleMembers");

            migrationBuilder.DropColumn(
                name: "Autor",
                table: "Music");

            migrationBuilder.DropColumn(
                name: "WhosalerPrice",
                table: "ManufactoringCompany");

            migrationBuilder.DropColumn(
                name: "ComposerId",
                table: "Ensemble");

            migrationBuilder.DropColumn(
                name: "LeaderId",
                table: "Ensemble");

            migrationBuilder.DropColumn(
                name: "OrchestraConductorId",
                table: "Ensemble");

            migrationBuilder.DropColumn(
                name: "PerformanceId",
                table: "Ensemble");

            migrationBuilder.DropColumn(
                name: "Arrangement",
                table: "MusicalMetadatas");

            migrationBuilder.DropColumn(
                name: "Dynamics",
                table: "MusicalMetadatas");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "EnsembleMembers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "EnsembleMembers");

            migrationBuilder.RenameTable(
                name: "MusicalMetadatas",
                newName: "MusicalMetadata");

            migrationBuilder.RenameTable(
                name: "EnsembleMembers",
                newName: "Musicant");

            migrationBuilder.RenameColumn(
                name: "MusicantEnsemblesId",
                table: "EnsambleMusicant",
                newName: "EnsemblesId");

            migrationBuilder.RenameIndex(
                name: "IX_MusicalMetadatas_PerformanceId",
                table: "MusicalMetadata",
                newName: "IX_MusicalMetadata_PerformanceId");

            migrationBuilder.RenameColumn(
                name: "ProfileLink",
                table: "Musicant",
                newName: "SecondName");

            migrationBuilder.AddColumn<Guid>(
                name: "EnsembleId",
                table: "Performance",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "MusicalMetadataId",
                table: "Performance",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "AuthorId",
                table: "Music",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<string>(
                name: "MusicalInstrument",
                table: "Musicant",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicalMetadata",
                table: "MusicalMetadata",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Musicant",
                table: "Musicant",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Songwriter",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SecondName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Patronomyc = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Songwriter", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Music_AuthorId",
                table: "Music",
                column: "AuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_EnsambleMusicant_Ensemble_EnsemblesId",
                table: "EnsambleMusicant",
                column: "EnsemblesId",
                principalTable: "Ensemble",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnsambleMusicant_Musicant_MusicantsId",
                table: "EnsambleMusicant",
                column: "MusicantsId",
                principalTable: "Musicant",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Music_Songwriter_AuthorId",
                table: "Music",
                column: "AuthorId",
                principalTable: "Songwriter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicalMetadata_Performance_PerformanceId",
                table: "MusicalMetadata",
                column: "PerformanceId",
                principalTable: "Performance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnsambleMusicant_Ensemble_EnsemblesId",
                table: "EnsambleMusicant");

            migrationBuilder.DropForeignKey(
                name: "FK_EnsambleMusicant_Musicant_MusicantsId",
                table: "EnsambleMusicant");

            migrationBuilder.DropForeignKey(
                name: "FK_Music_Songwriter_AuthorId",
                table: "Music");

            migrationBuilder.DropForeignKey(
                name: "FK_MusicalMetadata_Performance_PerformanceId",
                table: "MusicalMetadata");

            migrationBuilder.DropTable(
                name: "Songwriter");

            migrationBuilder.DropIndex(
                name: "IX_Music_AuthorId",
                table: "Music");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MusicalMetadata",
                table: "MusicalMetadata");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Musicant",
                table: "Musicant");

            migrationBuilder.DropColumn(
                name: "EnsembleId",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "MusicalMetadataId",
                table: "Performance");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Music");

            migrationBuilder.RenameTable(
                name: "MusicalMetadata",
                newName: "MusicalMetadatas");

            migrationBuilder.RenameTable(
                name: "Musicant",
                newName: "EnsembleMembers");

            migrationBuilder.RenameColumn(
                name: "EnsemblesId",
                table: "EnsambleMusicant",
                newName: "MusicantEnsemblesId");

            migrationBuilder.RenameIndex(
                name: "IX_MusicalMetadata_PerformanceId",
                table: "MusicalMetadatas",
                newName: "IX_MusicalMetadatas_PerformanceId");

            migrationBuilder.RenameColumn(
                name: "SecondName",
                table: "EnsembleMembers",
                newName: "ProfileLink");

            migrationBuilder.AddColumn<string>(
                name: "Autor",
                table: "Music",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "WhosalerPrice",
                table: "ManufactoringCompany",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "ComposerId",
                table: "Ensemble",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LeaderId",
                table: "Ensemble",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "OrchestraConductorId",
                table: "Ensemble",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "PerformanceId",
                table: "Ensemble",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Arrangement",
                table: "MusicalMetadatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Dynamics",
                table: "MusicalMetadatas",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "MusicalInstrument",
                table: "EnsembleMembers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "EnsembleMembers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "EnsembleMembers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MusicalMetadatas",
                table: "MusicalMetadatas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnsembleMembers",
                table: "EnsembleMembers",
                column: "Id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_EnsambleMusicant_EnsembleMembers_MusicantsId",
                table: "EnsambleMusicant",
                column: "MusicantsId",
                principalTable: "EnsembleMembers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnsambleMusicant_Ensemble_MusicantEnsemblesId",
                table: "EnsambleMusicant",
                column: "MusicantEnsemblesId",
                principalTable: "Ensemble",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ensemble_EnsembleMembers_Composer",
                table: "Ensemble",
                column: "ComposerId",
                principalTable: "EnsembleMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ensemble_EnsembleMembers_Leader",
                table: "Ensemble",
                column: "LeaderId",
                principalTable: "EnsembleMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ensemble_EnsembleMembers_OrhestraConductor",
                table: "Ensemble",
                column: "OrchestraConductorId",
                principalTable: "EnsembleMembers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MusicalMetadatas_Performance_PerformanceId",
                table: "MusicalMetadatas",
                column: "PerformanceId",
                principalTable: "Performance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
