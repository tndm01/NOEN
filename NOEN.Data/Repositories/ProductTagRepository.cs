using NOEN.Data.Infrastructure;
using NOEN.Model.Models;

namespace NOEN.Data.Repositories
{
    public interface IProductTagRepository : IRepository<ProductTag> { }

    public class ProductTagRepository : RepositoryBase<ProductTag>, IProductTagRepository
    {
        public ProductTagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}