namespace Lesson11.Entitys.DTO
{
    public class Book
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public string Title { get; set; }
        public DateTime? Created { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? Description { get; set; }
        public virtual Author Author { get; set; }        
        public virtual ICollection<GenreLink>? Links { get; set; }
        public virtual ICollection<Genre>? Genres { get; set; }
    }
}
