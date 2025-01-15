﻿namespace FinalProject.Application.DTO
{
    /// <summary>
    /// Класс описывающий DTO Оплаты (Payment).
    /// </summary>
    public class PaymentDTO : BaseDTO
    {
        /// <summary>
        /// Дата оплаты.
        /// </summary>
        public DateTime PaymentDate { get; set; }

        /// <summary>
        /// Уникальный идентификатор пользователя.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Уникальный идентификатор бронирования.
        /// </summary>
        public long ReservationId { get; set; }

        /// <summary>
        /// Размер платежа.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Банк отправителя.
        /// </summary>
        public string SenderBank { get; set; }

        /// <summary>
        /// Счет отправителя.
        /// </summary>
        public string SenderPaymentAccount { get; set; }

        /// <summary>
        /// Банк получателя.
        /// </summary>
        public string RecipientBank { get; set; }

        /// <summary>
        /// Счет получателя.
        /// </summary>
        public string RecipientPaymentAccount { get; set; }
    }
}
