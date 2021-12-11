using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Order.Infrastructure.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Order",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FirstName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    LastName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    EmailAddress = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    AddressLine = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Country = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    State = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    CardName = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    CardNumber = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    Expiration = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    CVV = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    PaymentMethod = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true),
                    LastModifiedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order",
                schema: "dbo");
        }
    }
}
