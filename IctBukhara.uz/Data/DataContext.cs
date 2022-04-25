using IctBukhara.uz.Models;
using IctBukhara.uz.Models.PostModels;
using Microsoft.EntityFrameworkCore;

namespace IctBukhara.uz.Data
{
    using System;
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Mentor> Mentorlar { get; set; }

        public DbSet<Kurs> Kurslar { get; set; }

        public DbSet<SubscriptionKurs> KursgaYozilganlar { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasIndex(x => x.Login).IsUnique();
            modelBuilder.Entity<Mentor>().Property(x => x.Cv).HasConversion<string>();
            modelBuilder.Entity<SubscriptionKurs>().Property(d => d.Vaqt).HasDefaultValue(DateTime.Now);
                //.HasDefaultValueSql("GETDATE()");
            base.OnModelCreating(modelBuilder);
        }
    }
}
