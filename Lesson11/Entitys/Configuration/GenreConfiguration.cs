using Lesson11.Entitys.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lesson11.Entitys.Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            //builder.ToTable("Genres");
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name).IsRequired().HasMaxLength(100);

            builder.HasMany(g => g.Links)
                .WithOne(l => l.Genre)
                .HasForeignKey(l => l.GenreId);

            builder.HasMany(g => g.Books)
                .WithMany(b => b.Genres)
                .UsingEntity<GenreLink>(
                    l => l.HasOne(x => x.Book).WithMany().HasForeignKey(x => x.BookId),
                    r => r.HasOne(x => x.Genre).WithMany().HasForeignKey(x => x.GenreId),
                    j =>
                    {
                        j.HasKey(lr => new { lr.BookId, lr.GenreId });
                    }
                );
        }
    }
}
