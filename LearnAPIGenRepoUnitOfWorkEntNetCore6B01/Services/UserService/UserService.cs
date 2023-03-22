using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.DTOs.Request;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Interfaces;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Models;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork= unitOfWork;
        }

        public int CreateUser(UserRequest userRequest)
        {
            var emailAddess = _unitOfWork.UserRepository.FindByCondition(e => e.EmailAddress.Equals(userRequest.EmailAddress)).Select(e => e.EmailAddress).FirstOrDefault();
            if (emailAddess != null) 
            {
                throw new Exception($"Email '{emailAddess}' already exists");
            }

            User user = new User()
            {
                UserName = userRequest.UserName,
                UserTypeId = userRequest.UserTypeId,
                BlackListed = userRequest.BlackListed,
                BcId = userRequest.BcId,
                MobileNo = userRequest.MobileNo,
                EmailAddress = userRequest.EmailAddress,
            };

            _unitOfWork.UserRepository.Add(user);
            int created = _unitOfWork.Save();
            return created;
        }

        public List<User> GetAllUser()
        {
            var listAllUsers = _unitOfWork.UserRepository.FindAll().ToList();
            return listAllUsers;
        }

        public User GetUserById(int id)
        {
            var user = _unitOfWork.UserRepository.FindByCondition(e => e.Uid.Equals(id)).FirstOrDefault();

            return user;
        }

        public int UpdateUser(int userId, UserRequest userRequest)
        {
            int update = -1;
            var userFindById = _unitOfWork.UserRepository.FindByCondition(e => e.Uid.Equals(userId)).FirstOrDefault();
            if (userFindById != null)
            {
                var email = _unitOfWork.UserRepository.FindByCondition(e => !e.Uid.Equals(userId) && e.EmailAddress.Equals(userRequest.EmailAddress)).Select(e => e.EmailAddress).FirstOrDefault();
                if (email != null)
                {
                    throw new Exception($"Email '{email}' already exists");
                }
                userFindById.UserName = userRequest.UserName;   
                userFindById.UserTypeId = userRequest.UserTypeId;
                userFindById.BlackListed = userRequest.BlackListed;
                userFindById.BcId = userRequest.BcId;
                userFindById.MobileNo = userRequest.MobileNo;
                userFindById.EmailAddress = userRequest.EmailAddress;

                _unitOfWork.UserRepository.Update(userFindById);
                update = _unitOfWork.Save();

            }
            return update;
        }
    }
}
