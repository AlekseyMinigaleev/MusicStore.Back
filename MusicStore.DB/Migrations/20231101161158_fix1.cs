using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MusicStore.DB.Migrations
{
    /// <inheritdoc />
    public partial class fix1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MusicalMetadata_Performance_PerformanceId",
                table: "MusicalMetadata");

            migrationBuilder.DropIndex(
                name: "IX_MusicalMetadata_PerformanceId",
                table: "MusicalMetadata");

            migrationBuilder.DropColumn(
                name: "PerformanceId",
                table: "MusicalMetadata");

            migrationBuilder.CreateIndex(
                name: "IX_Performance_MusicalMetadataId",
                table: "Performance",
                column: "MusicalMetadataId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_MusicalMetadata_MusicalMetadataId",
                table: "Performance",
                column: "MusicalMetadataId",
                principalTable: "MusicalMetadata",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_MusicalMetadata_MusicalMetadataId",
                table: "Performance");

            migrationBuilder.DropIndex(
                name: "IX_Performance_MusicalMetadataId",
                table: "Performance");

            migrationBuilder.AddColumn<Guid>(
                name: "PerformanceId",
                table: "MusicalMetadata",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_MusicalMetadata_PerformanceId",
                table: "MusicalMetadata",
                column: "PerformanceId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MusicalMetadata_Performance_PerformanceId",
                table: "MusicalMetadata",
                column: "PerformanceId",
                principalTable: "Performance",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
