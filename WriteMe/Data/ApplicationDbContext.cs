using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WriteMe.Data.Entities;

namespace WriteMe.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<FriendsList> FriendsLists { get; set; }

        public DbSet<FriendsRelationship> FriendsRelationships { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FriendsList>()
                .HasOne(m => m.RelatingUser)
                .WithMany(t => t.RelatingFriendsLists)
                .HasForeignKey(m => m.RelatingUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FriendsList>()
                .HasOne(m => m.RelatedUser)
                .WithMany(t => t.RelatedFriendsLists)
                .HasForeignKey(m => m.RelatedUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FriendsList>()
                .HasOne(a => a.Chat)
                .WithOne(b => b.FriendsList)
                .HasForeignKey<Chat>(b => b.ChatId);

        }
    }
}