using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Interfaces;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Models;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Repositories
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(LearnUOfWorkVPSCSharpContext context) : base(context)
        {
        }
    }
}
