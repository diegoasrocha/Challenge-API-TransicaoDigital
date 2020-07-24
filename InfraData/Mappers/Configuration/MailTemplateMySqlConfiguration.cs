using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InfraData.Mappers.Configuration
{
    public class MailTemplateMySqlConfiguration : IEntityTypeConfiguration<MailTemplate>
    {
        public void Configure(EntityTypeBuilder<MailTemplate> builder)
        {
            builder.ToTable("mail_template");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id)
                   .HasColumnName("id")
                   .ValueGeneratedNever()
                   .HasMaxLength(36)
                   .IsFixedLength(true);

            builder.Property(p => p.From)
                   .HasColumnName("from")
                   .HasMaxLength(50);

            builder.Property(p => p.Subject)
                   .HasColumnName("subject")
                   .HasMaxLength(100);

            builder.Property(p => p.Body)
                   .HasColumnName("body");
        }
    }
}
