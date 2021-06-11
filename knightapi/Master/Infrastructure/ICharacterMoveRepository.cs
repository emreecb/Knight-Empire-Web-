using Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Infrastructure
{
    public interface ICharacterMoveRepository : IRepository<CharacterMove>
    {
        void Delete(int id);
    }
}
