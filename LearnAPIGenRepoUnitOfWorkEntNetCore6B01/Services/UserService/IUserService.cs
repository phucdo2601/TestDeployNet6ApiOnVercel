using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.DTOs.Request;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Models;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Services.UserService
{
    public interface IUserService
    {
        List<User> GetAllUser();
        User GetUserById(int id);
        int CreateUser(UserRequest userRequest);  
        int UpdateUser(int userId, UserRequest userRequest);
    }
}
