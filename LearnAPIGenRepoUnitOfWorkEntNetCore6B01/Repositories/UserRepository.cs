using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Interfaces;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Models;
using Microsoft.EntityFrameworkCore;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Repositories
{
    /*public class UserRepository : IUserRepository
    {
        private readonly LearnUOfWorkVPSCSharpContext _learnUOfWorkVPSCSharpContext;

        public UserRepository(LearnUOfWorkVPSCSharpContext learnUOfWorkVPSCSharpContext)
        {
            _learnUOfWorkVPSCSharpContext = learnUOfWorkVPSCSharpContext;
        }
        public void Add(User model)
        {
            try
            {
                _learnUOfWorkVPSCSharpContext.Users.Add(model);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<User>> GetAllUserAsync()
        {
            try
            {
                return await _learnUOfWorkVPSCSharpContext.Users.ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Remove(int userId)
        {
            try
            {
                var user = _learnUOfWorkVPSCSharpContext.Users.Find(userId);
                _learnUOfWorkVPSCSharpContext.Users.Remove(user);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }*/

    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(LearnUOfWorkVPSCSharpContext context) : base(context)
        {
        }

        public IEnumerable<User> Collection()
        {
            return UserContext.Users.ToList();
        }

        public LearnUOfWorkVPSCSharpContext UserContext
        {
            get { return Context as LearnUOfWorkVPSCSharpContext; }
        }
    }
}
