using Master.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Master.Infrastructure
{
    public interface IAcilisBildirimRepository : IRepository<AcilisBildirim>
    {
        void Delete(int id);
    }
}
