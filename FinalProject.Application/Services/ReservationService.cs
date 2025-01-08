using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Abstractions.Services;
using FinalProject.Domain;

namespace FinalProject.Application.Services
{
    /// <summary>
    /// Сервис для работы с сущностью Бронирование (Reservation).
    /// </summary>
    /// <param name="reservationRepository">Экземпляр интерфейс для работы с сущностью в слое Infrastructure.</param>
    public class ReservationService(IEntitiesRepository<Reservation> reservationRepository) : IEntitieService<Reservation>
    {
        /// <summary>
        /// Создание бронирования (Reservation).
        /// </summary>
        /// <param name="reservation">Бронирование.</param>
        /// <returns>Id бронирования.</returns>
        public Task<long> Create(Reservation reservation)
        {
            return reservationRepository.Create(reservation);
        }

        /// <summary>
        /// Удаление бронирования (Reservation).
        /// </summary>
        /// <param name="id">Уникальный идентификатор бронирования (Reservation).</param>
        /// <returns>Сообщение "OK".</returns>
        public Task<object> Delete(long id)
        {
            return reservationRepository.Delete(id);
        }

        /// <summary>
        /// Получение бронирования (Reservation) по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор бронирования (Reservation).</param>
        /// <returns>Бронирования (Reservation).</returns>
        public Task<Reservation> GetById(long id)
        {
            return reservationRepository.GetById(id);
        }

        /// <summary>
        /// Получение списка бронирований.
        /// </summary>
        /// <returns>Коллекция бронирований (Reservation)</returns>
        public Task<IReadOnlyCollection<Reservation>> Get()
        {
            return reservationRepository.Get();
        }

        /// <summary>
        /// Изменение бронирования (Reservation).
        /// </summary>
        /// <param name="id">Уникальный идентификатор бронирования (Reservation).</param>
        /// <param name="reservation">Бронирование.</param>
        /// <returns>Сообщение "OK".</returns>
        public Task<object> Update(long id, Reservation reservation)
        {
            return reservationRepository.Update(id, reservation);
        }
    }
}
