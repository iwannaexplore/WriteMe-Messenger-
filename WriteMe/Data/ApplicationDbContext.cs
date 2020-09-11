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
        public DbSet<FriendList> FriendLists{ get; set; }
        
        public DbSet<FriendsRelationship> FriendsRelationships { get; set; }

        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.RelatingUser)
                .WithMany(t => t.RelatingMessages)
                .HasForeignKey(m => m.RelatingUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.RelatedUser)
                .WithMany(t => t.RelatedMessage)
                .HasForeignKey(m => m.RelatedUserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<FriendListUser>()
                .HasKey(bc => new { bc.FriendListId, bc.UserId });
            modelBuilder.Entity<FriendListUser>()
                .HasOne(bc => bc.FriendList)
                .WithMany(b => b.FriendListUsers)
                .HasForeignKey(bc => bc.FriendListId);
            modelBuilder.Entity<FriendListUser>()
                .HasOne(bc => bc.User)
                .WithMany(c => c.FriendListUsers)
                .HasForeignKey(bc => bc.UserId);

            modelBuilder.Seed();
        }
    }
}