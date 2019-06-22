using Microsoft.EntityFrameworkCore.Migrations;

namespace DockerApiDemo.Data.Migrations
{
    public partial class CustomerSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 1, "m.verstappen@redbull.com", "Max", "Verstappen", "No1R4cer" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 2, "d.ricciardo@renault.com", "Daniel", "Ricciardo", "b1gSM1L35" });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Email", "FirstName", "LastName", "Password" },
                values: new object[] { 3, "k.raikkonen@alfaromeo.com", "Kimi", "Raikkonen", "1W4SHaving4!*&$" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
