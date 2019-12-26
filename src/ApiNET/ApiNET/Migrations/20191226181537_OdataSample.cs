using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ApiNET.Migrations
{
    public partial class OdataSample : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 100, nullable: true),
                    ModifyUser = table.Column<string>(maxLength: 100, nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Designation = table.Column<string>(nullable: true),
                    Salary = table.Column<int>(nullable: false),
                    City = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 12, 26, 21, 15, 36, 632, DateTimeKind.Local).AddTicks(6035), new DateTime(2019, 12, 26, 21, 15, 36, 632, DateTimeKind.Local).AddTicks(6038) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 12, 26, 21, 15, 36, 632, DateTimeKind.Local).AddTicks(6086), new DateTime(2019, 12, 26, 21, 15, 36, 632, DateTimeKind.Local).AddTicks(6087) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 12, 26, 21, 15, 36, 630, DateTimeKind.Local).AddTicks(9239), new DateTime(2019, 12, 26, 21, 15, 36, 631, DateTimeKind.Local).AddTicks(6744) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 12, 26, 21, 15, 36, 631, DateTimeKind.Local).AddTicks(7086), new DateTime(2019, 12, 26, 21, 15, 36, 631, DateTimeKind.Local).AddTicks(7093) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 12, 26, 21, 15, 36, 631, DateTimeKind.Local).AddTicks(7098), new DateTime(2019, 12, 26, 21, 15, 36, 631, DateTimeKind.Local).AddTicks(7098) });

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 12, 26, 21, 15, 36, 633, DateTimeKind.Local).AddTicks(1389), new DateTime(2019, 12, 26, 21, 15, 36, 633, DateTimeKind.Local).AddTicks(1392) });

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 12, 26, 21, 15, 36, 633, DateTimeKind.Local).AddTicks(1417), new DateTime(2019, 12, 26, 21, 15, 36, 633, DateTimeKind.Local).AddTicks(1417) });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 12, 26, 21, 15, 36, 633, DateTimeKind.Local).AddTicks(7416), new DateTime(2019, 12, 26, 21, 15, 36, 633, DateTimeKind.Local).AddTicks(7419) });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 12, 26, 21, 15, 36, 633, DateTimeKind.Local).AddTicks(7448), new DateTime(2019, 12, 26, 21, 15, 36, 633, DateTimeKind.Local).AddTicks(7448) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 11, 13, 22, 36, 48, 211, DateTimeKind.Local).AddTicks(2525), new DateTime(2019, 11, 13, 22, 36, 48, 211, DateTimeKind.Local).AddTicks(2528) });

            migrationBuilder.UpdateData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 11, 13, 22, 36, 48, 211, DateTimeKind.Local).AddTicks(2572), new DateTime(2019, 11, 13, 22, 36, 48, 211, DateTimeKind.Local).AddTicks(2572) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 11, 13, 22, 36, 48, 209, DateTimeKind.Local).AddTicks(5324), new DateTime(2019, 11, 13, 22, 36, 48, 210, DateTimeKind.Local).AddTicks(1085) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 11, 13, 22, 36, 48, 210, DateTimeKind.Local).AddTicks(1608), new DateTime(2019, 11, 13, 22, 36, 48, 210, DateTimeKind.Local).AddTicks(1615) });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 11, 13, 22, 36, 48, 210, DateTimeKind.Local).AddTicks(1619), new DateTime(2019, 11, 13, 22, 36, 48, 210, DateTimeKind.Local).AddTicks(1619) });

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 11, 13, 22, 36, 48, 212, DateTimeKind.Local).AddTicks(298), new DateTime(2019, 11, 13, 22, 36, 48, 212, DateTimeKind.Local).AddTicks(300) });

            migrationBuilder.UpdateData(
                table: "Emails",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 11, 13, 22, 36, 48, 212, DateTimeKind.Local).AddTicks(502), new DateTime(2019, 11, 13, 22, 36, 48, 212, DateTimeKind.Local).AddTicks(502) });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 11, 13, 22, 36, 48, 213, DateTimeKind.Local).AddTicks(1089), new DateTime(2019, 11, 13, 22, 36, 48, 213, DateTimeKind.Local).AddTicks(1104) });

            migrationBuilder.UpdateData(
                table: "Phones",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2019, 11, 13, 22, 36, 48, 213, DateTimeKind.Local).AddTicks(1158), new DateTime(2019, 11, 13, 22, 36, 48, 213, DateTimeKind.Local).AddTicks(1158) });
        }
    }
}
