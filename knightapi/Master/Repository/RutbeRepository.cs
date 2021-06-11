using Master.Infrastructure;
using Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Repository
{
    public class RutbeRepository : BaseRepository<Rutbe>, IRutbeRepository
    {

        public RutbeRepository(MasterContext dbContext)
        : base(dbContext)
        {

        }
    }
}