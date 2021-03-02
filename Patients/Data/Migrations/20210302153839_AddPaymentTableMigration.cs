using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patients.Migrations
{
  public partial class AddPaymentTableMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: "Payments",
        columns: table => new
        {
          ID = table.Column<Guid>(type: "TEXT", nullable: false),
          Amount = table.Column<decimal>(type: "TEXT", nullable: false),
          DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
          PatientID = table.Column<Guid>(type: "TEXT", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Payments", x => x.ID);
          table.ForeignKey(
            name: "FK_Payments_Patients_PatientID",
            column: x => x.PatientID,
            principalTable: "Patients",
            principalColumn: "ID",
            onDelete: ReferentialAction.Cascade);
        });

      migrationBuilder.CreateIndex(
        name: "IX_Payments_PatientID",
        table: "Payments",
        column: "PatientID");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        name: "Payments");
    }
  }
}