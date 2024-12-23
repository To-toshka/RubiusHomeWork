using Lesson11.Entitys.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lesson11.Entitys.Configuration
{
    public class AuthorDateConfiguration : IEntityTypeConfiguration<AuthorData>
    {
        public void Configure(EntityTypeBuilder<AuthorData> builder)
        {
            //builder.ToTable("AuthorsData");
            builder.HasKey(ad => ad.Id);
            builder.Property(ad => ad.DeathDate).HasColumnType("date");
            builder.Property(ad => ad.Country).HasMaxLength(100);
            builder.Property(ad => ad.BooksQuantity).HasColumnType("integer");
            builder.Property(ad => ad.PulitzerPrize).IsRequired().HasColumnType("boolean");
            builder.Property(ad => ad.NobelPrizeForLiterature).IsRequired().HasColumnType("boolean");

            builder.HasOne(ad => ad.Author)
                .WithOne(a => a.AuthorData)
                .HasForeignKey<Author>(a => a.Id);
        }
    }
}
