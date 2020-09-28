﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WriteMe.Data;

namespace WriteMe.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200928130422_ChangedUser")]
    partial class ChangedUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new
                        {
                            Id = 2,
                            ConcurrencyStamp = "3e7b5809-445c-4277-a41e-9381ba15240f",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = 1,
                            ConcurrencyStamp = "f4312d78-26ba-49b9-8bec-1bc17943fad3",
                            Name = "User",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 2,
                            RoleId = 2
                        },
                        new
                        {
                            UserId = 3,
                            RoleId = 1
                        },
                        new
                        {
                            UserId = 4,
                            RoleId = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("WriteMe.Data.Entities.Chat", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FriendListId")
                        .HasColumnType("int");

                    b.HasKey("ChatId");

                    b.HasIndex("FriendListId")
                        .IsUnique();

                    b.ToTable("Chats");

                    b.HasData(
                        new
                        {
                            ChatId = 1,
                            FriendListId = 1
                        },
                        new
                        {
                            ChatId = 2,
                            FriendListId = 2
                        },
                        new
                        {
                            ChatId = 3,
                            FriendListId = 3
                        },
                        new
                        {
                            ChatId = 4,
                            FriendListId = 4
                        });
                });

            modelBuilder.Entity("WriteMe.Data.Entities.FriendList", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FriendsRelationshipId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FriendsRelationshipId");

                    b.ToTable("FriendLists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FriendsRelationshipId = 1
                        },
                        new
                        {
                            Id = 2,
                            FriendsRelationshipId = 1
                        },
                        new
                        {
                            Id = 3,
                            FriendsRelationshipId = 1
                        },
                        new
                        {
                            Id = 4,
                            FriendsRelationshipId = 2
                        });
                });

            modelBuilder.Entity("WriteMe.Data.Entities.FriendListUser", b =>
                {
                    b.Property<int>("FriendListId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("FriendListId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("FriendListUsers");

                    b.HasData(
                        new
                        {
                            FriendListId = 1,
                            UserId = 1
                        },
                        new
                        {
                            FriendListId = 1,
                            UserId = 2
                        },
                        new
                        {
                            FriendListId = 2,
                            UserId = 3
                        },
                        new
                        {
                            FriendListId = 2,
                            UserId = 4
                        },
                        new
                        {
                            FriendListId = 3,
                            UserId = 3
                        },
                        new
                        {
                            FriendListId = 3,
                            UserId = 2
                        },
                        new
                        {
                            FriendListId = 4,
                            UserId = 3
                        },
                        new
                        {
                            FriendListId = 4,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("WriteMe.Data.Entities.FriendsRelationship", b =>
                {
                    b.Property<int>("FriendsRelationshipId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("FriendsRelationshipId");

                    b.ToTable("FriendsRelationships");

                    b.HasData(
                        new
                        {
                            FriendsRelationshipId = 1,
                            Name = "Friend"
                        },
                        new
                        {
                            FriendsRelationshipId = 2,
                            Name = "Blocked"
                        });
                });

            modelBuilder.Entity("WriteMe.Data.Entities.Message", b =>
                {
                    b.Property<int>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ChatId")
                        .HasColumnType("int");

                    b.Property<int>("RelatedUserId")
                        .HasColumnType("int");

                    b.Property<int>("RelatingUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SendingTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MessageId");

                    b.HasIndex("ChatId");

                    b.HasIndex("RelatedUserId");

                    b.HasIndex("RelatingUserId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            MessageId = 1,
                            ChatId = 1,
                            RelatedUserId = 1,
                            RelatingUserId = 2,
                            SendingTime = new DateTime(2020, 9, 27, 22, 0, 0, 0, DateTimeKind.Local),
                            Text = "Hello, Vika"
                        },
                        new
                        {
                            MessageId = 2,
                            ChatId = 1,
                            RelatedUserId = 2,
                            RelatingUserId = 1,
                            SendingTime = new DateTime(2020, 9, 27, 22, 10, 0, 0, DateTimeKind.Local),
                            Text = "Hello, Julie"
                        },
                        new
                        {
                            MessageId = 3,
                            ChatId = 2,
                            RelatedUserId = 3,
                            RelatingUserId = 4,
                            SendingTime = new DateTime(2020, 9, 27, 22, 0, 0, 0, DateTimeKind.Local),
                            Text = "Hello, dimon"
                        },
                        new
                        {
                            MessageId = 4,
                            ChatId = 2,
                            RelatedUserId = 4,
                            RelatingUserId = 3,
                            SendingTime = new DateTime(2020, 9, 27, 22, 10, 0, 0, DateTimeKind.Local),
                            Text = "Hello, admin"
                        },
                        new
                        {
                            MessageId = 5,
                            ChatId = 3,
                            RelatedUserId = 2,
                            RelatingUserId = 3,
                            SendingTime = new DateTime(2020, 9, 27, 22, 0, 0, 0, DateTimeKind.Local),
                            Text = "Hello, admin"
                        },
                        new
                        {
                            MessageId = 6,
                            ChatId = 3,
                            RelatedUserId = 3,
                            RelatingUserId = 2,
                            SendingTime = new DateTime(2020, 9, 27, 22, 10, 0, 0, DateTimeKind.Local),
                            Text = "Hello, Vika"
                        },
                        new
                        {
                            MessageId = 7,
                            ChatId = 4,
                            RelatedUserId = 1,
                            RelatingUserId = 3,
                            SendingTime = new DateTime(2020, 9, 27, 22, 0, 0, 0, DateTimeKind.Local),
                            Text = "Hello, admin"
                        },
                        new
                        {
                            MessageId = 8,
                            ChatId = 4,
                            RelatedUserId = 3,
                            RelatingUserId = 1,
                            SendingTime = new DateTime(2020, 9, 27, 22, 10, 0, 0, DateTimeKind.Local),
                            Text = "Hello, julie. Idi v ban"
                        });
                });

            modelBuilder.Entity("WriteMe.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "5e820e3f-4c07-4700-b488-fcf8fb5e59a5",
                            Email = "jylie@mail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "JYLIE@GMAIL.COM",
                            NormalizedUserName = "JYLIE@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEENOZCJ1R0VlJ5tsgHrcbN+UykPJ8cVM7XY+Db7XJrrWsH/MMSI7Jtb0nVtQ3rKf/Q==",
                            PhoneNumberConfirmed = false,
                            ProfilePicture = "304042a2-29bd-410c-8097-1744461b6c88_I2ff7ApwdMAM.jpg",
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "jylie@mail.com"
                        },
                        new
                        {
                            Id = 2,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a585c003-e24e-4400-85d6-cb7826f28e47",
                            Email = "vika@mail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "VIKA@GMAIL.COM",
                            NormalizedUserName = "VIKA@MAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAENP9fpRVdIBpsWMF2aAMaCgco9tiUwVqpQprWfgueF5zbjIepYgeWmxPqFE/5b+s6A==",
                            PhoneNumberConfirmed = false,
                            ProfilePicture = "304042a2-29bd-410c-8097-1744461b6c88_photo_2019-01-26_19-32-55.jpg",
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "vika@mail.com"
                        },
                        new
                        {
                            Id = 3,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a387ff6a-265a-495d-bd8e-8ed42deadb60",
                            Email = "admin@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "ADMIN@GMAIL.COM",
                            NormalizedUserName = "ADMIN@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAELe2AnIxu2U6Y75BVsaqdPt+11LnwDK9Gje2lXqLfmo5EqQlUX0W+k53NZgn6RTa2Q==",
                            PhoneNumberConfirmed = false,
                            ProfilePicture = "304042a2-29bd-410c-8097-1744461b6c88_photo_2020-03-28_22-57-55.jpg",
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "admin@gmail.com"
                        },
                        new
                        {
                            Id = 4,
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "09481aeb-ca82-4190-a6d9-4e77a0e09649",
                            Email = "iwannaexplore@gmail.com",
                            EmailConfirmed = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "IWANNAEXPLORE@GMAIL.COM",
                            NormalizedUserName = "IWANNAEXPLORE@GMAIL.COM",
                            PasswordHash = "AQAAAAEAACcQAAAAEFwEdyYEzO6RXhJiPJtbAK8O1b9pN4uWAw2EkwT/Fea56MAAR6BY1OCz8fTJeTzuKg==",
                            PhoneNumberConfirmed = false,
                            ProfilePicture = "304042a2-29bd-410c-8097-1744461b6c88_photo_2020-04-24_17-05-28.jpg",
                            SecurityStamp = "",
                            TwoFactorEnabled = false,
                            UserName = "iwannaexplore@gmail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<int>", b =>
                {
                    b.HasOne("WriteMe.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<int>", b =>
                {
                    b.HasOne("WriteMe.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<int>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<int>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WriteMe.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<int>", b =>
                {
                    b.HasOne("WriteMe.Data.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WriteMe.Data.Entities.Chat", b =>
                {
                    b.HasOne("WriteMe.Data.Entities.FriendList", "FriendList")
                        .WithOne("Chat")
                        .HasForeignKey("WriteMe.Data.Entities.Chat", "FriendListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WriteMe.Data.Entities.FriendList", b =>
                {
                    b.HasOne("WriteMe.Data.Entities.FriendsRelationship", "FriendsRelationship")
                        .WithMany()
                        .HasForeignKey("FriendsRelationshipId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WriteMe.Data.Entities.FriendListUser", b =>
                {
                    b.HasOne("WriteMe.Data.Entities.FriendList", "FriendList")
                        .WithMany("FriendListUsers")
                        .HasForeignKey("FriendListId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WriteMe.Data.Entities.User", "User")
                        .WithMany("FriendListUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WriteMe.Data.Entities.Message", b =>
                {
                    b.HasOne("WriteMe.Data.Entities.Chat", "Chat")
                        .WithMany("Messages")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WriteMe.Data.Entities.User", "RelatedUser")
                        .WithMany("RelatedMessage")
                        .HasForeignKey("RelatedUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("WriteMe.Data.Entities.User", "RelatingUser")
                        .WithMany("RelatingMessages")
                        .HasForeignKey("RelatingUserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
