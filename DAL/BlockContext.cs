using CGBlcok.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CGBlcok.DAL
{
    public class BlockContext:DbContext
    {
        public BlockContext()
           : base(GetConnectionString()) { }

        private static string GetConnectionString()
        {
            return "SqlServerConnectionString";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>()
                .HasRequired(l => l.User)
                .WithMany(r=>r.Roles)
                .WillCascadeOnDelete(true);
        }

        public DbSet<User> Users { get; set; }//建立实体类与表的映射关系
        public DbSet<Role> Roles { get; set; }//建立实体类与表的映射关系

    }
}