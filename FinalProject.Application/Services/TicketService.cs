using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Abstractions.Services;
using FinalProject.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Application.Services
{
    /// <summary>
    /// Сервис для работы с сущностью Билет (Ticket).
    /// </summary>
    /// <param name="ticketRepository">Экземпляр интерфейс для работы с сущностью в слое Infrastructure.</param>
    public class TicketService(IEntitiesRepository<Ticket> ticketRepository) : IEntitieService<Ticket>
    {
        /// <summary>
        /// Создание билета (Ticket).
        /// </summary>
        /// <param name="ticket">Билет.</param>
        /// <returns>Id билета.</returns>
        public Task<long> Create(Ticket ticket)
        {
            return ticketRepository.Create(ticket);
        }

        /// <summary>
        /// Удаление билета (Ticket).
        /// </summary>
        /// <param name="id">Уникальный идентификатор билета (Ticket).</param>
        /// <returns>Сообщение "OK".</returns>
        public Task<object> Delete(long id)
        {
            return ticketRepository.Delete(id);
        }

        /// <summary>
        /// Получение билета (Ticket) по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор билета (Ticket).</param>
        /// <returns>Билет (Ticket).</returns>
        public Task<Ticket> GetById(long id)
        {
            return ticketRepository.GetById(id);
        }

        /// <summary>
        /// Получение списка билетов.
        /// </summary>
        /// <returns>Коллекция билетов (Tickets)</returns>
        public Task<IReadOnlyCollection<Ticket>> Get()
        {
            return ticketRepository.Get();
        }

        /// <summary>
        /// Изменение билета (Ticket).
        /// </summary>
        /// <param name="id">Уникальный идентификатор билета (Ticket).</param>
        /// <param name="ticket">Билет.</param>
        /// <returns>Сообщение "OK".</returns>
        public Task<object> Update(long id, Ticket ticket)
        {
            return ticketRepository.Update(id, ticket);
        }

    }
}
