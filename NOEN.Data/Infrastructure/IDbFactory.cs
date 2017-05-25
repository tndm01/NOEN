using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOEN.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        NOENdbContext Init();
    }
}
