using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Chat_Application.Model
{
    public partial class ContextChatDB : DbContext
    {
        public ContextChatDB()
            : base("name=ContextChatDB")
        {
        }

        public virtual DbSet<AddFriend> AddFriends { get; set; }
        public virtual DbSet<Login> Logins { get; set; }
        public virtual DbSet<Messenger> Messengers { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Reason> Reasons { get; set; }
        public virtual DbSet<ReportUser> ReportUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .HasMany(e => e.AddFriends)
                .WithRequired(e => e.Login)
                .HasForeignKey(e => e.User2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Login>()
                .HasMany(e => e.AddFriends1)
                .WithRequired(e => e.Login1)
                .HasForeignKey(e => e.User1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Login>()
                .HasMany(e => e.ReportUsers)
                .WithRequired(e => e.Login)
                .HasForeignKey(e => e.ReportUser1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Login>()
                .HasMany(e => e.ReportUsers1)
                .WithRequired(e => e.Login1)
                .HasForeignKey(e => e.ReportedUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reason>()
                .HasMany(e => e.ReportUsers)
                .WithRequired(e => e.Reason)
                .WillCascadeOnDelete(false);
        }
    }
}
