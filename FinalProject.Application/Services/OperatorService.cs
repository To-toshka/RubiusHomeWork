using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Abstractions.Services;
using FinalProject.Domain;

namespace FinalProject.Application.Services
{
    /// <summary>
    /// Сервис для работы с сущностью Перевозчик (Operator).
    /// </summary>
    /// <param name="operatorRepository">Экземпляр интерфейс для работы с сущностью в слое Infrastructure.</param>
    public class OperatorService(IEntitiesRepository<Operator> operatorRepository) : IEntitieService<Operator>
    {
        /// <summary>
        /// Создание перевозчика (Operator).
        /// </summary>
        /// <param name="newOperator">Перевозчик.</param>
        /// <returns>Id перевозчика.</returns>
        public Task<long> Create(Operator newOperator)
        {
            return operatorRepository.Create(newOperator);
        }

        /// <summary>
        /// Удаление перевозчика (Operator).
        /// </summary>
        /// <param name="id">Уникальный идентификатор перевозчика (Operator).</param>
        /// <returns>Строка "OK".</returns>
        public Task<object> Delete(long id)
        {
            return operatorRepository.Delete(id);
        }

        /// <summary>
        /// Получение перевозчика (Operator) по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор перевозчика (Operator).</param>
        /// <returns>Перевозчик (Operator).</returns>
        public Task<Operator> GetById(long id)
        {
            return operatorRepository.GetById(id);
        }

        /// <summary>
        /// Получение списка перевозчиков.
        /// </summary>
        /// <returns>Коллекция перевозчиков (Operators)</returns>
        public Task<IReadOnlyCollection<Operator>> Get()
        {
            return operatorRepository.Get();
        }

        /// <summary>
        /// Изменение перевозчика (Operator).
        /// </summary>
        /// <param name="id">Уникальный идентификатор перевозчика (Operator).</param>
        /// <param name="dataOperator">Перевозчик.</param>
        /// <returns>Сообщение "OK".</returns>
        public Task<object> Update(long id, Operator dataOperator)
        {
            return operatorRepository.Update(id, dataOperator);
        }
    }
}
