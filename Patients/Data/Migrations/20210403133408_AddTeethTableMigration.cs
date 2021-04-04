using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Patients.Migrations
{
  public partial class AddTeethTableMigration: Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_DentalRecords_Patients_PatientID",
          table: "DentalRecords");

      migrationBuilder.DropPrimaryKey(
          name: "PK_DentalRecords",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "PatientID",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth11",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth12",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth13",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth14",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth15",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth16",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth17",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth18",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth21",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth22",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth23",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth24",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth25",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth26",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth27",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth28",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth31",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth32",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth33",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth34",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth35",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth36",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth37",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth38",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth41",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth42",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth43",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth44",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth45",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth46",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth47",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth48",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth51",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth52",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth53",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth54",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth55",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth61",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth62",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth63",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth64",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth65",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth71",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth72",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth73",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth74",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth75",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth81",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Tooth82",
          table: "DentalRecords");

      migrationBuilder.RenameColumn(
          name: "Tooth85",
          table: "DentalRecords",
          newName: "ToStatus");

      migrationBuilder.RenameColumn(
          name: "Tooth84",
          table: "DentalRecords",
          newName: "FromStatus");

      migrationBuilder.RenameColumn(
          name: "Tooth83",
          table: "DentalRecords",
          newName: "ToothNumber");

      migrationBuilder.AddColumn<string>(
          name: "Cause",
          table: "DentalRecords",
          type: "TEXT",
          nullable: true);

      migrationBuilder.AddPrimaryKey(
          name: "PK_DentalRecords",
          table: "DentalRecords",
          column: "ToothNumber");

      migrationBuilder.CreateTable(
          name: "Teeth",
          columns: table => new
          {
            Number = table.Column<int>(type: "INTEGER", nullable: false)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Teeth", x => x.Number);
          });

      migrationBuilder.AddForeignKey(
          name: "FK_DentalRecords_Teeth_ToothNumber",
          table: "DentalRecords",
          column: "ToothNumber",
          principalTable: "Teeth",
          principalColumn: "Number",
          onDelete: ReferentialAction.Restrict);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_DentalRecords_Teeth_ToothNumber",
          table: "DentalRecords");

      migrationBuilder.DropTable(
          name: "Teeth");

      migrationBuilder.DropPrimaryKey(
          name: "PK_DentalRecords",
          table: "DentalRecords");

      migrationBuilder.DropColumn(
          name: "Cause",
          table: "DentalRecords");

      migrationBuilder.RenameColumn(
          name: "ToStatus",
          table: "DentalRecords",
          newName: "Tooth85");

      migrationBuilder.RenameColumn(
          name: "FromStatus",
          table: "DentalRecords",
          newName: "Tooth84");

      migrationBuilder.RenameColumn(
          name: "ToothNumber",
          table: "DentalRecords",
          newName: "Tooth83");

      migrationBuilder.AddColumn<Guid>(
          name: "PatientID",
          table: "DentalRecords",
          type: "TEXT",
          nullable: false,
          defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

      migrationBuilder.AddColumn<int>(
          name: "Tooth11",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth12",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth13",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth14",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth15",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth16",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth17",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth18",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth21",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth22",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth23",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth24",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth25",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth26",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth27",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth28",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth31",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth32",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth33",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth34",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth35",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth36",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth37",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth38",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth41",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth42",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth43",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth44",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth45",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth46",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth47",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth48",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth51",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth52",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth53",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth54",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth55",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth61",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth62",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth63",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth64",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth65",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth71",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth72",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth73",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth74",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth75",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth81",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<int>(
          name: "Tooth82",
          table: "DentalRecords",
          type: "INTEGER",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddPrimaryKey(
          name: "PK_DentalRecords",
          table: "DentalRecords",
          column: "PatientID");

      migrationBuilder.AddForeignKey(
          name: "FK_DentalRecords_Patients_PatientID",
          table: "DentalRecords",
          column: "PatientID",
          principalTable: "Patients",
          principalColumn: "ID",
          onDelete: ReferentialAction.Cascade);
    }
  }
}