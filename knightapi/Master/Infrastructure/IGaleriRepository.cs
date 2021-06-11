using Master.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Master.Infrastructure
{
    public interface IGaleriRepository : IRepository<Galeri>
    {
        void Delete(int id);
    }
}
