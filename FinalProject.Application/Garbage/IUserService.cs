using FinalProject.Domain;

namespace FinalProject.Application.Abstractions.Services
{
    /// <summary>
    /// Интерфейс для работы с сущностью Пользователь (User).
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Получение списка пользователей.
        /// </summary>
        /// <returns>Коллекция пользователей (Users)</returns>
        Task<IReadOnlyCollection<User>> GetUsers();

        /// <summary>
        /// Получение пользователя (User) по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя (User).</param>
        /// <returns>Пользователь (User).</returns>
        Task<User> GetUserById(long id);

        /// <summary>
        /// Создание пользователя (User).
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <returns>Id пользователя.</returns>
        Task<long> CreateUser(User user);

        /// <summary>
        /// Изменение пользователя (User).
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя (User).</param>
        /// <param name="user">Пользователь.</param>
        /// <returns>Строка "OK".</returns>
        Task<object> UpdateUser(long id, User user);

        /// <summary>
        /// Удаление пользователя (User).
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя (User).</param>
        /// <returns>Строка "OK".</returns>
        Task<object> DeleteUser(long id);
    }
}
