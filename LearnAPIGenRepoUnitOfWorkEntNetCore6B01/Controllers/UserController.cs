using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.DTOs.Responses;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Interfaces;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Models;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Repositories;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Services.UserService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
            _userService = new UserService(unitOfWork);
        }

        public IUnitOfWork UnitOfWork { get; }

        /*[HttpGet]
        public async Task<IActionResult> GetListUsers() 
        { 
            var users = await UnitOfWork.UserRepository.GetAllUserAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(User user)
        {
            UnitOfWork.UserRepository.Add(user);
            await UnitOfWork.SaveAsync();
            return Ok(user);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteUser(int userId)
        {
            UnitOfWork.UserRepository.Remove(userId);
            await UnitOfWork.SaveAsync();
            return Ok("Delete Successfuly!");
        }*/

        [HttpGet]
        public IActionResult GetUsets()
        {
            var users = UnitOfWork.UserRepository.GetAll();
            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewUser(User user)
        {
            UnitOfWork.UserRepository.Add(user);
            await UnitOfWork.SaveAsync();
            return Ok(user);
        }

        [HttpDelete("Delete/{id}")]
        public ActionResult DeleteUser(int userId)
        {
            User user = new User();
            user = UnitOfWork.UserRepository.Find(u => u.Uid== userId).FirstOrDefault();
            UnitOfWork.UserRepository.Remove(user);
            UnitOfWork.SaveAsync();
            return Ok("Delete User Successfully!");
        }

        [HttpGet("user-service/GetAllUsers")]
        public async Task<ActionResult> GetAllUserUsingSerivces()
        {
            var users = _userService.GetAllUser();

            return users.Count >= 0 ? await Task.FromResult(StatusCode(StatusCodes.Status200OK, users)) 
                : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new Response { StatusCode = StatusCodes.Status404NotFound, Status = StatusResponse.Failed, Message = "Not found BasicSalarys" }));

        }
    }
}
