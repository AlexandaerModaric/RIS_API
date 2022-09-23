using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RIS_API.Data.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Modalitytypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalitytypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Middlename = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    Lastname = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mothername = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthdate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proceduretypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proceduretypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modalities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    AeTitle = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Port = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Modalitytypeid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modalities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Modalities_Modalitytypes_Modalitytypeid",
                        column: x => x.Modalitytypeid,
                        principalTable: "Modalitytypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HL7Messages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Patientid = table.Column<int>(type: "int", nullable: false),
                    Modalityid = table.Column<int>(type: "int", nullable: false),
                    Proceduretypeid = table.Column<int>(type: "int", nullable: false),
                    Studyid = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Startdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Accessionnumber = table.Column<int>(type: "int", nullable: false),
                    Insertdate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModalitytypeId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HL7Messages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HL7Messages_Modalities_Modalityid",
                        column: x => x.Modalityid,
                        principalTable: "Modalities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HL7Messages_Modalitytypes_ModalitytypeId",
                        column: x => x.ModalitytypeId,
                        principalTable: "Modalitytypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_HL7Messages_Patients_Patientid",
                        column: x => x.Patientid,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HL7Messages_Proceduretypes_Proceduretypeid",
                        column: x => x.Proceduretypeid,
                        principalTable: "Proceduretypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HL7Messages_Modalityid",
                table: "HL7Messages",
                column: "Modalityid");

            migrationBuilder.CreateIndex(
                name: "IX_HL7Messages_ModalitytypeId",
                table: "HL7Messages",
                column: "ModalitytypeId");

            migrationBuilder.CreateIndex(
                name: "IX_HL7Messages_Patientid",
                table: "HL7Messages",
                column: "Patientid");

            migrationBuilder.CreateIndex(
                name: "IX_HL7Messages_Proceduretypeid",
                table: "HL7Messages",
                column: "Proceduretypeid");

            migrationBuilder.CreateIndex(
                name: "IX_Modalities_Modalitytypeid",
                table: "Modalities",
                column: "Modalitytypeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HL7Messages");

            migrationBuilder.DropTable(
                name: "Modalities");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Proceduretypes");

            migrationBuilder.DropTable(
                name: "Modalitytypes");
        }
    }
}
