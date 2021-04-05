using Microsoft.EntityFrameworkCore.Migrations;

namespace Covid19.Data.Migrations
{
    public partial class tables_added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cured",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "deceased",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "ill",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "hospitalLocation",
                table: "Hospitals");

            migrationBuilder.AddColumn<int>(
                name: "currentConditionID",
                table: "Patients",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "patientCondition",
                table: "Patients",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "cityID",
                table: "Hospitals",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    cityID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cityName = table.Column<string>(maxLength: 50, nullable: false),
                    population = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.cityID);
                });

            migrationBuilder.CreateTable(
                name: "CurrentCondition",
                columns: table => new
                {
                    currentConditionID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    confirmedCases = table.Column<int>(nullable: false),
                    activeCases = table.Column<int>(nullable: false),
                    recovered = table.Column<int>(nullable: false),
                    confirmedDeaths = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentCondition", x => x.currentConditionID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_currentConditionID",
                table: "Patients",
                column: "currentConditionID");

            migrationBuilder.CreateIndex(
                name: "IX_Hospitals_cityID",
                table: "Hospitals",
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hospitals_City_cityID",
                table: "Hospitals");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_CurrentCondition_currentConditionID",
                table: "Patients");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "CurrentCondition");

            migrationBuilder.DropIndex(
                name: "IX_Patients_currentConditionID",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Hospitals_cityID",
                table: "Hospitals");

            migrationBuilder.DropColumn(
                name: "currentConditionID",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "patientCondition",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "cityID",
                table: "Hospitals");

            migrationBuilder.AddColumn<string>(
                name: "cured",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "deceased",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ill",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "hospitalLocation",
                table: "Hospitals",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }
    }
}
