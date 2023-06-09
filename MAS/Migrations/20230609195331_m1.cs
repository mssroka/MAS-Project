using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MAS.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Element",
                columns: table => new
                {
                    idElement = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Element_pk", x => x.idElement);
                });

            migrationBuilder.CreateTable(
                name: "Painting",
                columns: table => new
                {
                    idPainting = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    colour = table.Column<string>(type: "varchar(7)", unicode: false, maxLength: 7, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Painting_pk", x => x.idPainting);
                });

            migrationBuilder.CreateTable(
                name: "Part",
                columns: table => new
                {
                    idPart = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    cost = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Part_pk", x => x.idPart);
                });

            migrationBuilder.CreateTable(
                name: "PartsExchange",
                columns: table => new
                {
                    idPartsExchange = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PartsExchange_pk", x => x.idPartsExchange);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    idPerson = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    lastName = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    phoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Person_pk", x => x.idPerson);
                });

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    idService = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    address = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    maxEmpAmount = table.Column<int>(type: "int", nullable: false),
                    empAmount = table.Column<int>(type: "int", nullable: false),
                    opening = table.Column<DateTime>(type: "datetime", nullable: false),
                    closing = table.Column<DateTime>(type: "datetime", nullable: false),
                    phoneNumber = table.Column<string>(type: "varchar(15)", unicode: false, maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Service_pk", x => x.idService);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    idPerson = table.Column<int>(type: "int", nullable: false),
                    notes = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Client_pk", x => x.idPerson);
                    table.ForeignKey(
                        name: "Client_Person",
                        column: x => x.idPerson,
                        principalTable: "Person",
                        principalColumn: "idPerson");
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    idPerson = table.Column<int>(type: "int", nullable: false),
                    pesel = table.Column<int>(type: "int", nullable: false),
                    hireDate = table.Column<DateTime>(type: "date", nullable: false),
                    promotionDate = table.Column<DateTime>(type: "date", nullable: false),
                    idService = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Manager_pk", x => x.idPerson);
                    table.ForeignKey(
                        name: "Manager_Person",
                        column: x => x.idPerson,
                        principalTable: "Person",
                        principalColumn: "idPerson");
                    table.ForeignKey(
                        name: "Manager_Service",
                        column: x => x.idService,
                        principalTable: "Service",
                        principalColumn: "idService");
                });

            migrationBuilder.CreateTable(
                name: "Serviceman",
                columns: table => new
                {
                    idPerson = table.Column<int>(type: "int", nullable: false),
                    pesel = table.Column<int>(type: "int", nullable: false),
                    hireDate = table.Column<DateTime>(type: "date", nullable: false),
                    skills = table.Column<int>(type: "int", nullable: false),
                    repairAmount = table.Column<int>(type: "int", nullable: false),
                    idService = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Serviceman_pk", x => x.idPerson);
                    table.ForeignKey(
                        name: "Serviceman_Person",
                        column: x => x.idPerson,
                        principalTable: "Person",
                        principalColumn: "idPerson");
                    table.ForeignKey(
                        name: "Serviceman_Service",
                        column: x => x.idService,
                        principalTable: "Service",
                        principalColumn: "idService");
                });

            migrationBuilder.CreateTable(
                name: "Trainee",
                columns: table => new
                {
                    idPerson = table.Column<int>(type: "int", nullable: false),
                    salary = table.Column<int>(type: "int", nullable: false),
                    internshipStartDate = table.Column<DateTime>(type: "date", nullable: false),
                    lengthOfInternship = table.Column<int>(type: "int", nullable: false),
                    idService = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Trainee_pk", x => x.idPerson);
                    table.ForeignKey(
                        name: "Trainee_Person",
                        column: x => x.idPerson,
                        principalTable: "Person",
                        principalColumn: "idPerson");
                    table.ForeignKey(
                        name: "Trainee_Service",
                        column: x => x.idService,
                        principalTable: "Service",
                        principalColumn: "idService");
                });

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    idCar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    plates = table.Column<string>(type: "varchar(9)", unicode: false, maxLength: 9, nullable: false),
                    brand = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    model = table.Column<string>(type: "varchar(30)", unicode: false, maxLength: 30, nullable: false),
                    idPerson = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Car_pk", x => x.idCar);
                    table.ForeignKey(
                        name: "Car_Client",
                        column: x => x.idPerson,
                        principalTable: "Client",
                        principalColumn: "idPerson");
                });

            migrationBuilder.CreateTable(
                name: "Job",
                columns: table => new
                {
                    idJob = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    start = table.Column<DateTime>(type: "date", nullable: false),
                    end = table.Column<DateTime>(type: "date", nullable: false),
                    cost = table.Column<int>(type: "int", nullable: false),
                    status = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    note = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    idCar = table.Column<int>(type: "int", nullable: false),
                    idPerson = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Job_pk", x => x.idJob);
                    table.ForeignKey(
                        name: "Job_Car",
                        column: x => x.idCar,
                        principalTable: "Car",
                        principalColumn: "idCar");
                    table.ForeignKey(
                        name: "Job_Serviceman",
                        column: x => x.idPerson,
                        principalTable: "Serviceman",
                        principalColumn: "idPerson");
                });

            migrationBuilder.CreateTable(
                name: "Diagnosis",
                columns: table => new
                {
                    idPerson = table.Column<int>(type: "int", nullable: false),
                    idJob = table.Column<int>(type: "int", nullable: false),
                    diagText = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Diagnosis_pk", x => new { x.idJob, x.idPerson });
                    table.ForeignKey(
                        name: "Diagnosis_Job",
                        column: x => x.idJob,
                        principalTable: "Job",
                        principalColumn: "idJob");
                    table.ForeignKey(
                        name: "Diagnosis_Manager",
                        column: x => x.idPerson,
                        principalTable: "Manager",
                        principalColumn: "idPerson");
                });

            migrationBuilder.CreateTable(
                name: "Overview",
                columns: table => new
                {
                    idOverview = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cost = table.Column<int>(type: "int", nullable: false),
                    idJob = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Overview_pk", x => x.idOverview);
                    table.ForeignKey(
                        name: "Overview_Job",
                        column: x => x.idJob,
                        principalTable: "Job",
                        principalColumn: "idJob");
                });

            migrationBuilder.CreateTable(
                name: "PaintingElement",
                columns: table => new
                {
                    idElement = table.Column<int>(type: "int", nullable: false),
                    idPainting = table.Column<int>(type: "int", nullable: false),
                    idJob = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PaintingElement_pk", x => new { x.idElement, x.idPainting, x.idJob });
                    table.ForeignKey(
                        name: "PaintingElement_Copy_of_Element",
                        column: x => x.idElement,
                        principalTable: "Element",
                        principalColumn: "idElement");
                    table.ForeignKey(
                        name: "PaintingElement_Copy_of_Painting",
                        column: x => x.idPainting,
                        principalTable: "Painting",
                        principalColumn: "idPainting");
                    table.ForeignKey(
                        name: "PaintingElement_Job",
                        column: x => x.idJob,
                        principalTable: "Job",
                        principalColumn: "idJob");
                });

            migrationBuilder.CreateTable(
                name: "Replacement",
                columns: table => new
                {
                    idPartsExchange = table.Column<int>(type: "int", nullable: false),
                    idJob = table.Column<int>(type: "int", nullable: false),
                    idPart = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("Replacement_pk", x => new { x.idPartsExchange, x.idJob, x.idPart });
                    table.ForeignKey(
                        name: "Replacement_Job",
                        column: x => x.idJob,
                        principalTable: "Job",
                        principalColumn: "idJob");
                    table.ForeignKey(
                        name: "Replacement_Part",
                        column: x => x.idPart,
                        principalTable: "Part",
                        principalColumn: "idPart");
                    table.ForeignKey(
                        name: "Replacement_PartsExchange",
                        column: x => x.idPartsExchange,
                        principalTable: "PartsExchange",
                        principalColumn: "idPartsExchange");
                });

            migrationBuilder.CreateTable(
                name: "ServiceActivity",
                columns: table => new
                {
                    idServiceActivity = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    difficultyLevel = table.Column<int>(type: "int", nullable: false),
                    serviceDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idOverview = table.Column<int>(type: "int", nullable: true),
                    idPartsExchange = table.Column<int>(type: "int", nullable: true),
                    idPainting = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("ServiceActivity_pk", x => x.idServiceActivity);
                    table.ForeignKey(
                        name: "ServiceActivity_Overview",
                        column: x => x.idOverview,
                        principalTable: "Overview",
                        principalColumn: "idOverview");
                    table.ForeignKey(
                        name: "ServiceActivity_Painting",
                        column: x => x.idPainting,
                        principalTable: "Painting",
                        principalColumn: "idPainting");
                    table.ForeignKey(
                        name: "ServiceActivity_PartsExchange",
                        column: x => x.idPartsExchange,
                        principalTable: "PartsExchange",
                        principalColumn: "idPartsExchange");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Car_idPerson",
                table: "Car",
                column: "idPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosis_idPerson",
                table: "Diagnosis",
                column: "idPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Job_idCar",
                table: "Job",
                column: "idCar");

            migrationBuilder.CreateIndex(
                name: "IX_Job_idPerson",
                table: "Job",
                column: "idPerson");

            migrationBuilder.CreateIndex(
                name: "IX_Manager_idService",
                table: "Manager",
                column: "idService");

            migrationBuilder.CreateIndex(
                name: "IX_Overview_idJob",
                table: "Overview",
                column: "idJob");

            migrationBuilder.CreateIndex(
                name: "IX_PaintingElement_idJob",
                table: "PaintingElement",
                column: "idJob");

            migrationBuilder.CreateIndex(
                name: "IX_PaintingElement_idPainting",
                table: "PaintingElement",
                column: "idPainting");

            migrationBuilder.CreateIndex(
                name: "IX_Replacement_idJob",
                table: "Replacement",
                column: "idJob");

            migrationBuilder.CreateIndex(
                name: "IX_Replacement_idPart",
                table: "Replacement",
                column: "idPart");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceActivity_idOverview",
                table: "ServiceActivity",
                column: "idOverview");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceActivity_idPainting",
                table: "ServiceActivity",
                column: "idPainting");

            migrationBuilder.CreateIndex(
                name: "IX_ServiceActivity_idPartsExchange",
                table: "ServiceActivity",
                column: "idPartsExchange");

            migrationBuilder.CreateIndex(
                name: "IX_Serviceman_idService",
                table: "Serviceman",
                column: "idService");

            migrationBuilder.CreateIndex(
                name: "IX_Trainee_idService",
                table: "Trainee",
                column: "idService");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnosis");

            migrationBuilder.DropTable(
                name: "PaintingElement");

            migrationBuilder.DropTable(
                name: "Replacement");

            migrationBuilder.DropTable(
                name: "ServiceActivity");

            migrationBuilder.DropTable(
                name: "Trainee");

            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "Element");

            migrationBuilder.DropTable(
                name: "Part");

            migrationBuilder.DropTable(
                name: "Overview");

            migrationBuilder.DropTable(
                name: "Painting");

            migrationBuilder.DropTable(
                name: "PartsExchange");

            migrationBuilder.DropTable(
                name: "Job");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "Serviceman");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Service");

            migrationBuilder.DropTable(
                name: "Person");
        }
    }
}
