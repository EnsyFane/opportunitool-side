using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OpportunitoolApi.Infrastructure.Migrations
{
    public partial class OpportunityTableCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Opportunities",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false),
                    RegistrationDeadline = table.Column<DateTime>(type: "TEXT", nullable: true),
                    RegistrationLink = table.Column<string>(type: "TEXT", nullable: true),
                    OrganizerName = table.Column<string>(type: "TEXT", nullable: false),
                    OrganizerPhone = table.Column<string>(type: "TEXT", nullable: true),
                    OrganizerEmail = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opportunities", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Opportunities");
        }
    }
}
