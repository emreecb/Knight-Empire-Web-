using Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Infrastructure
{
    public interface IHaberRepository : IRepository<Haber>
    {
        void Delete(int id);

    }
}
