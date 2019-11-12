using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

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
                name: "AddressMaps",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 100, nullable: true),
                    ModifyUser = table.Column<string>(maxLength: 100, nullable: true),
                    AddressId = table.Column<long>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressMaps", x => x.Id);
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
                name: "EmailMaps",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 100, nullable: true),
                    ModifyUser = table.Column<string>(maxLength: 100, nullable: true),
                    EmailId = table.Column<long>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailMaps", x => x.Id);
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
                name: "PhoneMaps",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    CreateUser = table.Column<string>(maxLength: 100, nullable: true),
                    ModifyUser = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneId = table.Column<long>(nullable: false),
                    CustomerId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneMaps", x => x.Id);
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
                table: "AddressMaps",
                columns: new[] { "Id", "AddressId", "CreateUser", "CustomerId", "DateCreated", "DateModified", "IsDeleted", "ModifyUser" },
                values: new object[,]
                {
                    { 1L, 1L, "SYSTEM", 1L, new DateTime(2019, 11, 12, 23, 48, 10, 444, DateTimeKind.Local).AddTicks(3962), new DateTime(2019, 11, 12, 23, 48, 10, 444, DateTimeKind.Local).AddTicks(3964), false, "SYSTEM" },
                    { 2L, 2L, "SYSTEM", 1L, new DateTime(2019, 11, 12, 23, 48, 10, 444, DateTimeKind.Local).AddTicks(3978), new DateTime(2019, 11, 12, 23, 48, 10, 444, DateTimeKind.Local).AddTicks(3979), false, "SYSTEM" }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "ActivePassive", "AddressNote", "AddressType", "BuildingName", "BuildingNumber", "Country", "County", "CreateUser", "DateCreated", "DateModified", "FlatNumber", "IsDefault", "IsDeleted", "ModifyUser", "PostCode", "Street", "Town" },
                values: new object[,]
                {
                    { 1L, 0, "Dont post any letter", 0, "MaviBalina Apt.", "123", "Turkey", "Istanbul", "SYSTEM", new DateTime(2019, 11, 12, 23, 48, 10, 444, DateTimeKind.Local).AddTicks(2879), new DateTime(2019, 11, 12, 23, 48, 10, 444, DateTimeKind.Local).AddTicks(2883), "52", true, false, "SYSTEM", "34300", "Yenisehir", "Pendik" },
                    { 2L, 1, "", 1, "Teknopark Istanbul", "321", "Turkey", "Istanbul", "SYSTEM", new DateTime(2019, 11, 12, 23, 48, 10, 444, DateTimeKind.Local).AddTicks(2926), new DateTime(2019, 11, 12, 23, 48, 10, 444, DateTimeKind.Local).AddTicks(2926), "3", false, false, "SYSTEM", "34600", "Yenisehir", "Pendik" }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Age", "CreateUser", "CustomerRank", "DateCreated", "DateModified", "IsDeleted", "ModifyUser", "Name", "SurName" },
                values: new object[,]
                {
                    { 1L, 25, "SYSTEM", 2, new DateTime(2019, 11, 12, 23, 48, 10, 439, DateTimeKind.Local).AddTicks(9048), new DateTime(2019, 11, 12, 23, 48, 10, 442, DateTimeKind.Local).AddTicks(7397), false, "SYSTEM", "Yunus Emre", "Keskin" },
                    { 2L, 18, "SYSTEM", 0, new DateTime(2019, 11, 12, 23, 48, 10, 443, DateTimeKind.Local).AddTicks(418), new DateTime(2019, 11, 12, 23, 48, 10, 443, DateTimeKind.Local).AddTicks(427), false, "SYSTEM", "Yusuf Eren", "Keskin" },
                    { 3L, 45, "SYSTEM", 4, new DateTime(2019, 11, 12, 23, 48, 10, 443, DateTimeKind.Local).AddTicks(432), new DateTime(2019, 11, 12, 23, 48, 10, 443, DateTimeKind.Local).AddTicks(433), false, "SYSTEM", "Ayşe Hacer", "Keskin" }
                });

            migrationBuilder.InsertData(
                table: "EmailMaps",
                columns: new[] { "Id", "CreateUser", "CustomerId", "DateCreated", "DateModified", "EmailId", "IsDeleted", "ModifyUser" },
                values: new object[,]
                {
                    { 1L, "SYSTEM", 1L, new DateTime(2019, 11, 12, 23, 48, 10, 445, DateTimeKind.Local).AddTicks(4716), new DateTime(2019, 11, 12, 23, 48, 10, 445, DateTimeKind.Local).AddTicks(4717), 1L, false, "SYSTEM" },
                    { 2L, "SYSTEM", 1L, new DateTime(2019, 11, 12, 23, 48, 10, 445, DateTimeKind.Local).AddTicks(4732), new DateTime(2019, 11, 12, 23, 48, 10, 445, DateTimeKind.Local).AddTicks(4732), 2L, false, "SYSTEM" }
                });

            migrationBuilder.InsertData(
                table: "Emails",
                columns: new[] { "Id", "ActivePassive", "CreateUser", "DateCreated", "DateModified", "EmailAddress", "EmailType", "IsDefault", "IsDeleted", "ModifyUser" },
                values: new object[,]
                {
                    { 1L, 0, "SYSTEM", new DateTime(2019, 11, 12, 23, 48, 10, 445, DateTimeKind.Local).AddTicks(3679), new DateTime(2019, 11, 12, 23, 48, 10, 445, DateTimeKind.Local).AddTicks(3682), "yemrekeskin@gmail.com", 1, true, false, "SYSTEM" },
                    { 2L, 0, "SYSTEM", new DateTime(2019, 11, 12, 23, 48, 10, 445, DateTimeKind.Local).AddTicks(3704), new DateTime(2019, 11, 12, 23, 48, 10, 445, DateTimeKind.Local).AddTicks(3704), "info@yemrekeskin.com", 0, false, false, "SYSTEM" }
                });

            migrationBuilder.InsertData(
                table: "PhoneMaps",
                columns: new[] { "Id", "CreateUser", "CustomerId", "DateCreated", "DateModified", "IsDeleted", "ModifyUser", "PhoneId" },
                values: new object[,]
                {
                    { 1L, "SYSTEM", 1L, new DateTime(2019, 11, 12, 23, 48, 10, 446, DateTimeKind.Local).AddTicks(6330), new DateTime(2019, 11, 12, 23, 48, 10, 446, DateTimeKind.Local).AddTicks(6331), false, "SYSTEM", 1L },
                    { 2L, "SYSTEM", 1L, new DateTime(2019, 11, 12, 23, 48, 10, 446, DateTimeKind.Local).AddTicks(6345), new DateTime(2019, 11, 12, 23, 48, 10, 446, DateTimeKind.Local).AddTicks(6345), false, "SYSTEM", 1L }
                });

            migrationBuilder.InsertData(
                table: "Phones",
                columns: new[] { "Id", "ActivePassive", "AreaCode", "Country", "CreateUser", "DateCreated", "DateModified", "IsDefault", "IsDeleted", "ModifyUser", "Number", "PhoneType" },
                values: new object[,]
                {
                    { 1L, 0, "212", "90", "SYSTEM", new DateTime(2019, 11, 12, 23, 48, 10, 446, DateTimeKind.Local).AddTicks(5121), new DateTime(2019, 11, 12, 23, 48, 10, 446, DateTimeKind.Local).AddTicks(5123), true, false, "SYSTEM", "3786869", 0 },
                    { 2L, 0, "543", "90", "SYSTEM", new DateTime(2019, 11, 12, 23, 48, 10, 446, DateTimeKind.Local).AddTicks(5148), new DateTime(2019, 11, 12, 23, 48, 10, 446, DateTimeKind.Local).AddTicks(5149), false, false, "SYSTEM", "5556677", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "AddressMaps");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "EmailMaps");

            migrationBuilder.DropTable(
                name: "Emails");

            migrationBuilder.DropTable(
                name: "PhoneMaps");

            migrationBuilder.DropTable(
                name: "Phones");
        }
    }
}
