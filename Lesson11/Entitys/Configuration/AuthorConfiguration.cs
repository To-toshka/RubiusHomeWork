using Lesson11.Entitys.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lesson11.Entitys.Configuration
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            //builder.ToTable("Authors");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Surname).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Patronymic).HasMaxLength(100);
            builder.Property(a => a.BirthDate).HasColumnType("date");
            builder.Property(a => a.AuthorDescription).HasColumnType("text");

            builder.HasMany(a => a.Books)           
                .WithOne(b => b.Author)
                .HasForeignKey(p => p.AuthorId);

            builder.HasOne(a => a.AuthorData)
                .WithOne(ad => ad.Author)
                .HasForeignKey<Author>(ad => ad.Id);
        }
    }
}
