using FinalProject.Application.Abstractions.Repositories;
using FinalProject.Application.Abstractions.Services;
using FinalProject.Domain;

namespace FinalProject.Application.Services
{
    /// <summary>
    /// Сервис для работы с сущностью Пользователь (User).
    /// </summary>
    /// /// <param name="userRepository">Экземпляр интерфейс для работы с сущностью в слое Infrastructure.</param>
    public class UserService(IEntitiesRepository<User> userRepository) : IEntitieService<User>
    {
        /// <summary>
        /// Создание пользователя (User).
        /// </summary>
        /// <param name="user">Пользователь.</param>
        /// <returns>Id пользователя.</returns>
        public Task<long> Create(User user)
        {
            return userRepository.Create(user);
        }

        /// <summary>
        /// Удаление пользователя (User).
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя (User).</param>
        /// <returns>Сообщение "OK".</returns>
        public Task<object> Delete(long id)
        {
            return userRepository.Delete(id);
        }

        /// <summary>
        /// Получение пользователя (User) по id.
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя (User).</param>
        /// <returns>Пользователь (User).</returns>
        public Task<User> GetById(long id)
        {
            return userRepository.GetById(id);
        }

        /// <summary>
        /// Получение списка пользователей.
        /// </summary>
        /// <returns>Коллекция пользователей (Users)</returns>
        public Task<IReadOnlyCollection<User>> Get()
        {
            return userRepository.Get();
        }

        /// <summary>
        /// Изменение пользователя (User).
        /// </summary>
        /// <param name="id">Уникальный идентификатор пользователя (User).</param>
        /// <param name="user">Пользователь.</param>
        /// <returns>Сообщение "OK".</returns>
        public Task<object> Update(long id, User user)
        {
            return userRepository.Update(id, user);
        }
    }
}
