using Microsoft.EntityFrameworkCore.Migrations;

namespace Patients.Migrations
{
  public partial class AddDiagnosisColumnMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<string>(
        name: "Diagnosis",
        table: "Payments",
        type: "TEXT",
        nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
        name: "Diagnosis",
        table: "Payments");
    }
  }
}