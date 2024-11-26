using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v00100 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductTypeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(4472)),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(4587))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Passworded = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(4732)),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(4829))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DeliveryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OrderStatus = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(2764)),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(4220))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "Email", "LastName", "Name", "Passworded", "PhoneNumber", "Role", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("34f93433-2247-4c72-ab60-082484ff6d45"), "Robel", new DateTime(2024, 11, 26, 7, 34, 21, 761, DateTimeKind.Utc).AddTicks(4502), "john.doe@example.com", "Doe", "Robel", "$2a$11$oerTxSpksiazOW5MySwgk.klyY4QMrneZuAIH/4ehpasEmzXWhQGO", "123-456-7890", "Admin", 1, null, new DateTime(2024, 11, 26, 7, 34, 21, 761, DateTimeKind.Utc).AddTicks(4505) },
                    { new Guid("59d91785-6ff7-4bd8-a200-aeac7f604133"), "Robel", new DateTime(2024, 11, 26, 7, 34, 22, 105, DateTimeKind.Utc).AddTicks(4721), "robert.brown@example.com", "Brown", "Robert", "$2a$11$zL9o4H1r6jTpsMWR/NV9quIfHoj3Agej5pJYleidq9y2b07.da.X6", "555-666-7777", "Manager", 1, null, new DateTime(2024, 11, 26, 7, 34, 22, 105, DateTimeKind.Utc).AddTicks(4725) },
                    { new Guid("f8cf1593-eccd-4e01-8cda-eadd268b54aa"), "Robel", new DateTime(2024, 11, 26, 7, 34, 21, 933, DateTimeKind.Utc).AddTicks(4342), "jane.smith@example.com", "Smith", "Jane", "$2a$11$Gow/rkja9YsgR/AYVMPezelXIQXrjSHaaTfTxGI/fMsOArispgTM.", "987-654-3210", "User", 1, null, new DateTime(2024, 11, 26, 7, 34, 21, 933, DateTimeKind.Utc).AddTicks(4346) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
