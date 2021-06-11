using Master.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Master.Infrastructure
{
    public interface ISosyalMedyaRepository : IRepository<SosyalMedya>
    {
        void Delete(int id);
    }
}
