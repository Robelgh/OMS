using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class v00101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("34f93433-2247-4c72-ab60-082484ff6d45"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("59d91785-6ff7-4bd8-a200-aeac7f604133"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("f8cf1593-eccd-4e01-8cda-eadd268b54aa"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 26, 8, 47, 29, 817, DateTimeKind.Utc).AddTicks(5703),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(4829));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 26, 8, 47, 29, 817, DateTimeKind.Utc).AddTicks(5543),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(4732));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 26, 8, 47, 29, 817, DateTimeKind.Utc).AddTicks(5265),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(4587));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 26, 8, 47, 29, 817, DateTimeKind.Utc).AddTicks(5158),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(4472));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 26, 8, 47, 29, 817, DateTimeKind.Utc).AddTicks(4921),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(4220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 26, 8, 47, 29, 817, DateTimeKind.Utc).AddTicks(3607),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(2764));

            migrationBuilder.AddColumn<int>(
                name: "Price",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "Email", "LastName", "Name", "Passworded", "PhoneNumber", "Role", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("59357f53-ef79-46d7-8aee-6c1c62c74a92"), "Robel", new DateTime(2024, 11, 26, 8, 47, 29, 375, DateTimeKind.Utc).AddTicks(8805), "jane.smith@example.com", "Smith", "Jane", "$2a$11$ltr.8RuZiq3IJ6.PGpTqL.32izaHhbT5zaN3GfIHEzntECoWsIO.y", "987-654-3210", "User", 1, null, new DateTime(2024, 11, 26, 8, 47, 29, 375, DateTimeKind.Utc).AddTicks(8815) },
                    { new Guid("a4810e82-a4d4-4a61-9474-258cbe3923bd"), "Robel", new DateTime(2024, 11, 26, 8, 47, 29, 200, DateTimeKind.Utc).AddTicks(4239), "john.doe@example.com", "Doe", "Robel", "$2a$11$AyhIuGlPXdyf/OHwtqvV5ugdkm.70ZcYsYN84TX6JVQUKjJ6DHOiS", "123-456-7890", "Admin", 1, null, new DateTime(2024, 11, 26, 8, 47, 29, 200, DateTimeKind.Utc).AddTicks(4242) },
                    { new Guid("f019602b-3057-4565-ab2e-e8c1c79bbb41"), "Robel", new DateTime(2024, 11, 26, 8, 47, 29, 602, DateTimeKind.Utc).AddTicks(9818), "robert.brown@example.com", "Brown", "Robert", "$2a$11$EU2bejTgia/rkineKnOQ.OHISANfT5rTJkJdKS72yISwnPOqWGEYi", "555-666-7777", "Manager", 1, null, new DateTime(2024, 11, 26, 8, 47, 29, 602, DateTimeKind.Utc).AddTicks(9822) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("59357f53-ef79-46d7-8aee-6c1c62c74a92"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("a4810e82-a4d4-4a61-9474-258cbe3923bd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "ID",
                keyValue: new Guid("f019602b-3057-4565-ab2e-e8c1c79bbb41"));

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Orders");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(4829),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 26, 8, 47, 29, 817, DateTimeKind.Utc).AddTicks(5703));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(4732),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 26, 8, 47, 29, 817, DateTimeKind.Utc).AddTicks(5543));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(4587),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 26, 8, 47, 29, 817, DateTimeKind.Utc).AddTicks(5265));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(4472),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 26, 8, 47, 29, 817, DateTimeKind.Utc).AddTicks(5158));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(4220),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 11, 26, 8, 47, 29, 817, DateTimeKind.Utc).AddTicks(4921));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 11, 26, 7, 34, 22, 277, DateTimeKind.Utc).AddTicks(2764),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 11, 26, 8, 47, 29, 817, DateTimeKind.Utc).AddTicks(3607));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "ID", "CreatedBy", "CreatedDate", "Email", "LastName", "Name", "Passworded", "PhoneNumber", "Role", "Status", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { new Guid("34f93433-2247-4c72-ab60-082484ff6d45"), "Robel", new DateTime(2024, 11, 26, 7, 34, 21, 761, DateTimeKind.Utc).AddTicks(4502), "john.doe@example.com", "Doe", "Robel", "$2a$11$oerTxSpksiazOW5MySwgk.klyY4QMrneZuAIH/4ehpasEmzXWhQGO", "123-456-7890", "Admin", 1, null, new DateTime(2024, 11, 26, 7, 34, 21, 761, DateTimeKind.Utc).AddTicks(4505) },
                    { new Guid("59d91785-6ff7-4bd8-a200-aeac7f604133"), "Robel", new DateTime(2024, 11, 26, 7, 34, 22, 105, DateTimeKind.Utc).AddTicks(4721), "robert.brown@example.com", "Brown", "Robert", "$2a$11$zL9o4H1r6jTpsMWR/NV9quIfHoj3Agej5pJYleidq9y2b07.da.X6", "555-666-7777", "Manager", 1, null, new DateTime(2024, 11, 26, 7, 34, 22, 105, DateTimeKind.Utc).AddTicks(4725) },
                    { new Guid("f8cf1593-eccd-4e01-8cda-eadd268b54aa"), "Robel", new DateTime(2024, 11, 26, 7, 34, 21, 933, DateTimeKind.Utc).AddTicks(4342), "jane.smith@example.com", "Smith", "Jane", "$2a$11$Gow/rkja9YsgR/AYVMPezelXIQXrjSHaaTfTxGI/fMsOArispgTM.", "987-654-3210", "User", 1, null, new DateTime(2024, 11, 26, 7, 34, 21, 933, DateTimeKind.Utc).AddTicks(4346) }
                });
        }
    }
}
