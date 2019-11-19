using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace ApiNET.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 100, nullable: true),
                    ModifyUser = table.Column<string>(maxLength: 100, nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    AddressType = table.Column<int>(nullable: false),
                    FlatNumber = table.Column<string>(nullable: true),
                    BuildingNumber = table.Column<string>(nullable: true),
                    BuildingName = table.Column<string>(nullable: true),
                    Street = table.Column<string>(nullable: true),
                    Town = table.Column<string>(nullable: true),
                    County = table.Column<string>(nullable: true),
                    PostCode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    AddressNote = table.Column<string>(nullable: true),
                    ActivePassive = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 100, nullable: true),
                    ModifyUser = table.Column<string>(maxLength: 100, nullable: true),
                    Name = table.Column<string>(nullable: true),
                    SurName = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    CustomerRank = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emails",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 100, nullable: true),
                    ModifyUser = table.Column<string>(maxLength: 100, nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    EmailType = table.Column<int>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    ActivePassive = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 100, nullable: true),
                    ModifyUser = table.Column<string>(maxLength: 100, nullable: true),
                    CustomerId = table.Column<int>(nullable: false),
                    PhoneType = table.Column<int>(nullable: false),
                    Country = table.Column<string>(nullable: true),
                    AreaCode = table.Column<string>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    ActivePassive = table.Column<int>(nullable: false),
                    IsDefault = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "ActivePassive", "AddressNote", "AddressType", "BuildingName", "BuildingNumber", "Country", "County", "CreateUser", "CustomerId", "DateCreated", "DateModified", "FlatNumber", "IsDefault", "IsDeleted", "ModifyUser", "PostCode", "Street", "Town" },
                values: new object[,]
                {
                    { 1L, 0, "Dont post any letter", 0, "MaviBalina Apt.", "123", "Turkey", "Istanbul", "SYSTEM", 1, new DateTime(2019, 11, 13, 22, 36, 48, 211, DateTimeKind.Local).AddTicks(2525), new DateTime(2019, 11, 13, 22, 36, 48, 211, DateTimeKind.Local).AddTicks(2528), "52", true, false, "SYSTEM", "34300", "Yenisehir", "Pendik" },
                    { 2L, 1, "", 1, "Teknopark Istanbul", "321", "Turkey", "Istanbul", "SYSTEM", 1, new DateTime(2019, 11, 13, 22, 36, 48, 211, DateTimeKind.Local).AddTicks(2572), new DateTime(2019, 11, 13, 22, 36, 48, 211, DateTimeKind.Local).AddTicks(2572), "3", false, false, "SYSTEM", "34600", "Yenisehir", "Pendik" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "CreateUser", "CustomerRank", "DateCreated", "DateModified", "IsDeleted", "ModifyUser", "Name", "SurName" },
                values: new object[,]
                {
                    { 1L, 25, "SYSTEM", 2, new DateTime(2019, 11, 13, 22, 36, 48, 209, DateTimeKind.Local).AddTicks(5324), new DateTime(2019, 11, 13, 22, 36, 48, 210, DateTimeKind.Local).AddTicks(1085), false, "SYSTEM", "Yunus Emre", "Keskin" },
                    { 2L, 18, "SYSTEM", 0, new DateTime(2019, 11, 13, 22, 36, 48, 210, DateTimeKind.Local).AddTicks(1608), new DateTime(2019, 11, 13, 22, 36, 48, 210, DateTimeKind.Local).AddTicks(1615), false, "SYSTEM", "Yusuf Eren", "Keskin" },
                    { 3L, 45, "SYSTEM", 4, new DateTime(2019, 11, 13, 22, 36, 48, 210, DateTimeKind.Local).AddTicks(1619), new DateTime(2019, 11, 13, 22, 36, 48, 210, DateTimeKind.Local).AddTicks(1619), false, "SYSTEM", "Ayşe Hacer", "Keskin" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "ActivePassive", "CreateUser", "CustomerId", "DateCreated", "DateModified", "EmailAddress", "EmailType", "IsDefault", "IsDeleted", "ModifyUser" },
                values: new object[,]
                {
                    { 1L, 0, "SYSTEM", 1, new DateTime(2019, 11, 13, 22, 36, 48, 212, DateTimeKind.Local).AddTicks(298), new DateTime(2019, 11, 13, 22, 36, 48, 212, DateTimeKind.Local).AddTicks(300), "yemrekeskin@gmail.com", 1, true, false, "SYSTEM" },
                    { 2L, 0, "SYSTEM", 1, new DateTime(2019, 11, 13, 22, 36, 48, 212, DateTimeKind.Local).AddTicks(502), new DateTime(2019, 11, 13, 22, 36, 48, 212, DateTimeKind.Local).AddTicks(502), "info@yemrekeskin.com", 0, false, false, "SYSTEM" }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "ActivePassive", "AreaCode", "Country", "CreateUser", "CustomerId", "DateCreated", "DateModified", "IsDefault", "IsDeleted", "ModifyUser", "Number", "PhoneType" },
                values: new object[,]
                {
                    { 1L, 0, "212", "90", "SYSTEM", 1, new DateTime(2019, 11, 13, 22, 36, 48, 213, DateTimeKind.Local).AddTicks(1089), new DateTime(2019, 11, 13, 22, 36, 48, 213, DateTimeKind.Local).AddTicks(1104), true, false, "SYSTEM", "3786869", 0 },
                    { 2L, 0, "543", "90", "SYSTEM", 1, new DateTime(2019, 11, 13, 22, 36, 48, 213, DateTimeKind.Local).AddTicks(1158), new DateTime(2019, 11, 13, 22, 36, 48, 213, DateTimeKind.Local).AddTicks(1158), false, false, "SYSTEM", "5556677", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "Phones");
        }
    }
}