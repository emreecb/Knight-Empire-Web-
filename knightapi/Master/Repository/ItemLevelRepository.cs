using Master.Infrastructure;
using Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Repository
{
    public class ItemLevelRepository : BaseRepository<ItemLevel>, IItemLevelRepository
    {
        public ItemLevelRepository(MasterContext dbContext)
        : base(dbContext)
        {

        }
    }
}