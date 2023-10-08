using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Chat_Application.Model
{
    public partial class ContextChatDB : DbContext
    {
        public ContextChatDB()
            : base("name=Model1")
        {
        }

        public virtual DbSet<AddFriend> AddFriend { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Permission> Permission { get; set; }
        public virtual DbSet<Reason> Reason { get; set; }
        public virtual DbSet<ReportUser> ReportUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Login>()
                .HasMany(e => e.AddFriend)
                .WithRequired(e => e.Login)
                .HasForeignKey(e => e.User2)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Login>()
                .HasMany(e => e.AddFriend1)
                .WithRequired(e => e.Login1)
                .HasForeignKey(e => e.User1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Login>()
                .HasMany(e => e.ReportUser)
                .WithRequired(e => e.Login)
                .HasForeignKey(e => e.ReportUser1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Login>()
                .HasMany(e => e.ReportUser1)
                .WithRequired(e => e.Login1)
                .HasForeignKey(e => e.ReportedUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Reason>()
                .HasMany(e => e.ReportUser)
                .WithRequired(e => e.Reason)
                .WillCascadeOnDelete(false);
        }
    }
}
