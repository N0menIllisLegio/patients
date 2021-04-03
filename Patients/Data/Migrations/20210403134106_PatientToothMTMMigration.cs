using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patients.Migrations
{
  public partial class PatientToothMTMMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "PatientsTeeth",
          columns: table => new
          {
            PatientID = table.Column<Guid>(type: "TEXT", nullable: false),
            ToothNumber = table.Column<int>(type: "INTEGER", nullable: false),
            Status = table.Column<int>(type: "INTEGER", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_PatientsTeeth", x => new { x.PatientID, x.ToothNumber });
            table.ForeignKey(
                      name: "FK_PatientsTeeth_Patients_PatientID",
                      column: x => x.PatientID,
                      principalTable: "Patients",
                      principalColumn: "ID",
                      onDelete: ReferentialAction.Cascade);
            table.ForeignKey(
                      name: "FK_PatientsTeeth_Teeth_ToothNumber",
                      column: x => x.ToothNumber,
                      principalTable: "Teeth",
                      principalColumn: "Number",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateIndex(
          name: "IX_PatientsTeeth_PatientID_ToothNumber",
          table: "PatientsTeeth",
          columns: new[] { "PatientID", "ToothNumber" });

      migrationBuilder.CreateIndex(
          name: "IX_PatientsTeeth_ToothNumber",
          table: "PatientsTeeth",
          column: "ToothNumber");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "PatientsTeeth");
    }
  }
}