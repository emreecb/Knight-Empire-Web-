using Master.Infrastructure;
using Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Repository
{
    public class CharacterDetailsRepository : BaseRepository<CharacterDetails>, ICharacterDetailsRepository
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
        public CharacterDetailsRepository(MasterContext dbContext)
        : base(dbContext)
        {

        }
    }
}