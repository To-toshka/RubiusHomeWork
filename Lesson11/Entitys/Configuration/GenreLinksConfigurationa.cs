using Lesson11.Entitys.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lesson11.Entitys.Configuration
{
    public class GenreLinksConfigurationa : IEntityTypeConfiguration<GenreLink>
    {
        public void Configure(EntityTypeBuilder<GenreLink> builder)
        {
            //builder.ToTable("GenreLinks");
            builder.HasKey(l => l.Id);
            builder.Property(l => l.BookId).IsRequired().HasColumnType("uuid");
            builder.Property(l => l.GenreId).IsRequired().HasColumnType("uuid");

            builder.HasOne(l => l.Book)
                .WithMany(b => b.Links)
                .HasForeignKey(l => l.BookId);

            builder.HasOne(l => l.Genre)
                .WithMany(g => g.Links)
                .HasForeignKey(l => l.GenreId);
        }
    }
}
