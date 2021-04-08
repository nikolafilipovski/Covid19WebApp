using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19.Data.Migrations
{
    public partial class prop_deleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_City_cityID",
                table: "Hospitals");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_CurrentCondition_currentConditionID",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrentCondition",
                table: "CurrentCondition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_City",
                table: "City");

            migrationBuilder.DropColumn(
                name: "patientCondition",
                table: "Patients");

            migrationBuilder.RenameTable(
                name: "CurrentCondition",
                newName: "CurrentConditions");

            migrationBuilder.RenameTable(
                name: "City",
                newName: "Cities");

            migrationBuilder.AlterColumn<int>(
                name: "currentConditionID",
                table: "Patients",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrentConditions",
                table: "CurrentConditions",
                column: "currentConditionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cities",
                table: "Cities",
                column: "cityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_Cities_cityID",
                table: "Hospitals",
                column: "cityID",
                principalTable: "Cities",
                principalColumn: "cityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_CurrentConditions_currentConditionID",
                table: "Patients",
                column: "currentConditionID",
                principalTable: "CurrentConditions",
                principalColumn: "currentConditionID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_Cities_cityID",
                table: "Hospitals");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_CurrentConditions_currentConditionID",
                table: "Patients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CurrentConditions",
                table: "CurrentConditions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cities",
                table: "Cities");

            migrationBuilder.RenameTable(
                name: "CurrentConditions",
                newName: "CurrentCondition");

            migrationBuilder.RenameTable(
                name: "Cities",
                newName: "City");

            migrationBuilder.AlterColumn<int>(
                name: "currentConditionID",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "patientCondition",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CurrentCondition",
                table: "CurrentCondition",
                column: "currentConditionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_City",
                table: "City",
                column: "cityID");

            migrationBuilder.AddForeignKey(
                name: "FK_Hospitals_City_cityID",
                table: "Hospitals",
                column: "cityID",
                principalTable: "City",
                principalColumn: "cityID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_CurrentCondition_currentConditionID",
                table: "Patients",
                column: "currentConditionID",
                principalTable: "CurrentCondition",
                principalColumn: "currentConditionID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
