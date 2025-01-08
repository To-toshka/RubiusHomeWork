using FinalProject.Domain;

namespace FinalProject.Application.Abstractions.Repositories
{
    /// <summary>
    /// Интерфейс для работы с сущностью Перевозчик (Operator) в слое Infrastructure.
    /// </summary>
    public interface IOperatorRepository
    {
        /// <summary>
        /// Получение списка перевозчиков.
        /// </summary>
        /// <returns>Коллекция перевозчиков (Operators)</returns>
        Task<IReadOnlyCollection<Operator>> GetOperators();

        /// <summary>
        /// Получение перевозчика (Operator) по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор перевозчика (Operator).</param>
        /// <returns>Перевозчик (Operator).</returns>
        Task<Operator> GetOperatorById(long id);

        /// <summary>
        /// Создание перевозчика (Operator).
        /// </summary>
        /// <param name="newOperator">Перевозчик.</param>
        /// <returns>Id перевозчика.</returns>
        Task<long> CreateOperator(Operator newOperator);

        /// <summary>
        /// Изменение перевозчика (Operator).
        /// </summary>
        /// <param name="id">Уникальный идентификатор перевозчика (Operator).</param>
        /// <param name="dataOperator">Перевозчик.</param>
        /// <returns>Сообщение "OK".</returns>
        Task<object> UpdateOperator(long id, Operator dataOperator);

        /// <summary>
        /// Удаление перевозчика (Operator).
        /// </summary>
        /// <param name="id">Уникальный идентификатор перевозчика (Operator).</param>
        /// <returns>Строка "OK".</returns>
        Task<object> DeleteOperator(long id);
    }
}
