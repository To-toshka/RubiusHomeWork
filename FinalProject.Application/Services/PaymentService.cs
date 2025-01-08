using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Abstractions.Services;
using FinalProject.Domain;

namespace FinalProject.Application.Services
{
    /// <summary>
    /// Сервис для работы с сущностью Оплата (Payment).
    /// </summary>
    /// <param name="paymentRepository">Экземпляр интерфейс для работы с сущностью в слое Infrastructure.</param>
    public class PaymentService(IEntitiesRepository<Payment> paymentRepository) : IEntitieService<Payment>
    {
        /// <summary>
        /// Получение списка оплат.
        /// </summary>
        /// <returns>Коллекция оплат (Payment)</returns>
        public Task<IReadOnlyCollection<Payment>> Get()
        {
            return paymentRepository.Get();
        }

        /// <summary>
        /// Получение оплат (Payment) по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор оплаты (Payment).</param>
        /// <returns>Оплата (Payment).</returns>
        public Task<Payment> GetById(long id)
        {
            return paymentRepository.GetById(id);
        }

        /// <summary>
        /// Создание оплаты (Payment).
        /// </summary>
        /// <param name="payment">Оплата.</param>
        /// <returns>Id оплаты.</returns>
        public Task<long> Create(Payment payment)
        {
            return paymentRepository.Create(payment);
        }

        /// <summary>
        /// Изменение оплаты (Payment).
        /// </summary>
        /// <param name="id">Уникальный идентификатор оплаты (Payment).</param>
        /// <param name="payment">Оплата.</param>
        /// <returns>Сообщение "OK".</returns>
        public Task<object> Update(long id, Payment payment)
        {
            return paymentRepository.Update(id, payment);
        }

        /// <summary>
        /// Удаление оплаты (Payment).
        /// </summary>
        /// <param name="id">Уникальный идентификатор оплаты (Payment).</param>
        /// <returns>Строка "OK".</returns>
        public Task<object> Delete(long id)
        {
            return paymentRepository.Delete(id);
        }
    }
}
