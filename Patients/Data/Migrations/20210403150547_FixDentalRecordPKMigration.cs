using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patients.Migrations
{
  public partial class FixDentalRecordPKMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_DentalRecords_Teeth_ToothNumber",
          table: "DentalRecords");

      migrationBuilder.DropPrimaryKey(
          name: "PK_DentalRecords",
          table: "DentalRecords");

      migrationBuilder.AddColumn<Guid>(
          name: "ID",
          table: "DentalRecords",
          type: "TEXT",
          nullable: false,
          defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

      migrationBuilder.AddColumn<Guid>(
          name: "PatientID",
          table: "DentalRecords",
          type: "TEXT",
          nullable: false,
          defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

      migrationBuilder.AddPrimaryKey(
          name: "PK_DentalRecords",
          table: "DentalRecords",
          column: "ID");

      migrationBuilder.CreateIndex(
          name: "IX_DentalRecords_PatientID_ToothNumber",
          table: "DentalRecords",
          columns: new[] { "PatientID", "ToothNumber" });

      migrationBuilder.AddForeignKey(
          name: "FK_DentalRecords_PatientsTeeth_PatientID_ToothNumber",
          table: "DentalRecords",
          columns: new[] { "PatientID", "ToothNumber" },
          principalTable: "PatientsTeeth",
          principalColumns: new[] { "PatientID", "ToothNumber" },
          onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_DentalRecords_PatientsTeeth_PatientID_ToothNumber",
          table: "DentalRecords");

      migrationBuilder.DropPrimaryKey(
          name: "PK_DentalRecords",
          table: "DentalRecords");

      migrationBuilder.DropIndex(
          name: "IX_DentalRecords_PatientID_ToothNumber",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "ID",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "PatientID",
          table: "DentalRecords");

      migrationBuilder.AddPrimaryKey(
          name: "PK_DentalRecords",
          table: "DentalRecords",
          column: "ToothNumber");

      migrationBuilder.AddForeignKey(
          name: "FK_DentalRecords_Teeth_ToothNumber",
          table: "DentalRecords",
          column: "ToothNumber",
          principalTable: "Teeth",
          principalColumn: "Number",
          onDelete: ReferentialAction.Cascade);
    }
  }
}