using System;
using System.Collections.Generic;
using System.Text;
using Master.Infrastructure;
using Master.Model;

namespace Master.Repository
{
    public class AcilisBildirimRepository : BaseRepository<AcilisBildirim>, IAcilisBildirimRepository
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

        public AcilisBildirimRepository(MasterContext dbContext)
        : base(dbContext)
        {

        }
    }
}