using Microsoft.EntityFrameworkCore.Migrations;

namespace Patients.Migrations
{
  public partial class RenameTableAddIndexMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
        name: "FK_DentalRecord_Patients_PatientID",
        table: "DentalRecord");

      migrationBuilder.DropPrimaryKey(
        name: "PK_DentalRecord",
        table: "DentalRecord");

      migrationBuilder.RenameTable(
        name: "DentalRecord",
        newName: "DentalRecords");

      migrationBuilder.AddPrimaryKey(
        name: "PK_DentalRecords",
        table: "DentalRecords",
        column: "PatientID");

      migrationBuilder.CreateIndex(
        name: "IX_Patients_Surname",
        table: "Patients",
        column: "Surname");

      migrationBuilder.AddForeignKey(
        name: "FK_DentalRecords_Patients_PatientID",
        table: "DentalRecords",
        column: "PatientID",
        principalTable: "Patients",
        principalColumn: "ID",
        onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
        name: "FK_DentalRecords_Patients_PatientID",
        table: "DentalRecords");

      migrationBuilder.DropIndex(
        name: "IX_Patients_Surname",
        table: "Patients");

      migrationBuilder.DropPrimaryKey(
        name: "PK_DentalRecords",
        table: "DentalRecords");

      migrationBuilder.RenameTable(
        name: "DentalRecords",
        newName: "DentalRecord");

      migrationBuilder.AddPrimaryKey(
        name: "PK_DentalRecord",
        table: "DentalRecord",
        column: "PatientID");

      migrationBuilder.AddForeignKey(
        name: "FK_DentalRecord_Patients_PatientID",
        table: "DentalRecord",
        column: "PatientID",
        principalTable: "Patients",
        principalColumn: "ID",
        onDelete: ReferentialAction.Cascade);
    }
  }
}
