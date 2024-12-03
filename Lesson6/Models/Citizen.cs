namespace Lesson6.Models
{
    /// <summary>
    /// Класс описывающий граждан для сервиса регистрации (RegistrationService).
    /// </summary>
    public class Citizen
    {
        /// <summary>
        /// Поле содержащее фамилию гражданина.
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Поле содержащее дату регистрации гражданина.
        /// </summary>
        public DateOnly RegistrationDate { get; set; }
    }
}
