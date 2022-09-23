using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RIS_API.Data.Migrations
{
    public partial class SeedingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Modalitytypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "CR" },
                    { 2, "DR" }
                });

            migrationBuilder.InsertData(
                table: "Proceduretypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Shoulder" },
                    { 2, "Head" }
                });

            migrationBuilder.InsertData(
                table: "Modalities",
                columns: new[] { "Id", "AeTitle", "Description", "IpAddress", "Modalitytypeid", "Name", "Port" },
                values: new object[] { 1, "CRModAE", "CR Modality", "127.0.0.1", 1, "CR_Modality", 104 });

            migrationBuilder.InsertData(
                table: "Modalities",
                columns: new[] { "Id", "AeTitle", "Description", "IpAddress", "Modalitytypeid", "Name", "Port" },
                values: new object[] { 2, "MRModAE", "MR Modality", "127.0.0.1", 1, "MR_Modality", 104 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Modalities",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Modalities",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Modalitytypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Proceduretypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Proceduretypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Modalitytypes",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
