using Lesson11.Entitys.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lesson11.Entitys.Configuration
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //builder.ToTable("Books");
            builder.HasKey(b => b.Id);
            builder.Property(b => b.AuthorId).IsRequired().HasColumnType("uuid");
            builder.Property(b => b.Title).IsRequired().HasMaxLength(100);
            builder.Property(b => b.Created).HasColumnType("date");
            builder.Property(b => b.OriginalLanguage).HasMaxLength(100);
            builder.Property(b => b.Created).HasColumnType("text");

            builder.HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);

            builder.HasMany(b => b.Links)
                .WithOne(l => l.Book)
                .HasForeignKey(l => l.BookId);

            builder.HasMany(b => b.Genres)
                .WithMany(g => g.Books)
                .UsingEntity<GenreLink>(
                    l => l.HasOne(x => x.Genre).WithMany().HasForeignKey(x => x.GenreId),
                    r => r.HasOne(x => x.Book).WithMany().HasForeignKey(x => x.BookId),
                    j =>
                    {
                        j.HasKey(lr => new { lr.GenreId, lr.BookId });
                    }
                );
        }
    }
}