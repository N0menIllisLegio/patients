using Microsoft.EntityFrameworkCore.Migrations;

namespace Patients.Migrations
{
  public partial class InitialMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
        name: "Diaries",
        columns: table => new
        {
          Id = table.Column<int>(type: "INTEGER", nullable: false)
                .Annotation("Sqlite:Autoincrement", true),
          PatientId = table.Column<int>(type: "INTEGER", nullable: true),
          Diagnosis = table.Column<string>(type: "TEXT", nullable: true),
          Date = table.Column<string>(type: "TEXT", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Diaries", x => x.Id);
        });

      migrationBuilder.CreateTable(
        name: "Patients",
        columns: table => new
        {
          Id = table.Column<int>(type: "INTEGER", nullable: false)
                .Annotation("Sqlite:Autoincrement", true),
          BirthDate = table.Column<string>(type: "TEXT", nullable: true),
          LastVisitDate = table.Column<string>(type: "TEXT", nullable: true),
          Sex = table.Column<string>(type: "TEXT", nullable: true),
          Teeth = table.Column<string>(type: "TEXT", nullable: true),
          Address = table.Column<string>(type: "TEXT", nullable: true),
          Diagnosis = table.Column<string>(type: "TEXT", nullable: true),
          Name = table.Column<string>(type: "TEXT", nullable: true),
          PhoneNumber = table.Column<string>(type: "TEXT", nullable: true),
          Place = table.Column<string>(type: "TEXT", nullable: true),
          ScreensDirectory = table.Column<string>(type: "TEXT", nullable: true),
          SecondName = table.Column<string>(type: "TEXT", nullable: true),
          Surname = table.Column<string>(type: "TEXT", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Patients", x => x.Id);
        });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        name: "Diaries");

      migrationBuilder.DropTable(
        name: "Patients");
    }
  }
}
