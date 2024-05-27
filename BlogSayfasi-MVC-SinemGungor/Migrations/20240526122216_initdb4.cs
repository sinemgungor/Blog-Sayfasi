using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogSayfasi_MVC_SinemGungor.Migrations
{
    /// <inheritdoc />
    public partial class initdb4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 22, 15, 744, DateTimeKind.Local).AddTicks(6590));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 22, 15, 744, DateTimeKind.Local).AddTicks(6605));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 22, 15, 744, DateTimeKind.Local).AddTicks(6607));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 22, 15, 744, DateTimeKind.Local).AddTicks(6608));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 22, 15, 744, DateTimeKind.Local).AddTicks(6609));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6,
                column: "CreatedTime",
                value: new DateTime(2024, 5, 26, 15, 22, 15, 744, DateTimeKind.Local).AddTicks(6610));

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "683196b5-7e09-466a-9bd2-c1fb7725334c");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d7b2aa2e-8a4b-4422-9e77-6b5cd6cac634");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePictureUrl" },
                values: new object[] { "8ca36c29-34dc-4553-9ca6-736ecd6ef1e2", "AQAAAAIAAYagAAAAECyKBLsPCdYumU1nh2QkQJYtEZm771B9KHxyjNtnI7wIJr+fu7umgyU0EbNwQWT64A==", "/pictures/pp1.jpg" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePictureUrl" },
                values: new object[] { "5ace3f85-97fc-45d3-ab59-0e8352e8f43f", "AQAAAAIAAYagAAAAEFBLKIFMHjP1mARPq90C7MeiRfeIOMudsXmW75BHOxEDxl7XCX5KhTX405EvGWUEvw==", "/pictures/pp2.jpg" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "ProfilePictureUrl" },
                values: new object[] { "5d7a51d1-a02e-4619-bd76-c42bdeee193e", "/pictures/pp3.jpg" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePictureUrl" },
                values: new object[] { "ad6ba0fb-d1a3-4a0a-b9de-742d3db8326d", "AQAAAAIAAYagAAAAEJxofeTorHjeA0jk0svUk9/JVU+rLOJqGak0zzaKSdqBOdQBT1I50jfJE7fkoW7Ykw==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePictureUrl" },
                values: new object[] { "6a7444c9-30e3-4839-96c5-80f632d9ca2d", "AQAAAAIAAYagAAAAENZiUKBxU/vI0jsm/f3IQx+nk6ehRsSwwcHAWtT+jIrAYMArLTQjQ4thY2b0gPLYPw==", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "ProfilePictureUrl" },
                values: new object[] { "a12389d7-0e24-4146-baac-55d09c8f5ddf", null });
        }
    }
}
