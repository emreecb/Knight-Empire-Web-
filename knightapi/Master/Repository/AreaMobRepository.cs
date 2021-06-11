using Master.Infrastructure;
using Master.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Master.Repository
{
    public class AreaMobRepository : BaseRepository<AreaMob>, IAreaMobRepository
    {

        public AreaMobRepository(MasterContext dbContext)
        : base(dbContext)
        {

        }
    }
}