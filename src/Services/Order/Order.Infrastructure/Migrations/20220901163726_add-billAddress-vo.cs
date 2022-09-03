using Microsoft.EntityFrameworkCore.Migrations;

namespace Order.Infrastructure.Migrations
{
    public partial class addbillAddressvo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ZipCode",
                schema: "dbo",
                table: "Order",
                newName: "billingAddress_ZipCode");

            migrationBuilder.RenameColumn(
                name: "State",
                schema: "dbo",
                table: "Order",
                newName: "billingAddress_State");

            migrationBuilder.RenameColumn(
                name: "LastName",
                schema: "dbo",
                table: "Order",
                newName: "billingAddress_LastName");

            migrationBuilder.RenameColumn(
                name: "FirstName",
                schema: "dbo",
                table: "Order",
                newName: "billingAddress_FirstName");

            migrationBuilder.RenameColumn(
                name: "EmailAddress",
                schema: "dbo",
                table: "Order",
                newName: "billingAddress_EmailAddress");

            migrationBuilder.RenameColumn(
                name: "Country",
                schema: "dbo",
                table: "Order",
                newName: "billingAddress_Country");

            migrationBuilder.RenameColumn(
                name: "AddressLine",
                schema: "dbo",
                table: "Order",
                newName: "billingAddress_AddressLine");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "billingAddress_ZipCode",
                schema: "dbo",
                table: "Order",
                newName: "ZipCode");

            migrationBuilder.RenameColumn(
                name: "billingAddress_State",
                schema: "dbo",
                table: "Order",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "billingAddress_LastName",
                schema: "dbo",
                table: "Order",
                newName: "LastName");

            migrationBuilder.RenameColumn(
                name: "billingAddress_FirstName",
                schema: "dbo",
                table: "Order",
                newName: "FirstName");

            migrationBuilder.RenameColumn(
                name: "billingAddress_EmailAddress",
                schema: "dbo",
                table: "Order",
                newName: "EmailAddress");

            migrationBuilder.RenameColumn(
                name: "billingAddress_Country",
                schema: "dbo",
                table: "Order",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "billingAddress_AddressLine",
                schema: "dbo",
                table: "Order",
                newName: "AddressLine");
        }
    }
}
