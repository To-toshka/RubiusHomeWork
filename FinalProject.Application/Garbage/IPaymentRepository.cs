using FinalProject.Domain;

namespace FinalProject.Application.Abstractions.Repositories
{
    /// <summary>
    /// Интерфейс для работы с сущностью Оплата (Payment) в слое Infrastructure.
    /// </summary>
    public interface IPaymentRepository
    {
        /// <summary>
        /// Получение списка оплат.
        /// </summary>
        /// <returns>Коллекция оплат (Payment)</returns>
        Task<IReadOnlyCollection<Payment>> GetPayments();

        /// <summary>
        /// Получение оплат (Payment) по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор оплаты (Payment).</param>
        /// <returns>Оплата (Payment).</returns>
        Task<Payment> GetPaymentById(long id);

        /// <summary>
        /// Создание оплаты (Payment).
        /// </summary>
        /// <param name="payment">Оплата.</param>
        /// <returns>Id оплаты.</returns>
        Task<long> CreateOperator(Payment payment);

        /// <summary>
        /// Изменение оплаты (Payment).
        /// </summary>
        /// <param name="id">Уникальный идентификатор оплаты (Payment).</param>
        /// <param name="payment">Оплата.</param>
        /// <returns>Сообщение "OK".</returns>
        Task<object> UpdatePayment(long id, Payment payment);

        /// <summary>
        /// Удаление оплаты (Payment).
        /// </summary>
        /// <param name="id">Уникальный идентификатор оплаты (Payment).</param>
        /// <returns>Строка "OK".</returns>
        Task<object> DeletePayment(long id);
    }
}
