using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Abstractions.Services;
using FinalProject.Domain;

namespace FinalProject.Application.Services
{
    /// <summary>
    /// Сервис для работы с сущностью Данные пассажира в билете (TicketData).
    /// </summary>
    /// <param name="ticketDataRepository">Экземпляр интерфейс для работы с сущностью в слое Infrastructure.</param>
    public class TicketDataService(IEntitiesRepository<TicketData> ticketDataRepository) : IEntitieService<TicketData>
    {
        /// <summary>
        /// Создание данных пассажира (TicketData).
        /// </summary>
        /// <param name="ticketData">Данных пассажира.</param>
        /// <returns>Id данных пассажира.</returns>
        public Task<long> Create(TicketData ticketData)
        {
            return ticketDataRepository.Create(ticketData);
        }

        /// <summary>
        /// Удаление данных пассажира (TicketData).
        /// </summary>
        /// <param name="id">Уникальный идентификатор данных пассажира (TicketData).</param>
        /// <returns>Сообщение "OK".</returns>
        public Task<object> Delete(long id)
        {
            return ticketDataRepository.Delete(id);
        }

        /// <summary>
        /// Получение данных пассажира (TicketData) по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор данных пассажира (TicketData).</param>
        /// <returns>Данные пассажира (TicketData).</returns>
        public Task<TicketData> GetById(long id)
        {
            return ticketDataRepository.GetById(id);
        }

        /// <summary>
        /// Получение списка данных пассажиров.
        /// </summary>
        /// <returns>Коллекция данных пассажиров (TicketData)</returns>
        public Task<IReadOnlyCollection<TicketData>> Get()
        {
            return ticketDataRepository.Get();
        }

        /// <summary>
        /// Изменение данных пассажира (TicketData).
        /// </summary>
        /// <param name="id">Уникальный идентификатор данных пассажира (TicketData).</param>
        /// <param name="ticketData">Данные пассажира.</param>
        /// <returns>Сообщение "OK".</returns>
        public Task<object> Update(long id, TicketData ticketData)
        {
            return ticketDataRepository.Update(id, ticketData);
        }
    }
}
