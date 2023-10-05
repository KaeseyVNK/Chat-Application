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

        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<AddFriend> AddFriend { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
