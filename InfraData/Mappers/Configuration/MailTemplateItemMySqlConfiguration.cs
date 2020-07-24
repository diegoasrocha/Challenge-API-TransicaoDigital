using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData.Mappers.Configuration
{
    public class MailTemplateItemMySqlConfiguration : IEntityTypeConfiguration<MailTemplateItem>
    {
        public void Configure(EntityTypeBuilder<MailTemplateItem> builder)
        {
            builder.ToTable("mail_template_item");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasColumnName("id")
                   .ValueGeneratedNever()
                   .HasMaxLength(36)
                   .IsFixedLength(true);

            builder.Property(p => p.Key)
                   .HasColumnName("key")
                   .HasMaxLength(50);

            builder.Property(p => p.Value)
                   .HasColumnName("value")
                   .HasMaxLength(100);

            builder.Property(p => p.MailTemplateId)                    
                   .HasColumnName("mail_template_id")
                   .HasMaxLength(36)
                   .IsFixedLength(true);

            builder.HasOne(p => p.MailTemplate).WithMany(p => p.MailTemplateItems);
        }
    }
}
