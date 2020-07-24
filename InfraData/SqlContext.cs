using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace InfraData
{
    public class SqlContext : DbContext
    {
        public SqlContext()
        {
        }

        public SqlContext(DbContextOptions<SqlContext> options) : base(options) { }

        public DbSet<Example> Example { get; set; }
        public DbSet<MailTemplate> MailTemplates { get; set; }
        public DbSet<MailTemplateItem> MailTemplateItems { get; set; }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("RegDate") != null))
            {

                if (entry.State == EntityState.Added)
                {
                    entry.Property("RegDate").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("RegDate").IsModified = false;
                }
            }

            return base.SaveChanges();

        }
    }
}
