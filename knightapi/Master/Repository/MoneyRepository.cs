using Master.Infrastructure;
using Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Repository
{
    public class MoneyRepository : BaseRepository<Money>, IMoneyRepository
    {
        public void Delete(int id)
        {
            var obj = Get(x => x.Id == id);
            if (obj != null)
            {
               /* obj.SilinmeDurumu = true;
                obj.Aktif = false;
                Update(obj);
                Save();*/
            }
        }
        public MoneyRepository(MasterContext dbContext)
        : base(dbContext)
        {

        }
    }
}