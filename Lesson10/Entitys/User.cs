namespace Lesson10.Entitys
{
    /// <summary>
    /// Класс описывающий Пользователя - сущность хранящуюся в таблице Users БД.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Уникальный идентификатор Пользователя.
        /// </summary>
        public int? Id { get; set; }
        /// <summary>
        /// Имя Пользователя
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Фамилия Пользователя
        /// </summary>
        public string? Surname { get; set; }
        /// <summary>
        /// Отчество Пользователя
        /// </summary>
        public string? Patronymic { get; set; }
        /// <summary>
        /// Дата рождения Пользователя
        /// </summary>
        public DateOnly? BirthDate {  get; set; }
    }
}
