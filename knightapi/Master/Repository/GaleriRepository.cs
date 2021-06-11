using System;
using System.Collections.Generic;
using Master.Infrastructure;
using Master.Model;
using System.Text;

namespace Master.Repository
{
    public class GaleriRepository : BaseRepository<Galeri>, IGaleriRepository
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
        public GaleriRepository(MasterContext dbContext)
        : base(dbContext)
        {

        }
    }
}