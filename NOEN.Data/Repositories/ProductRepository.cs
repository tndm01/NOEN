using System.Collections.Generic;
using System.Linq;
using NOEN.Data.Infrastructure;
using NOEN.Model.Models;

namespace NOEN.Data.Repositories
{
    //Để định nghĩa các phương thức mà k có sẵn trong Repository
    public interface IProductRepository : IRepository<Product>
    {
        IEnumerable<Product> GetAlias(string alias);

        IEnumerable<Product> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow);
    }

    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ProductRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public IEnumerable<Product> GetAlias(string alias)
        {
            return this.DbContext.Products.Where(x => x.Alias == alias);
        }

        public IEnumerable<Product> GetListProductByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            var query = from p in DbContext.Products
                        join pt in DbContext.ProductTags
                        on p.ID equals pt.ProductID
                        where pt.TagID == tagId
                        select p;
            totalRow = query.Count();
            return query.OrderByDescending(x => x.CreatedDate).Skip((page - 1) * pageSize).Take(pageSize);
        }
    }
}