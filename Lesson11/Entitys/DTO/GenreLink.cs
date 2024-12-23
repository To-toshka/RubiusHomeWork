namespace Lesson11.Entitys.DTO
{
    public class GenreLink
    {
        public Guid Id { get; set; }
        public Guid GenreId { get; set; }
        public Guid BookId { get; set; }
        public virtual Book Book { get; set; }
        public virtual Genre Genre { get; set; }

    }
}
