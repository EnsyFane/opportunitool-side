using Microsoft.EntityFrameworkCore.Migrations;

namespace OpportunitoolApi.Infrastructure.Migrations
{
    public partial class ExpandOpportunityLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Opportunities");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Opportunities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Opportunities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Opportunities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "County",
                table: "Opportunities",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsOnline",
                table: "Opportunities",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "County",
                table: "Opportunities");

            migrationBuilder.DropColumn(
                name: "IsOnline",
                table: "Opportunities");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Opportunities",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }
    }
}