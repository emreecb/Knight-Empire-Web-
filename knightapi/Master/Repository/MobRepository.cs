using Master.Infrastructure;
using Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Repository
{
    public class MobRepository : BaseRepository<Mob>, IMobRepository
    {
        public void Delete(int id)
        {
            var obj = Get(x => x.Id == id);
            if (obj != null)
            {
                obj.DeleteStatus = true;
                obj.Active = false;
                Update(obj);
                Save();
            }
        }
        public MobRepository(MasterContext dbContext)
        : base(dbContext)
        {

        }
    }
}