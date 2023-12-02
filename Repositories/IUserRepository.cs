using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace recruitment_app.Repositories
{
    public interface IUserRepository<T>
    {
        Task<T> GetUserById(Guid uuid);
        Task AddUser(T entity);
        Task<IEnumerable<T>> GetAllUsers();
        Task UpdateUser(T entity);
        Task DeleteUser(Guid uuid);
    }
}