using LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Repositories;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Interfaces
{
    /**
     * IDisposable là 1 interface nó chứa một phương thức duy nhất Dispose() để giải phóng 
     * các tài nguyên không được quản lý như tệp luồng, 
     * kết nối cơ sở dữ liệu. 
     */
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> SaveAsync();

        Task<int> SaveAsync2();

        int Save();

        IUserRepository UserRepository { get; }
        ICarRepository CarRepository { get; }
    }
}
