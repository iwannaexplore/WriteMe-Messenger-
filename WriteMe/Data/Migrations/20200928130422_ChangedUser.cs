using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WriteMe.Data.Migrations
{
    public partial class ChangedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendListUser_FriendLists_FriendListId",
                table: "FriendListUser");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendListUser_AspNetUsers_UserId",
                table: "FriendListUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendListUser",
                table: "FriendListUser");

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "LastActivityTime",
                table: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "FriendListUser",
                newName: "FriendListUsers");

            migrationBuilder.RenameIndex(
                name: "IX_FriendListUser_UserId",
                table: "FriendListUsers",
                newName: "IX_FriendListUsers_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendListUsers",
                table: "FriendListUsers",
                columns: new[] { "FriendListId", "UserId" });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { 1, 2 },
                    { 2, 2 }
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "5e820e3f-4c07-4700-b488-fcf8fb5e59a5", "AQAAAAEAACcQAAAAEENOZCJ1R0VlJ5tsgHrcbN+UykPJ8cVM7XY+Db7XJrrWsH/MMSI7Jtb0nVtQ3rKf/Q==", "304042a2-29bd-410c-8097-1744461b6c88_I2ff7ApwdMAM.jpg", "" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "a585c003-e24e-4400-85d6-cb7826f28e47", "AQAAAAEAACcQAAAAENP9fpRVdIBpsWMF2aAMaCgco9tiUwVqpQprWfgueF5zbjIepYgeWmxPqFE/5b+s6A==", "304042a2-29bd-410c-8097-1744461b6c88_photo_2019-01-26_19-32-55.jpg", "" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 3, 0, "a387ff6a-265a-495d-bd8e-8ed42deadb60", "admin@gmail.com", true, false, null, "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAELe2AnIxu2U6Y75BVsaqdPt+11LnwDK9Gje2lXqLfmo5EqQlUX0W+k53NZgn6RTa2Q==", null, false, "304042a2-29bd-410c-8097-1744461b6c88_photo_2020-03-28_22-57-55.jpg", "", false, "admin@gmail.com" },
                    { 4, 0, "09481aeb-ca82-4190-a6d9-4e77a0e09649", "iwannaexplore@gmail.com", true, false, null, "IWANNAEXPLORE@GMAIL.COM", "IWANNAEXPLORE@GMAIL.COM", "AQAAAAEAACcQAAAAEFwEdyYEzO6RXhJiPJtbAK8O1b9pN4uWAw2EkwT/Fea56MAAR6BY1OCz8fTJeTzuKg==", null, false, "304042a2-29bd-410c-8097-1744461b6c88_photo_2020-04-24_17-05-28.jpg", "", false, "iwannaexplore@gmail.com" }
                });

            migrationBuilder.InsertData(
                table: "FriendLists",
                columns: new[] { "Id", "FriendsRelationshipId" },
                values: new object[,]
                {
                    { 2, 1 },
                    { 3, 1 },
                    { 4, 2 }
                });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[,]
                {
                    { 3, 1 },
                    { 4, 2 }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "ChatId", "FriendListId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 3, 3 },
                    { 4, 4 }
                });

            migrationBuilder.InsertData(
                table: "FriendListUsers",
                columns: new[] { "FriendListId", "UserId" },
                values: new object[,]
                {
                    { 3, 2 },
                    { 4, 1 },
                    { 2, 3 },
                    { 3, 3 },
                    { 4, 3 },
                    { 2, 4 }
                });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                columns: new[] { "ChatId", "RelatedUserId", "RelatingUserId", "SendingTime", "Text" },
                values: new object[] { 2, 3, 4, new DateTime(2020, 9, 27, 22, 0, 0, 0, DateTimeKind.Local), "Hello, dimon" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 4,
                columns: new[] { "ChatId", "RelatedUserId", "RelatingUserId", "SendingTime", "Text" },
                values: new object[] { 2, 4, 3, new DateTime(2020, 9, 27, 22, 10, 0, 0, DateTimeKind.Local), "Hello, admin" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 5,
                columns: new[] { "ChatId", "RelatedUserId", "RelatingUserId", "SendingTime", "Text" },
                values: new object[] { 3, 2, 3, new DateTime(2020, 9, 27, 22, 0, 0, 0, DateTimeKind.Local), "Hello, admin" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 6,
                columns: new[] { "ChatId", "RelatedUserId", "SendingTime", "Text" },
                values: new object[] { 3, 3, new DateTime(2020, 9, 27, 22, 10, 0, 0, DateTimeKind.Local), "Hello, Vika" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 7,
                columns: new[] { "ChatId", "RelatingUserId", "SendingTime", "Text" },
                values: new object[] { 4, 3, new DateTime(2020, 9, 27, 22, 0, 0, 0, DateTimeKind.Local), "Hello, admin" });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 8,
                columns: new[] { "ChatId", "RelatedUserId", "SendingTime", "Text" },
                values: new object[] { 4, 3, new DateTime(2020, 9, 27, 22, 10, 0, 0, DateTimeKind.Local), "Hello, julie. Idi v ban" });

            migrationBuilder.AddForeignKey(
                name: "FK_FriendListUsers_FriendLists_FriendListId",
                table: "FriendListUsers",
                column: "FriendListId",
                principalTable: "FriendLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendListUsers_AspNetUsers_UserId",
                table: "FriendListUsers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendListUsers_FriendLists_FriendListId",
                table: "FriendListUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendListUsers_AspNetUsers_UserId",
                table: "FriendListUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FriendListUsers",
                table: "FriendListUsers");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { 4, 2 });

            migrationBuilder.DeleteData(
                table: "FriendListUsers",
                keyColumns: new[] { "FriendListId", "UserId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "FriendListUsers",
                keyColumns: new[] { "FriendListId", "UserId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "FriendListUsers",
                keyColumns: new[] { "FriendListId", "UserId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "FriendListUsers",
                keyColumns: new[] { "FriendListId", "UserId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "FriendListUsers",
                keyColumns: new[] { "FriendListId", "UserId" },
                keyValues: new object[] { 4, 1 });

            migrationBuilder.DeleteData(
                table: "FriendListUsers",
                keyColumns: new[] { "FriendListId", "UserId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "ChatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "ChatId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "ChatId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FriendLists",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FriendLists",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FriendLists",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameTable(
                name: "FriendListUsers",
                newName: "FriendListUser");

            migrationBuilder.RenameIndex(
                name: "IX_FriendListUsers_UserId",
                table: "FriendListUser",
                newName: "IX_FriendListUser_UserId");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastActivityTime",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_FriendListUser",
                table: "FriendListUser",
                columns: new[] { "FriendListId", "UserId" });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "eae0ad0b-87d4-4d9e-87a6-36ef72bece1e");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "fd93520a-ff1a-4522-b03a-18d7c60fc9a7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "LastActivityTime", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "688fc33f-c39f-42b3-8559-c952843c6108", new DateTime(2020, 9, 14, 15, 13, 46, 573, DateTimeKind.Local).AddTicks(5521), null, "", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "LastActivityTime", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "bd4942c7-ba70-4b04-8c8b-5b7df6b643d2", new DateTime(2020, 9, 14, 15, 13, 46, 575, DateTimeKind.Local).AddTicks(3012), null, "", null });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "SendingTime",
                value: new DateTime(2020, 9, 14, 22, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "SendingTime",
                value: new DateTime(2020, 9, 14, 22, 10, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "ChatId", "RelatedUserId", "RelatingUserId", "SendingTime", "Text" },
                values: new object[,]
                {
                    { 6, 1, 1, 2, new DateTime(2020, 9, 14, 22, 30, 0, 0, DateTimeKind.Local), "Flexim? Vika" },
                    { 5, 1, 1, 2, new DateTime(2020, 9, 14, 22, 25, 0, 0, DateTimeKind.Local), "Me too" },
                    { 4, 1, 2, 1, new DateTime(2020, 9, 14, 22, 20, 0, 0, DateTimeKind.Local), "Good" },
                    { 3, 1, 1, 2, new DateTime(2020, 9, 14, 22, 15, 0, 0, DateTimeKind.Local), "How are you?" },
                    { 9, 1, 1, 2, new DateTime(2020, 9, 13, 22, 15, 0, 0, DateTimeKind.Local), "How are you?" },
                    { 10, 1, 2, 1, new DateTime(2020, 9, 13, 22, 20, 0, 0, DateTimeKind.Local), "Good" },
                    { 11, 1, 1, 2, new DateTime(2020, 9, 13, 22, 25, 0, 0, DateTimeKind.Local), "Me too" },
                    { 12, 1, 1, 2, new DateTime(2020, 9, 13, 22, 30, 0, 0, DateTimeKind.Local), "Flexim? Vika" },
                    { 8, 1, 2, 1, new DateTime(2020, 9, 13, 22, 10, 0, 0, DateTimeKind.Local), "Hello, Julie" },
                    { 7, 1, 1, 2, new DateTime(2020, 9, 13, 22, 0, 0, 0, DateTimeKind.Local), "Hello, Vika" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_FriendListUser_FriendLists_FriendListId",
                table: "FriendListUser",
                column: "FriendListId",
                principalTable: "FriendLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FriendListUser_AspNetUsers_UserId",
                table: "FriendListUser",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
