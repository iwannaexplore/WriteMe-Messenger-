using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WriteMe.Data.Entities;
using WriteMe.Data.Extensions;

namespace WriteMe.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<FriendsList> FriendsLists { get; set; }

        public DbSet<FriendsRelationship> FriendsRelationships { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<FriendsList>()
                .HasOne(a => a.Chat)
                .WithOne(b => b.FriendsList)
                .HasForeignKey<Chat>(b => b.ChatId);

            modelBuilder.Seed();
        }
    }
}