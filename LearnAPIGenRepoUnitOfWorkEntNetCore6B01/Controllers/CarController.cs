using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Interfaces;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public CarController(IUnitOfWork UOW)
        {
            this.UOW = UOW;
        }

        public IUnitOfWork UOW { get; }

        [HttpGet]
        public IActionResult GetCars()
        {
            var cars = UOW.CarRepository.GetAll();
            return Ok(cars);
        }

        [HttpGet("GetCarById/{id}")]
        public async Task<IActionResult> GetCarById([FromRoute(Name ="id")] int id)
        {
            var car = UOW.CarRepository.GetById(id);
            return car != null? await Task.FromResult(StatusCode(StatusCodes.Status200OK, car)) : await Task.FromResult(StatusCode(StatusCodes.Status404NotFound, new
            {
                errMessage= "Car not found with this id"
            }));
        }

        [HttpPost("AddCar")]
        public async Task<IActionResult> AddCar(Car car)
        {
            UOW.CarRepository.Add(car);
            await UOW.SaveAsync();
            return Ok(car);
        }

        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteCar([FromRoute(Name ="id")] int carId)
        {
            Car car = new Car();
            car = UOW.CarRepository.Find(c => c.CarId == carId).FirstOrDefault();
            UOW.CarRepository.Remove(car);
            await UOW.SaveAsync();
            return  await Task.FromResult(StatusCode(StatusCodes.Status200OK, new
            {
                message = "Delete Car Successfully!"
            }));
        }

        [HttpPut("Update/{id}")]
        public async Task<IActionResult> UpdateCar([FromRoute(Name ="id")] int CarId, [FromBody] Car model)
        {
            var car = UOW.CarRepository.Find(c => c.CarId==CarId).FirstOrDefault();
            car.PlateNo = model.PlateNo;
            car.Description = model.Description;
            await UOW.SaveAsync();
            return await Task.FromResult(StatusCode(StatusCodes.Status200OK, new
            {
                message = "Update Car Successfully!"
            }));

        }
    }
}
