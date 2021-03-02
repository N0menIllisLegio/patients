using Microsoft.EntityFrameworkCore.Migrations;

namespace Patients.Migrations
{
  public partial class AddPatientDescriptionMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AddColumn<string>(
        name: "Description",
        table: "Patients",
        type: "TEXT",
        nullable: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropColumn(
        name: "Description",
        table: "Patients");
    }
  }
}