using Lesson10.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Lesson10
{
    /// <summary>
    /// Класс описывающий подключение к БД.
    /// </summary>
    public class ApplicationContext : DbContext
    {
        private string _connectionString;
        public DbSet<User> Users => Set<User>();
        public ApplicationContext(string connectionString)
        {
            _connectionString = connectionString;
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Name).HasColumnName("first_name").IsRequired().HasMaxLength(100);
                entity.Property(e => e.Surname).HasColumnName("last_name").IsRequired().HasMaxLength(100);
                entity.Property(e => e.Patronymic).HasColumnName("patronymic").HasMaxLength(100);
                entity.Property(e => e.BirthDate).HasColumnName("birth_date").IsRequired();
            });
        }
    }
}
