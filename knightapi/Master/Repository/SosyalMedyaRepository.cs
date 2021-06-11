using System;
using System.Collections.Generic;
using System.Text;
using Master.Infrastructure;
using Master.Model;

namespace Master.Repository
{
    public class SosyalMedyaRepository : BaseRepository<SosyalMedya>, ISosyalMedyaRepository
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
        public SosyalMedyaRepository(MasterContext dbContext)
        : base(dbContext)
        {

        }
    }
}