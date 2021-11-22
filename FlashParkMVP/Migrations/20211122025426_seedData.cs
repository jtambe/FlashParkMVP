using Microsoft.EntityFrameworkCore.Migrations;

namespace FlashParkMVP.Migrations
{
    public partial class seedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ParkingLots",
                columns: new[] { "ParkingLotId", "ParkingLotAddress" },
                values: new object[] { 2, "Garage1" });

            migrationBuilder.InsertData(
                table: "ParkingLots",
                columns: new[] { "ParkingLotId", "ParkingLotAddress" },
                values: new object[] { 3, "Garage2" });

            migrationBuilder.InsertData(
                table: "ParkingLots",
                columns: new[] { "ParkingLotId", "ParkingLotAddress" },
                values: new object[] { 1, "Garage3" });

            migrationBuilder.InsertData(
                table: "ParkingSpaces",
                columns: new[] { "ParkingSpaceId", "IsAvailable", "ParkingLotId" },
                values: new object[,]
                {
                    { 6, true, 2 },
                    { 7, false, 2 },
                    { 8, true, 2 },
                    { 9, true, 2 },
                    { 10, true, 2 },
                    { 11, false, 3 },
                    { 12, false, 3 },
                    { 13, true, 3 },
                    { 1, true, 1 },
                    { 2, false, 1 },
                    { 3, true, 1 },
                    { 4, false, 1 },
                    { 5, true, 1 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "ParkingSpaceId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "ParkingSpaceId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "ParkingSpaceId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "ParkingSpaceId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "ParkingSpaceId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "ParkingSpaceId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "ParkingSpaceId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "ParkingSpaceId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "ParkingSpaceId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "ParkingSpaceId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "ParkingSpaceId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "ParkingSpaceId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ParkingSpaces",
                keyColumn: "ParkingSpaceId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ParkingLots",
                keyColumn: "ParkingLotId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ParkingLots",
                keyColumn: "ParkingLotId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ParkingLots",
                keyColumn: "ParkingLotId",
                keyValue: 3);
        }
    }
}
