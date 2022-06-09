using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Test2T.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    IdCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProductionYear = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Id_Car", x => x.IdCar);
                });

            migrationBuilder.CreateTable(
                name: "Mechanic",
                columns: table => new
                {
                    IdMechanic = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanic", x => x.IdMechanic);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypeDict",
                columns: table => new
                {
                    IdServiceType = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceType = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypeDict", x => x.IdServiceType);
                });

            migrationBuilder.CreateTable(
                name: "Inspection",
                columns: table => new
                {
                    IdInspection = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdCar = table.Column<int>(type: "int", nullable: false),
                    IdMechanic = table.Column<int>(type: "int", nullable: false),
                    InspectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    IdCarNavIdCar = table.Column<int>(type: "int", nullable: true),
                    IdMechanicNavIdMechanic = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inspection", x => x.IdInspection);
                    table.ForeignKey(
                        name: "FK_Inspection_Car_IdCarNavIdCar",
                        column: x => x.IdCarNavIdCar,
                        principalTable: "Car",
                        principalColumn: "IdCar",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Inspection_Mechanic_IdMechanicNavIdMechanic",
                        column: x => x.IdMechanicNavIdMechanic,
                        principalTable: "Mechanic",
                        principalColumn: "IdMechanic",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypeDict_Inspection",
                columns: table => new
                {
                    IdServiceType = table.Column<int>(type: "int", nullable: false),
                    IdInspection = table.Column<int>(type: "int", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    InspectionIdInspection = table.Column<int>(type: "int", nullable: true),
                    ServiceTypeDictIdServiceType = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypeDict_Inspection", x => new { x.IdServiceType, x.IdInspection });
                    table.ForeignKey(
                        name: "FK_ServiceTypeDict_Inspection_Inspection_InspectionIdInspection",
                        column: x => x.InspectionIdInspection,
                        principalTable: "Inspection",
                        principalColumn: "IdInspection",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ServiceTypeDict_Inspection_ServiceTypeDict_ServiceTypeDictIdServiceType",
                        column: x => x.ServiceTypeDictIdServiceType,
                        principalTable: "ServiceTypeDict",
                        principalColumn: "IdServiceType",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Car",
                columns: new[] { "IdCar", "Name", "ProductionYear" },
                values: new object[] { 1, "Corsa", 2018 });

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_IdCarNavIdCar",
                table: "Inspection",
                column: "IdCarNavIdCar");

            migrationBuilder.CreateIndex(
                name: "IX_Inspection_IdMechanicNavIdMechanic",
                table: "Inspection",
                column: "IdMechanicNavIdMechanic");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypeDict_Inspection_InspectionIdInspection",
                table: "ServiceTypeDict_Inspection",
                column: "InspectionIdInspection");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceTypeDict_Inspection_ServiceTypeDictIdServiceType",
                table: "ServiceTypeDict_Inspection",
                column: "ServiceTypeDictIdServiceType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceTypeDict_Inspection");

            migrationBuilder.DropTable(
                name: "Inspection");

            migrationBuilder.DropTable(
                name: "ServiceTypeDict");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Mechanic");
        }
    }
}
