using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApplication1.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BreedTypes",
                columns: table => new
                {
                    IdBreedType = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedTypes", x => x.IdBreedType);
                });

            migrationBuilder.CreateTable(
                name: "Volunteers",
                columns: table => new
                {
                    IdVolunteer = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdSupervisor = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Surname = table.Column<string>(maxLength: 80, nullable: false),
                    Phone = table.Column<string>(maxLength: 30, nullable: false),
                    Address = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 80, nullable: false),
                    StartingDate = table.Column<DateTime>(nullable: false),
                    SupervisorIdVolunteer = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteers", x => x.IdVolunteer);
                    table.ForeignKey(
                        name: "FK_Volunteers_Volunteers_SupervisorIdVolunteer",
                        column: x => x.SupervisorIdVolunteer,
                        principalTable: "Volunteers",
                        principalColumn: "IdVolunteer",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    IdPet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdBreedType = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    IsMale = table.Column<bool>(type: "bit", nullable: false),
                    DateRegistered = table.Column<DateTime>(nullable: false),
                    ApprocimateDateOfBirth = table.Column<DateTime>(nullable: false),
                    DateAdopted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.IdPet);
                    table.ForeignKey(
                        name: "FK_Pets_BreedTypes_IdBreedType",
                        column: x => x.IdBreedType,
                        principalTable: "BreedTypes",
                        principalColumn: "IdBreedType",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Volunteer_Pets",
                columns: table => new
                {
                    IdVolunteer = table.Column<int>(nullable: false),
                    IdPet = table.Column<int>(nullable: false),
                    DateAccepted = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Volunteer_Pets", x => new { x.IdVolunteer, x.IdPet });
                    table.ForeignKey(
                        name: "FK_Volunteer_Pets_Pets_IdPet",
                        column: x => x.IdPet,
                        principalTable: "Pets",
                        principalColumn: "IdPet",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Volunteer_Pets_Volunteers_IdVolunteer",
                        column: x => x.IdVolunteer,
                        principalTable: "Volunteers",
                        principalColumn: "IdVolunteer",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_IdBreedType",
                table: "Pets",
                column: "IdBreedType");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteer_Pets_IdPet",
                table: "Volunteer_Pets",
                column: "IdPet");

            migrationBuilder.CreateIndex(
                name: "IX_Volunteers_SupervisorIdVolunteer",
                table: "Volunteers",
                column: "SupervisorIdVolunteer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Volunteer_Pets");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Volunteers");

            migrationBuilder.DropTable(
                name: "BreedTypes");
        }
    }
}
