namespace Lesson11.Entitys.DTO
{
    public class Genre
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<GenreLink>? Links { get; set; }
        public virtual ICollection<Book>? Books { get; set; }
    }
}
