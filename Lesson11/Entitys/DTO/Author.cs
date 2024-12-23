namespace Lesson11.Entitys.DTO
{
    public class Author
    {
        public Guid Id { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string? Patronymic { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string? AuthorDescription { get; set; }
        public virtual AuthorData AuthorData {  get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
