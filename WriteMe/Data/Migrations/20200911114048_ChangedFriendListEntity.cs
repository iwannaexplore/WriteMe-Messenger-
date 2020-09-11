using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WriteMe.Data.Migrations
{
    public partial class ChangedFriendListEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_FriendsLists_ChatId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_RelatingUserId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "FriendsLists");

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
                table: "Chats",
                keyColumn: "ChatId",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "RelatedUserId",
                table: "Messages",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ChatId",
                table: "Chats",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "FriendRelationshipId",
                table: "Chats",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FriendsRelationshipId",
                table: "Chats",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(128)",
                oldMaxLength: 128);

            migrationBuilder.CreateTable(
                name: "FriendList",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendList", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FriendListUser",
                columns: table => new
                {
                    FriendListId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendListUser", x => new { x.FriendListId, x.UserId });
                    table.ForeignKey(
                        name: "FK_FriendListUser_FriendList_FriendListId",
                        column: x => x.FriendListId,
                        principalTable: "FriendList",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FriendListUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "132d7597-e9de-4338-8d3a-07c6f9b2e7f9");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d47e8eba-51d4-4328-818a-438acf0eff7c");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "LastActivityTime" },
                values: new object[] { "6ec495cd-c279-4ab3-91b9-08af68f89ede", new DateTime(2020, 9, 10, 14, 40, 47, 511, DateTimeKind.Local).AddTicks(9755) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "LastActivityTime" },
                values: new object[] { "8d20bf11-cf06-46b0-952f-0b95cee4f785", new DateTime(2020, 9, 10, 14, 40, 47, 513, DateTimeKind.Local).AddTicks(6029) });

            migrationBuilder.InsertData(
                table: "FriendList",
                column: "Id",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                columns: new[] { "RelatedUserId", "SendingTime" },
                values: new object[] { 1, new DateTime(2020, 9, 10, 22, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                columns: new[] { "RelatedUserId", "SendingTime" },
                values: new object[] { 2, new DateTime(2020, 9, 10, 22, 10, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                columns: new[] { "RelatedUserId", "SendingTime" },
                values: new object[] { 1, new DateTime(2020, 9, 10, 22, 15, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 4,
                columns: new[] { "RelatedUserId", "SendingTime" },
                values: new object[] { 2, new DateTime(2020, 9, 10, 22, 20, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 5,
                columns: new[] { "RelatedUserId", "SendingTime" },
                values: new object[] { 1, new DateTime(2020, 9, 10, 22, 25, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 6,
                columns: new[] { "RelatedUserId", "SendingTime" },
                values: new object[] { 1, new DateTime(2020, 9, 10, 22, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "ChatId", "RelatedUserId", "RelatingUserId", "SendingTime", "Text" },
                values: new object[,]
                {
                    { 10, 1, 2, 1, new DateTime(2020, 9, 9, 22, 20, 0, 0, DateTimeKind.Local), "Good" },
                    { 12, 1, 1, 2, new DateTime(2020, 9, 9, 22, 30, 0, 0, DateTimeKind.Local), "Flexim? Vika" },
                    { 11, 1, 1, 2, new DateTime(2020, 9, 9, 22, 25, 0, 0, DateTimeKind.Local), "Me too" },
                    { 7, 1, 1, 2, new DateTime(2020, 9, 9, 22, 0, 0, 0, DateTimeKind.Local), "Hello, Vika" },
                    { 9, 1, 1, 2, new DateTime(2020, 9, 9, 22, 15, 0, 0, DateTimeKind.Local), "How are you?" },
                    { 8, 1, 2, 1, new DateTime(2020, 9, 9, 22, 10, 0, 0, DateTimeKind.Local), "Hello, Julie" }
                });

            migrationBuilder.UpdateData(
                table: "Chats",
                keyColumn: "ChatId",
                keyValue: 1,
                column: "FriendRelationshipId",
                value: 1);

            migrationBuilder.InsertData(
                table: "FriendListUser",
                columns: new[] { "FriendListId", "UserId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "FriendListUser",
                columns: new[] { "FriendListId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RelatedUserId",
                table: "Messages",
                column: "RelatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_FriendListId",
                table: "Chats",
                column: "FriendListId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Chats_FriendsRelationshipId",
                table: "Chats",
                column: "FriendsRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendListUser_UserId",
                table: "FriendListUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_FriendList_FriendListId",
                table: "Chats",
                column: "FriendListId",
                principalTable: "FriendList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_FriendsRelationships_FriendsRelationshipId",
                table: "Chats",
                column: "FriendsRelationshipId",
                principalTable: "FriendsRelationships",
                principalColumn: "FriendsRelationshipId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_RelatedUserId",
                table: "Messages",
                column: "RelatedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_RelatingUserId",
                table: "Messages",
                column: "RelatingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Chats_FriendList_FriendListId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Chats_FriendsRelationships_FriendsRelationshipId",
                table: "Chats");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_RelatedUserId",
                table: "Messages");

            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_RelatingUserId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "FriendListUser");

            migrationBuilder.DropTable(
                name: "FriendList");

            migrationBuilder.DropIndex(
                name: "IX_Messages_RelatedUserId",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Chats_FriendListId",
                table: "Chats");

            migrationBuilder.DropIndex(
                name: "IX_Chats_FriendsRelationshipId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "RelatedUserId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "FriendRelationshipId",
                table: "Chats");

            migrationBuilder.DropColumn(
                name: "FriendsRelationshipId",
                table: "Chats");

            migrationBuilder.AlterColumn<int>(
                name: "ChatId",
                table: "Chats",
                type: "int",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserTokens",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "ProviderKey",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "LoginProvider",
                table: "AspNetUserLogins",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateTable(
                name: "FriendsLists",
                columns: table => new
                {
                    FriendsListId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendRelationshipId = table.Column<int>(type: "int", nullable: false),
                    FriendsRelationshipId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendsLists", x => x.FriendsListId);
                    table.ForeignKey(
                        name: "FK_FriendsLists_FriendsRelationships_FriendsRelationshipId",
                        column: x => x.FriendsRelationshipId,
                        principalTable: "FriendsRelationships",
                        principalColumn: "FriendsRelationshipId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FriendsLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "ConcurrencyStamp",
                value: "ae013705-a274-4709-9df4-b107bd01f683");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "ConcurrencyStamp",
                value: "d7e5a447-fd33-4e07-a98e-6c7619ddcbcf");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "LastActivityTime" },
                values: new object[] { "df138dc7-0312-4617-bf15-9db5837fe8c6", new DateTime(2020, 9, 1, 13, 50, 48, 836, DateTimeKind.Local).AddTicks(9325) });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "LastActivityTime" },
                values: new object[] { "c0b1e227-0de7-4e23-a7ef-f31cd707ad25", new DateTime(2020, 9, 1, 13, 50, 48, 839, DateTimeKind.Local).AddTicks(2240) });

            migrationBuilder.InsertData(
                table: "FriendsLists",
                columns: new[] { "FriendsListId", "FriendRelationshipId", "FriendsRelationshipId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, null, null },
                    { 2, 1, null, null }
                });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 1,
                column: "SendingTime",
                value: new DateTime(2020, 9, 1, 22, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 2,
                column: "SendingTime",
                value: new DateTime(2020, 9, 1, 22, 10, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 3,
                column: "SendingTime",
                value: new DateTime(2020, 9, 1, 22, 15, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 4,
                column: "SendingTime",
                value: new DateTime(2020, 9, 1, 22, 20, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 5,
                column: "SendingTime",
                value: new DateTime(2020, 9, 1, 22, 25, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 6,
                column: "SendingTime",
                value: new DateTime(2020, 9, 1, 22, 30, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "ChatId", "FriendListId" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 7,
                columns: new[] { "ChatId", "SendingTime" },
                values: new object[] { 2, new DateTime(2020, 8, 31, 22, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 8,
                columns: new[] { "ChatId", "SendingTime" },
                values: new object[] { 2, new DateTime(2020, 8, 31, 22, 10, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 9,
                columns: new[] { "ChatId", "SendingTime" },
                values: new object[] { 2, new DateTime(2020, 8, 31, 22, 15, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 10,
                columns: new[] { "ChatId", "SendingTime" },
                values: new object[] { 2, new DateTime(2020, 8, 31, 22, 20, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 11,
                columns: new[] { "ChatId", "SendingTime" },
                values: new object[] { 2, new DateTime(2020, 8, 31, 22, 25, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Messages",
                keyColumn: "MessageId",
                keyValue: 12,
                columns: new[] { "ChatId", "SendingTime" },
                values: new object[] { 2, new DateTime(2020, 8, 31, 22, 30, 0, 0, DateTimeKind.Local) });

            migrationBuilder.CreateIndex(
                name: "IX_FriendsLists_FriendsRelationshipId",
                table: "FriendsLists",
                column: "FriendsRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendsLists_UserId",
                table: "FriendsLists",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Chats_FriendsLists_ChatId",
                table: "Chats",
                column: "ChatId",
                principalTable: "FriendsLists",
                principalColumn: "FriendsListId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_RelatingUserId",
                table: "Messages",
                column: "RelatingUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
