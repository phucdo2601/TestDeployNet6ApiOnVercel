using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Interfaces;
using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Models;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
		private readonly LearnUOfWorkVPSCSharpContext _learnUOfWorkVPSCSharpContext;

        public UnitOfWork(LearnUOfWorkVPSCSharpContext learnUOfWorkVPSCSharpContext)
		{
			_learnUOfWorkVPSCSharpContext= learnUOfWorkVPSCSharpContext;
		}

        public IUserRepository UserRepository => new UserRepository(_learnUOfWorkVPSCSharpContext);

        public ICarRepository CarRepository => new CarRepository(_learnUOfWorkVPSCSharpContext);

        /**
         * Trong truong hop nay dung de giai phong tai nguyen, ngat kn csdl
         */
        public void Dispose()
        {
            _learnUOfWorkVPSCSharpContext.Dispose();
        }

        public int Save()
        {
            int result = _learnUOfWorkVPSCSharpContext.SaveChanges();
            _learnUOfWorkVPSCSharpContext.ChangeTracker.Clear();
            return result;
        }

        public async Task<bool> SaveAsync()
        {
			try
			{ 
                int result = await _learnUOfWorkVPSCSharpContext.SaveChangesAsync();
                /**
                 * Lớp ChangeTracker chịu trách nhiệm theo dõi các thực thể được tải 
                 * vào Ngữ cảnh. Nó làm như vậy bằng cách tạo một thể hiện của lớp 
                 * EntityEntry cho mọi thực thể. ChnageTracker duy trì Trạng thái Thực thể, 
                 * Giá trị Ban đầu, Giá trị Hiện tại, v.v. của từng thực thể trong 
                 * lớp EntityEntry.
                 */
                _learnUOfWorkVPSCSharpContext.ChangeTracker.Clear();
                return result > 0;
			}
			catch (Exception)
			{

				throw;
			}
        }

        public async Task<int> SaveAsync2()
        {
            int result = await _learnUOfWorkVPSCSharpContext.SaveChangesAsync();
            _learnUOfWorkVPSCSharpContext.ChangeTracker.Clear();
            return result;
        }
    }
}
