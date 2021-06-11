using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Master.Infrastructure;
using Master.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Master.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class AreaMobController : Controller
    {
        private IAreaMobRepository _areaMobRepository;
        private IMobRepository _mobRepository;
        private readonly IHostingEnvironment _appEnvironment;

        public AreaMobController(IAreaMobRepository areaMobRepository,IMobRepository mobRepository, IHostingEnvironment appEnvironment)
        {
            _areaMobRepository = areaMobRepository;
            _mobRepository = mobRepository;
            _appEnvironment = appEnvironment;
        }
        [HttpGet]
        public IEnumerable<AreaMob> Get()
        {
            var model = _areaMobRepository.GetAll();
            return model;
        }

        [HttpGet("{id}")]
        public AreaMob Get(int id)
        {
            return _areaMobRepository.Get(x => x.Id == id);
        }

        [HttpGet("getmoblist/{id}")]
        public IEnumerable<Mob> getmob(int id)
        {
            List<Mob> moblist = new List<Mob>();
            var model= _areaMobRepository.GetMany(x => x.AreaId == id);
            foreach(var item in model)
            {
                var mob = _mobRepository.Get(x => x.Id == item.MobId);
                moblist.Add(mob);
            }

            return moblist;
            
        }


        [HttpPut]
        public IActionResult Put([FromBody] AreaMob obj)
        {
            try
            {
                _areaMobRepository.Update(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var model = _areaMobRepository.Get(x => x.Id == id);
                _areaMobRepository.Remove(model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}