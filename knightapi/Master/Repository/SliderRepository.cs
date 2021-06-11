using System;
using System.Collections.Generic;
using Master.Infrastructure;
using Master.Model;
using System.Text;

namespace Master.Repository
{
    public class SliderRepository : BaseRepository<Slider>, ISliderRepository
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
        public SliderRepository(MasterContext dbContext)
        : base(dbContext)
        {

        }
    }
}