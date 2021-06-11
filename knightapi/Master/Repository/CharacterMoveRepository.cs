using Master.Infrastructure;
using Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Repository
{
    public class CharacterMoveRepository : BaseRepository<CharacterMove>, ICharacterMoveRepository
    {
        public void Delete(int id)
        {
            var obj = Get(x => x.Id == id);
            if (obj != null)
            {
                obj.DeleteStatus = true;
                Update(obj);
                Save();
            }
        }
        public CharacterMoveRepository(MasterContext dbContext)
        : base(dbContext)
        {

        }
    }
}