using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using HueSite.Areas.Identity.Data;
//using HueSite.Migrations;
using HueSite.Data.Models;

namespace HueSite.Data
{
    public class DatabaseContext : IdentityDbContext<AppUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            /*modelBuilder.Entity<Note>()
                .HasOne<AppUser>(s => s.User)
                .WithMany(g => g.Notes)
                .HasForeignKey(s => s.UserId);*/
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseLazyLoadingProxies();
        }

        //DbSets
        public DbSet<Note> Notes { get; set; }
    }
}
