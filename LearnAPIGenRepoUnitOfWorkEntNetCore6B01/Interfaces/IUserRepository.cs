using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Models;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Interfaces
{
    public interface IUserRepository: IGenericRepository<User>
    {
        /*void Add(User model);

        void Remove(int userId);

        Task<IEnumerable<User>> GetAllUserAsync();*/

        IEnumerable<User> Collection();
    }
}
