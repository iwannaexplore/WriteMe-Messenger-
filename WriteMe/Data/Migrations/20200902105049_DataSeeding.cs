using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WriteMe.Data.Migrations
{
    public partial class DataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendsLists_AspNetUsers_RelatedUserId",
                table: "FriendsLists");

            migrationBuilder.DropForeignKey(
                name: "FK_FriendsLists_AspNetUsers_RelatingUserId",
                table: "FriendsLists");

            migrationBuilder.DropIndex(
                name: "IX_FriendsLists_RelatedUserId",
                table: "FriendsLists");

            migrationBuilder.DropIndex(
                name: "IX_FriendsLists_RelatingUserId",
                table: "FriendsLists");

            migrationBuilder.DropColumn(
                name: "RelatedUserId",
                table: "FriendsLists");

            migrationBuilder.DropColumn(
                name: "RelatingUserId",
                table: "FriendsLists");

            migrationBuilder.AddColumn<int>(
                name: "RelatingUserId",
                table: "Messages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "FriendsLists",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 2, "d7e5a447-fd33-4e07-a98e-6c7619ddcbcf", "Admin", "ADMIN" },
                    { 1, "ae013705-a274-4709-9df4-b107bd01f683", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastActivityTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "df138dc7-0312-4617-bf15-9db5837fe8c6", "jylie@mail.com", true, new DateTime(2020, 9, 1, 13, 50, 48, 836, DateTimeKind.Local).AddTicks(9325), false, null, "JYLIE@GMAIL.COM", "JYLIE@MAIL.COM", null, null, false, "", null, false, "jylie@mail.com" },
                    { 2, 0, "c0b1e227-0de7-4e23-a7ef-f31cd707ad25", "vika@mail.com", true, new DateTime(2020, 9, 1, 13, 50, 48, 839, DateTimeKind.Local).AddTicks(2240), false, null, "VIKA@GMAIL.COM", "VIKA@MAIL.COM", null, null, false, "", null, false, "vika@mail.com" }
                });

            migrationBuilder.InsertData(
                table: "FriendsLists",
                columns: new[] { "FriendsListId", "FriendRelationshipId", "FriendsRelationshipId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, null, null },
                    { 2, 1, null, null }
                });

            migrationBuilder.InsertData(
                table: "FriendsRelationships",
                columns: new[] { "FriendsRelationshipId", "Name" },
                values: new object[,]
                {
                    { 1, "Friend" },
                    { 2, "Blocked" }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "ChatId", "FriendListId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "ChatId", "FriendListId" },
                values: new object[] { 2, 2 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "ChatId", "RelatingUserId", "SendingTime", "Text" },
                values: new object[,]
                {
                    { 1, 1, 2, new DateTime(2020, 9, 1, 22, 0, 0, 0, DateTimeKind.Local), "Hello, Vika" },
                    { 2, 1, 1, new DateTime(2020, 9, 1, 22, 10, 0, 0, DateTimeKind.Local), "Hello, Julie" },
                    { 3, 1, 2, new DateTime(2020, 9, 1, 22, 15, 0, 0, DateTimeKind.Local), "How are you?" },
                    { 4, 1, 1, new DateTime(2020, 9, 1, 22, 20, 0, 0, DateTimeKind.Local), "Good" },
                    { 5, 1, 2, new DateTime(2020, 9, 1, 22, 25, 0, 0, DateTimeKind.Local), "Me too" },
                    { 6, 1, 2, new DateTime(2020, 9, 1, 22, 30, 0, 0, DateTimeKind.Local), "Flexim? Vika" },
                    { 7, 2, 2, new DateTime(2020, 8, 31, 22, 0, 0, 0, DateTimeKind.Local), "Hello, Vika" },
                    { 8, 2, 1, new DateTime(2020, 8, 31, 22, 10, 0, 0, DateTimeKind.Local), "Hello, Julie" },
                    { 9, 2, 2, new DateTime(2020, 8, 31, 22, 15, 0, 0, DateTimeKind.Local), "How are you?" },
                    { 10, 2, 1, new DateTime(2020, 8, 31, 22, 20, 0, 0, DateTimeKind.Local), "Good" },
                    { 11, 2, 2, new DateTime(2020, 8, 31, 22, 25, 0, 0, DateTimeKind.Local), "Me too" },
                    { 12, 2, 2, new DateTime(2020, 8, 31, 22, 30, 0, 0, DateTimeKind.Local), "Flexim? Vika" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RelatingUserId",
                table: "Messages",
                column: "RelatingUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendsLists_UserId",
                table: "FriendsLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendsLists_AspNetUsers_UserId",
                table: "FriendsLists",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_RelatingUserId",
                table: "Messages",
                column: "RelatingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FriendsLists_AspNetUsers_UserId",
                table: "FriendsLists");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_RelatingUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_RelatingUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_FriendsLists_UserId",
                table: "FriendsLists");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FriendsRelationships",
                keyColumn: "FriendsRelationshipId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FriendsRelationships",
                keyColumn: "FriendsRelationshipId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2);

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

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "ChatId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Chats",
                keyColumn: "ChatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FriendsLists",
                keyColumn: "FriendsListId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FriendsLists",
                keyColumn: "FriendsListId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "RelatingUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FriendsLists");

            migrationBuilder.AddColumn<int>(
                name: "RelatedUserId",
                table: "FriendsLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RelatingUserId",
                table: "FriendsLists",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FriendsLists_RelatedUserId",
                table: "FriendsLists",
                column: "RelatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendsLists_RelatingUserId",
                table: "FriendsLists",
                column: "RelatingUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendsLists_AspNetUsers_RelatedUserId",
                table: "FriendsLists",
                column: "RelatedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FriendsLists_AspNetUsers_RelatingUserId",
                table: "FriendsLists",
                column: "RelatingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
