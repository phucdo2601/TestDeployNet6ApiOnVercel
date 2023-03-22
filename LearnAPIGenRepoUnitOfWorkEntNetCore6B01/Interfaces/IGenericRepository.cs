using System.Linq.Expressions;

namespace LearnAPIGenRepoUnitOfWorkEntNetCore6B01.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        T GetById(int id);

        /**
         * https://codelearn.io/sharing/ienumerable-khac-iqueryable
         * Khi sử dụng IEnumerable, câu lệnh truy vấn sẽ thực hiện trên máy chủ và trả về dữ liệu cho client. 
         * Sau khi trả hết dữ liệu, client mới thực hiện lấy 2 bản ghi đầu tiên.

           Khi sử dụng IQueryable, câu lệnh truy vấn sẽ thực hiện trên máy chủ, 
            lọc trên máy chủ và trả dữ liệu cho client.
         */
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T, bool>> predicate); 
        
        IQueryable<T> FindAll();

        /**
         * Linq Expression: https://viblo.asia/p/linq-expression-m68Z0yNjlkG
         *  Expression đại diện cho biểu thức lambda mạnh mẽ. Nó có nghĩa là biểu thức lambda cũng có thể được gán cho loại Expression<TDelegate>. 
         *  Trình biên dich .NET chuyển đổi biểu thức lambda được gán cho biểu thức Expression<TDelegate> thành một cây biểu thức Expression
         *  thay vì mã thực thi. 
         */
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition);

        IQueryable<T> FindInclude(params Expression<Func<T, object>>[] includes);

        IQueryable<T> FindIncludeByCondition(Expression<Func<T, bool>> condition, params Expression<Func<T, object>>[] includes);

        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate); 
        void Add(T entity);
        void AddRange(IEnumerable<T> entities);
        void Remove(T entity);
        void RemoveAll(IEnumerable<T> entities);
        void Update(T entity);
    }
}
