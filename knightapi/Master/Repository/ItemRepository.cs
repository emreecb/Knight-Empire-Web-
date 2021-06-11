using Master.Infrastructure;
using Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Repository
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {

        public ItemRepository(MasterContext dbContext)
        : base(dbContext)
        {

        }
    }
}