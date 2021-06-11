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
    public class NetpolController : Controller
    {
        private INetPolRepository _netPolRepository;
        private readonly IHostingEnvironment _appEnvironment;

        public NetpolController(INetPolRepository netPolRepository, IHostingEnvironment appEnvironment)
        {
            _netPolRepository = netPolRepository;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IEnumerable<NetPol> Get()
        {
            var model = _netPolRepository.GetMany(x => x.DeleteStatus == false);
            return model;
        }

        [HttpGet("{id}")]
        public NetPol Get(int id)
        {
            return _netPolRepository.Get(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]NetPol obj)
        {
            try
            {
                obj.DeleteStatus = false;
                obj.Active = true;
                obj.CreateTime = DateTime.Now;
                _netPolRepository.Insert(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] NetPol obj)
        {
            try
            {
                if (obj.Id == 0)
                {
                    obj.CreateTime = DateTime.Now;
                }
                else
                {
                    obj.UpdateTime = DateTime.Now;
                }
                obj.DeleteStatus = false;
                _netPolRepository.Update(obj);
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
                _netPolRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}