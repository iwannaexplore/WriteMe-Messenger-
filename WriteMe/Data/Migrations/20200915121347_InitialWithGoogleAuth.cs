using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WriteMe.Data.Migrations
{
    public partial class InitialWithGoogleAuth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LastActivityTime = table.Column<DateTime>(nullable: false),
                    ProfilePicture = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FriendsRelationships",
                columns: table => new
                {
                    FriendsRelationshipId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendsRelationships", x => x.FriendsRelationshipId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    RoleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FriendLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendsRelationshipId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FriendLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FriendLists_FriendsRelationships_FriendsRelationshipId",
                        column: x => x.FriendsRelationshipId,
                        principalTable: "FriendsRelationships",
                        principalColumn: "FriendsRelationshipId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    ChatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FriendListId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.ChatId);
                    table.ForeignKey(
                        name: "FK_Chats_FriendLists_FriendListId",
                        column: x => x.FriendListId,
                        principalTable: "FriendLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_FriendListUser_FriendLists_FriendListId",
                        column: x => x.FriendListId,
                        principalTable: "FriendLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FriendListUser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    SendingTime = table.Column<DateTime>(nullable: false),
                    ChatId = table.Column<int>(nullable: false),
                    RelatingUserId = table.Column<int>(nullable: false),
                    RelatedUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Chats_ChatId",
                        column: x => x.ChatId,
                        principalTable: "Chats",
                        principalColumn: "ChatId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_RelatedUserId",
                        column: x => x.RelatedUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Messages_AspNetUsers_RelatingUserId",
                        column: x => x.RelatingUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { 2, "fd93520a-ff1a-4522-b03a-18d7c60fc9a7", "Admin", "ADMIN" },
                    { 1, "eae0ad0b-87d4-4d9e-87a6-36ef72bece1e", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastActivityTime", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "ProfilePicture", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "688fc33f-c39f-42b3-8559-c952843c6108", "jylie@mail.com", true, new DateTime(2020, 9, 14, 15, 13, 46, 573, DateTimeKind.Local).AddTicks(5521), false, null, "JYLIE@GMAIL.COM", "JYLIE@MAIL.COM", null, null, false, "", null, false, "jylie@mail.com" },
                    { 2, 0, "bd4942c7-ba70-4b04-8c8b-5b7df6b643d2", "vika@mail.com", true, new DateTime(2020, 9, 14, 15, 13, 46, 575, DateTimeKind.Local).AddTicks(3012), false, null, "VIKA@GMAIL.COM", "VIKA@MAIL.COM", null, null, false, "", null, false, "vika@mail.com" }
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
                table: "FriendLists",
                columns: new[] { "Id", "FriendsRelationshipId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "ChatId", "FriendListId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "FriendListUser",
                columns: new[] { "FriendListId", "UserId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "FriendListUser",
                columns: new[] { "FriendListId", "UserId" },
                values: new object[] { 1, 2 });

            migrationBuilder.InsertData(
                table: "Messages",
                columns: new[] { "MessageId", "ChatId", "RelatedUserId", "RelatingUserId", "SendingTime", "Text" },
                values: new object[,]
                {
                    { 1, 1, 1, 2, new DateTime(2020, 9, 14, 22, 0, 0, 0, DateTimeKind.Local), "Hello, Vika" },
                    { 2, 1, 2, 1, new DateTime(2020, 9, 14, 22, 10, 0, 0, DateTimeKind.Local), "Hello, Julie" },
                    { 3, 1, 1, 2, new DateTime(2020, 9, 14, 22, 15, 0, 0, DateTimeKind.Local), "How are you?" },
                    { 4, 1, 2, 1, new DateTime(2020, 9, 14, 22, 20, 0, 0, DateTimeKind.Local), "Good" },
                    { 5, 1, 1, 2, new DateTime(2020, 9, 14, 22, 25, 0, 0, DateTimeKind.Local), "Me too" },
                    { 6, 1, 1, 2, new DateTime(2020, 9, 14, 22, 30, 0, 0, DateTimeKind.Local), "Flexim? Vika" },
                    { 7, 1, 1, 2, new DateTime(2020, 9, 13, 22, 0, 0, 0, DateTimeKind.Local), "Hello, Vika" },
                    { 8, 1, 2, 1, new DateTime(2020, 9, 13, 22, 10, 0, 0, DateTimeKind.Local), "Hello, Julie" },
                    { 9, 1, 1, 2, new DateTime(2020, 9, 13, 22, 15, 0, 0, DateTimeKind.Local), "How are you?" },
                    { 10, 1, 2, 1, new DateTime(2020, 9, 13, 22, 20, 0, 0, DateTimeKind.Local), "Good" },
                    { 11, 1, 1, 2, new DateTime(2020, 9, 13, 22, 25, 0, 0, DateTimeKind.Local), "Me too" },
                    { 12, 1, 1, 2, new DateTime(2020, 9, 13, 22, 30, 0, 0, DateTimeKind.Local), "Flexim? Vika" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_FriendListId",
                table: "Chats",
                column: "FriendListId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FriendLists_FriendsRelationshipId",
                table: "FriendLists",
                column: "FriendsRelationshipId");

            migrationBuilder.CreateIndex(
                name: "IX_FriendListUser_UserId",
                table: "FriendListUser",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatId",
                table: "Messages",
                column: "ChatId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RelatedUserId",
                table: "Messages",
                column: "RelatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_RelatingUserId",
                table: "Messages",
                column: "RelatingUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "FriendListUser");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "FriendLists");

            migrationBuilder.DropTable(
                name: "FriendsRelationships");
        }
    }
}
