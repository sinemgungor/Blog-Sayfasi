using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSayfasi_MVC_SinemGungor.Migrations
{
    /// <inheritdoc />
    public partial class initdb3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 14, 48, 710, DateTimeKind.Local).AddTicks(244));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 14, 48, 710, DateTimeKind.Local).AddTicks(260));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 14, 48, 710, DateTimeKind.Local).AddTicks(261));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 14, 48, 710, DateTimeKind.Local).AddTicks(262));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 14, 48, 710, DateTimeKind.Local).AddTicks(268));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 14, 48, 710, DateTimeKind.Local).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "0706944c-35a2-4a17-8724-48e08bf50234");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "b0ad2e3c-b3b4-440f-8608-765c16859903");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "ad6ba0fb-d1a3-4a0a-b9de-742d3db8326d", "Sinem", "Güngör", "AQAAAAIAAYagAAAAEJxofeTorHjeA0jk0svUk9/JVU+rLOJqGak0zzaKSdqBOdQBT1I50jfJE7fkoW7Ykw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "6a7444c9-30e3-4839-96c5-80f632d9ca2d", "Sena", "Malkoç", "AQAAAAIAAYagAAAAENZiUKBxU/vI0jsm/f3IQx+nk6ehRsSwwcHAWtT+jIrAYMArLTQjQ4thY2b0gPLYPw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName" },
                values: new object[] { "a12389d7-0e24-4146-baac-55d09c8f5ddf", "Sema", "Öztürkler" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 5, 56, 724, DateTimeKind.Local).AddTicks(4016));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 5, 56, 724, DateTimeKind.Local).AddTicks(4031));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 5, 56, 724, DateTimeKind.Local).AddTicks(4033));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 5, 56, 724, DateTimeKind.Local).AddTicks(4034));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 5, 56, 724, DateTimeKind.Local).AddTicks(4035));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 5, 56, 724, DateTimeKind.Local).AddTicks(4037));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f946bf68-0d58-4576-95f7-60659927e0df");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "5fa0d9fc-034e-4040-8d8e-15cb5c3c6b35");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "6e4b7ff0-1696-44d9-8702-6bac59372d73", null, null, "AQAAAAIAAYagAAAAEOs4HheDitw2WkvQiamar5RFxFE3qoBE9epjVe4fbUAWe8DecbQxtGAFlPupabYaYQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "PasswordHash" },
                values: new object[] { "5ef9e11b-8a0e-42a5-b1b2-2b723a0263ee", null, null, "AQAAAAIAAYagAAAAEJxDaT00QV5E5JuGTxcOwYs0qnhF7rON9kJ6gXafWkOP46FxaSnx2N21KmY8iAhnzA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName" },
                values: new object[] { "16aa75ae-66e8-4f56-a240-77ef0864fe6f", null, null });
        }
    }
}
