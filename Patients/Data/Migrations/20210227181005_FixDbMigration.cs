using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patients.Migrations
{
  public partial class FixDbMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        name: "Diaries");

      migrationBuilder.DropColumn(
        name: "Place",
        table: "Patients");

      migrationBuilder.DropColumn(
        name: "ScreensDirectory",
        table: "Patients");

      migrationBuilder.DropColumn(
        name: "Sex",
        table: "Patients");

      migrationBuilder.DropColumn(
        name: "Teeth",
        table: "Patients");

      migrationBuilder.RenameColumn(
        name: "Id",
        table: "Patients",
        newName: "ID");

      migrationBuilder.AlterColumn<DateTime>(
        name: "LastVisitDate",
        table: "Patients",
        type: "TEXT",
        nullable: false,
        defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
        oldClrType: typeof(string),
        oldType: "TEXT",
        oldNullable: true);

      migrationBuilder.AlterColumn<DateTime>(
        name: "BirthDate",
        table: "Patients",
        type: "TEXT",
        nullable: false,
        defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
        oldClrType: typeof(string),
        oldType: "TEXT",
        oldNullable: true);

      migrationBuilder.AlterColumn<Guid>(
        name: "ID",
        table: "Patients",
        type: "TEXT",
        nullable: false,
        oldClrType: typeof(int),
        oldType: "INTEGER")
          .OldAnnotation("Sqlite:Autoincrement", true);

      migrationBuilder.AddColumn<int>(
        name: "Gender",
        table: "Patients",
        type: "INTEGER",
        nullable: false,
        defaultValue: 0);

      migrationBuilder.AddColumn<int>(
        name: "Storage",
        table: "Patients",
        type: "INTEGER",
        nullable: false,
        defaultValue: 0);

      migrationBuilder.CreateTable(
        name: "DentalRecord",
        columns: table => new
        {
          PatientID = table.Column<Guid>(type: "TEXT", nullable: false),
          Tooth11 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth12 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth13 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth14 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth15 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth16 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth17 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth18 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth21 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth22 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth23 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth24 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth25 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth26 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth27 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth28 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth31 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth32 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth33 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth34 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth35 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth36 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth37 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth38 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth41 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth42 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth43 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth44 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth45 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth46 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth47 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth48 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth51 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth52 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth53 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth54 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth55 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth61 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth62 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth63 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth64 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth65 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth71 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth72 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth73 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth74 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth75 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth81 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth82 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth83 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth84 = table.Column<int>(type: "INTEGER", nullable: false),
          Tooth85 = table.Column<int>(type: "INTEGER", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_DentalRecord", x => x.PatientID);
          table.ForeignKey(
            name: "FK_DentalRecord_Patients_PatientID",
            column: x => x.PatientID,
            principalTable: "Patients",
            principalColumn: "ID",
            onDelete: ReferentialAction.Cascade);
        });

      migrationBuilder.CreateTable(
        name: "DiaryRecords",
        columns: table => new
        {
          ID = table.Column<Guid>(type: "TEXT", nullable: false),
          Diagnosis = table.Column<string>(type: "TEXT", nullable: true),
          Date = table.Column<DateTime>(type: "TEXT", nullable: false),
          PatientID = table.Column<Guid>(type: "TEXT", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_DiaryRecords", x => x.ID);
          table.ForeignKey(
            name: "FK_DiaryRecords_Patients_PatientID",
            column: x => x.PatientID,
            principalTable: "Patients",
            principalColumn: "ID",
            onDelete: ReferentialAction.Cascade);
        });

      migrationBuilder.CreateIndex(
        name: "IX_DiaryRecords_PatientID",
        table: "DiaryRecords",
        column: "PatientID");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        name: "DentalRecord");

      migrationBuilder.DropTable(
        name: "DiaryRecords");

      migrationBuilder.DropColumn(
        name: "Gender",
        table: "Patients");

      migrationBuilder.DropColumn(
        name: "Storage",
        table: "Patients");

      migrationBuilder.RenameColumn(
        name: "ID",
        table: "Patients",
        newName: "Id");

      migrationBuilder.AlterColumn<string>(
        name: "LastVisitDate",
        table: "Patients",
        type: "TEXT",
        nullable: true,
        oldClrType: typeof(DateTime),
        oldType: "TEXT");

      migrationBuilder.AlterColumn<string>(
        name: "BirthDate",
        table: "Patients",
        type: "TEXT",
        nullable: true,
        oldClrType: typeof(DateTime),
        oldType: "TEXT");

      migrationBuilder.AlterColumn<int>(
        name: "Id",
        table: "Patients",
        type: "INTEGER",
        nullable: false,
        oldClrType: typeof(Guid),
        oldType: "TEXT")
          .Annotation("Sqlite:Autoincrement", true);

      migrationBuilder.AddColumn<string>(
        name: "Place",
        table: "Patients",
        type: "TEXT",
        nullable: true);

      migrationBuilder.AddColumn<string>(
        name: "ScreensDirectory",
        table: "Patients",
        type: "TEXT",
        nullable: true);

      migrationBuilder.AddColumn<string>(
        name: "Sex",
        table: "Patients",
        type: "TEXT",
        nullable: true);

      migrationBuilder.AddColumn<string>(
        name: "Teeth",
        table: "Patients",
        type: "TEXT",
        nullable: true);

      migrationBuilder.CreateTable(
        name: "Diaries",
        columns: table => new
        {
          Id = table.Column<int>(type: "INTEGER", nullable: false)
            .Annotation("Sqlite:Autoincrement", true),
          Diagnosis = table.Column<string>(type: "TEXT", nullable: true),
          PatientId = table.Column<int>(type: "INTEGER", nullable: true),
          Date = table.Column<string>(type: "TEXT", nullable: true)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_Diaries", x => x.Id);
        });
    }
  }
}
