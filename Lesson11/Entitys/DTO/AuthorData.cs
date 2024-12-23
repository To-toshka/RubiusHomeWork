namespace Lesson11.Entitys.DTO
{
    public class AuthorData
    {
        public Guid Id { get; set; }
        public Guid AuthorId { get; set; }
        public DateOnly? DeathDate { get; set; }
        public string? Country { get; set; }
        public int? BooksQuantity { get; set; }
        public bool PulitzerPrize { get; set; }
        public bool NobelPrizeForLiterature { get; set; }
        public virtual Author Author { get; set; }

    }
}
