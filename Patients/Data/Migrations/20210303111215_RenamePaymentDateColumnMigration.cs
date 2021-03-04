using Microsoft.EntityFrameworkCore.Migrations;

namespace Patients.Migrations
{
  public partial class RenamePaymentDateColumnMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.RenameColumn(
        name: "DateTime",
        table: "Payments",
        newName: "Date");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.RenameColumn(
        name: "Date",
        table: "Payments",
        newName: "DateTime");
    }
  }
}
