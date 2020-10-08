using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WriteMe.Data.Migrations
{
    public partial class AddedImagesMessages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsImage",
                table: "Messages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsVideo",
                table: "Messages",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "81c68196-fc65-480b-83a5-f3ecbf3fcb00");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "a9ae4eb3-b118-4dbc-9207-c1486f4f85c7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "93072fee-fd15-49bf-bcb6-5a50976455a3", "AQAAAAEAACcQAAAAEMX354zwZC5PhmyVdWxlp5EbdsJJv8Tsi3ucQR8G6uHWvGSS+xSOC+Tf3RIM1Gb1fQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "47e2dadf-a8f0-4828-9147-3e24039dd25e", "AQAAAAEAACcQAAAAELP7/6X9RFIcFZmcJLJTsXJ1JhYbuydzXqgnsDlf8tASIInDprx92wKqQNnB1EIVkA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8343de29-b637-4276-81ed-c94b0a76988a", "AQAAAAEAACcQAAAAELo5iERV+aHawiTwAiLWDlc2LiMYfvpcxNdGiFmegohMVSGp3tkQq+AVKn3xwuj6kw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "2f9137ea-e43e-4862-b34d-621e62a52c5b", "AQAAAAEAACcQAAAAECJSqFue0LqR0UGVUv0Ah/B4OEMAnkQN+sITHHYzHMmdywck+/CYohZ6NIz7C/JWyg==" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "SendingTime",
                value: new DateTime(2020, 10, 5, 22, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "SendingTime",
                value: new DateTime(2020, 10, 5, 22, 10, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "SendingTime",
                value: new DateTime(2020, 10, 5, 22, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 4,
                column: "SendingTime",
                value: new DateTime(2020, 10, 5, 22, 10, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 5,
                column: "SendingTime",
                value: new DateTime(2020, 10, 5, 22, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 6,
                column: "SendingTime",
                value: new DateTime(2020, 10, 5, 22, 10, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 7,
                column: "SendingTime",
                value: new DateTime(2020, 10, 5, 22, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 8,
                column: "SendingTime",
                value: new DateTime(2020, 10, 5, 22, 10, 0, 0, DateTimeKind.Local));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsImage",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "IsVideo",
                table: "Messages");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "f4312d78-26ba-49b9-8bec-1bc17943fad3");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "3e7b5809-445c-4277-a41e-9381ba15240f");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "5e820e3f-4c07-4700-b488-fcf8fb5e59a5", "AQAAAAEAACcQAAAAEENOZCJ1R0VlJ5tsgHrcbN+UykPJ8cVM7XY+Db7XJrrWsH/MMSI7Jtb0nVtQ3rKf/Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a585c003-e24e-4400-85d6-cb7826f28e47", "AQAAAAEAACcQAAAAENP9fpRVdIBpsWMF2aAMaCgco9tiUwVqpQprWfgueF5zbjIepYgeWmxPqFE/5b+s6A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a387ff6a-265a-495d-bd8e-8ed42deadb60", "AQAAAAEAACcQAAAAELe2AnIxu2U6Y75BVsaqdPt+11LnwDK9Gje2lXqLfmo5EqQlUX0W+k53NZgn6RTa2Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "09481aeb-ca82-4190-a6d9-4e77a0e09649", "AQAAAAEAACcQAAAAEFwEdyYEzO6RXhJiPJtbAK8O1b9pN4uWAw2EkwT/Fea56MAAR6BY1OCz8fTJeTzuKg==" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "SendingTime",
                value: new DateTime(2020, 9, 27, 22, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "SendingTime",
                value: new DateTime(2020, 9, 27, 22, 10, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "SendingTime",
                value: new DateTime(2020, 9, 27, 22, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 4,
                column: "SendingTime",
                value: new DateTime(2020, 9, 27, 22, 10, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 5,
                column: "SendingTime",
                value: new DateTime(2020, 9, 27, 22, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 6,
                column: "SendingTime",
                value: new DateTime(2020, 9, 27, 22, 10, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 7,
                column: "SendingTime",
                value: new DateTime(2020, 9, 27, 22, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 8,
                column: "SendingTime",
                value: new DateTime(2020, 9, 27, 22, 10, 0, 0, DateTimeKind.Local));
        }
    }
}
