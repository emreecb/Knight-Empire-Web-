using Master.Infrastructure;
using Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Repository
{
    public class InventoryRepository : BaseRepository<Inventory>, IInventoryRepository
    {
       
        public InventoryRepository(MasterContext dbContext)
        : base(dbContext)
        {

        }
    }
}