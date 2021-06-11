using System;
using System.Collections.Generic;
using System.IO;
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
    public class SosyalMedyaController : Controller
    {
        private ISosyalMedyaRepository _sosyalMedyaRepository;
        private readonly IHostingEnvironment _appEnvironment;

        public SosyalMedyaController(ISosyalMedyaRepository sosyalMedyaRepository, IHostingEnvironment appEnvironment)
        {
            _sosyalMedyaRepository = sosyalMedyaRepository;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IEnumerable<SosyalMedya> Get()
        {
            var model = _sosyalMedyaRepository.GetMany(x => x.DeleteStatus == false);
            return model;
        }

        [HttpGet("{id}")]
        public SosyalMedya Get(int id)
        {
            return _sosyalMedyaRepository.Get(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]SosyalMedya obj)
        {
            try
            {
                obj.DeleteStatus = false;
                obj.Active = true;
                obj.CreateTime = DateTime.Now;
                _sosyalMedyaRepository.Insert(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }



        [HttpPut]
        public IActionResult Put([FromBody] SosyalMedya obj)
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
                _sosyalMedyaRepository.Update(obj);
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
                _sosyalMedyaRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}