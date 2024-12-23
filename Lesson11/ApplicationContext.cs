using Lesson11.Entitys.Configuration;
using Lesson11.Entitys.DTO;
using Microsoft.EntityFrameworkCore;

namespace Lesson11
{
    public class ApplicationContext : DbContext
    {
        //private string _connectionString;
                
        public DbSet<Author> Authors { get; set; }
        public DbSet<AuthorData> AuthorsData { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreLink> GenresLinks { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options) {}
        /*
        public ApplicationContext()//string connectionString)
        {
            //_connectionString = connectionString;
            Database.EnsureCreated();
        }*/

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=postgres;Database=postgres");
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            /*modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorDateConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new GenreConfiguration());
            modelBuilder.ApplyConfiguration(new GenreLinksConfigurationa());*/
            builder.Entity<Author>(entity =>
            {
                entity.ToTable("Authors");
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Surname).HasColumnName("Surname").IsRequired().HasMaxLength(100);
                entity.Property(a => a.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
                entity.Property(a => a.Patronymic).HasColumnName("Patronymic").HasMaxLength(100);
                entity.Property(a => a.BirthDate).HasColumnName("BirthDate").HasColumnType("date");
                entity.Property(a => a.AuthorDescription).HasColumnName("AuthorDescription").HasColumnType("text");

                entity.HasMany(a => a.Books)
                    .WithOne(b => b.Author)
                    .HasForeignKey(p => p.AuthorId);

                entity.HasOne(a => a.AuthorData)
                    .WithOne(ad => ad.Author)
                    .HasForeignKey<AuthorData>(ad => ad.AuthorId);
            });

            builder.Entity<AuthorData>(entity =>
            {
                entity.ToTable("AuthorsData");
                entity.HasKey(ad => ad.Id);
                entity.Property(b => b.AuthorId).HasColumnName("AuthorId").IsRequired().HasColumnType("uuid");
                entity.Property(ad => ad.DeathDate).HasColumnName("DeathDate").HasColumnType("date");
                entity.Property(ad => ad.Country).HasColumnName("Country").HasMaxLength(100);
                entity.Property(ad => ad.BooksQuantity).HasColumnName("BooksQuantity").HasColumnType("integer");
                entity.Property(ad => ad.PulitzerPrize).HasColumnName("PulitzerPrize").IsRequired().HasColumnType("boolean");
                entity.Property(ad => ad.NobelPrizeForLiterature).HasColumnName("NobelPrizeForLiterature").IsRequired().HasColumnType("boolean");

                /*entity.HasOne(ad => ad.Author)
                    .WithOne(a => a.AuthorData)
                    .HasForeignKey<Author>(a => a.Id);*/
            });

            builder.Entity<Book>(entity =>
            {
                entity.ToTable("Books");
                entity.HasKey(b => b.Id);
                entity.Property(b => b.AuthorId).HasColumnName("AuthorId").IsRequired().HasColumnType("uuid");
                entity.Property(b => b.Title).HasColumnName("Title").IsRequired().HasMaxLength(100);
                entity.Property(b => b.Created).HasColumnName("Created").HasColumnType("date");
                entity.Property(b => b.OriginalLanguage).HasColumnName("OriginalLanguage").HasMaxLength(100);
                entity.Property(b => b.Description).HasColumnName("Description").HasColumnType("text");

                /*entity.HasOne(b => b.Author)
                    .WithMany(a => a.Books)
                    .HasForeignKey(b => b.AuthorId);*/

                /*entity.HasMany(b => b.Links)
                    .WithOne(l => l.Book)
                    .HasForeignKey(l => l.BookId);*/

                entity.HasMany(b => b.Genres)
                    .WithMany(g => g.Books)
                    .UsingEntity<GenreLink>(
                        l => l.HasOne(x => x.Genre).WithMany().HasForeignKey(x => x.GenreId),
                        r => r.HasOne(x => x.Book).WithMany().HasForeignKey(x => x.BookId),
                        j =>
                        {
                            j.HasKey(lr => new { lr.GenreId, lr.BookId });
                        }
                    );
            });

            builder.Entity<Genre>(entity =>
            {
                entity.ToTable("Genres");
                entity.HasKey(g => g.Id);
                entity.Property(g => g.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);

                /*entity.HasMany(g => g.Links)
                    .WithOne(l => l.Genre)
                    .HasForeignKey(l => l.GenreId);*/

                entity.HasMany(g => g.Books)
                    .WithMany(b => b.Genres)
                    .UsingEntity<GenreLink>(
                        l => l.HasOne(x => x.Book).WithMany().HasForeignKey(x => x.BookId),
                        r => r.HasOne(x => x.Genre).WithMany().HasForeignKey(x => x.GenreId),
                        j =>
                        {
                            j.HasKey(lr => new { lr.BookId, lr.GenreId });
                        }
                    );
            });

            builder.Entity<GenreLink>(entity =>
            {
                entity.ToTable("GenresLinks");
                entity.HasKey(l => l.Id);
                entity.Property(l => l.BookId).HasColumnName("BookId").IsRequired().HasColumnType("uuid");
                entity.Property(l => l.GenreId).HasColumnName("GenreId").IsRequired().HasColumnType("uuid");

                entity.HasOne(l => l.Book)
                    .WithMany(b => b.Links)
                    .HasForeignKey(l => l.BookId);

                entity.HasOne(l => l.Genre)
                    .WithMany(g => g.Links)
                    .HasForeignKey(l => l.GenreId);
            });
        }
    }
}
