namespace FinalProject.Application.DTO
{
    /// <summary>
    /// Класс описывающий DTO Бронирования (Reservation).
    /// </summary>
    public class ReservationDTO
    {
        /// <summary>
        /// Уникальный идентификатор бронирования.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Дата бронирования.
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Статус бронирования.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        /// Полная стоимость бронирования.
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// Комиссия агрегатора.
        /// </summary>
        public decimal Commission { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public long UserId { get; set; }
    }
}
