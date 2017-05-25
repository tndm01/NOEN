using NOEN.Data.Infrastructure;
using NOEN.Model.Models;

namespace NOEN.Data.Repositories
{
    //Để định nghĩa các phương thức chưa có sẵn trong Repository
    public interface IErrorRepository : IRepository<Error> { }

    public class ErrorRepository : RepositoryBase<Error>, IErrorRepository
    {
        public ErrorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}