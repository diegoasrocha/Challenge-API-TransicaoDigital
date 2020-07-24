using Domain.Entities; 
using InfraData.Mappers;
using Microsoft.EntityFrameworkCore; 

namespace InfraData.Context
{
    public partial class MySqlDbContext : DbContext
    {
        public MySqlDbContext()
        {
        }

        public MySqlDbContext(DbContextOptions<MySqlDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(Globals.DBConection);
            }
        }

        public virtual DbSet<Example> Example { get; set; }
        public virtual DbSet<MailTemplate> MailTemplates { get; set; }
        public virtual DbSet<MailTemplateItem> MailTemplateItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "1.0");
            modelBuilder.ApplyMapping();
        }
    }
}
