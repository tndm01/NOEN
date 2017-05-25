using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NOEN.Data.Infrastructure;
using NOEN.Model.Models;

namespace NOEN.Data.Repositories
{
    //Để định nghĩa các phương thức mà k có sẵn trong Repository
    public interface ITagRepository : IRepository<Tag>
    {

    }
    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
