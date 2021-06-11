using Master.Infrastructure;
using Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Repository
{
    public class GiftRepository : BaseRepository<Gift>, IGiftRepository
    {
        public GiftRepository(MasterContext dbContext)
        : base(dbContext)
        {

        }
    }
}