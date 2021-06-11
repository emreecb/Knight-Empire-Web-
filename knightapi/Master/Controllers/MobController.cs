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
    public class MobController : Controller
    {
        private IMobRepository _mobRepository;
        private readonly IHostingEnvironment _appEnvironment;

        public MobController(IMobRepository mobRepository, IHostingEnvironment appEnvironment)
        {
            _mobRepository = mobRepository;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IEnumerable<Mob> Get()
        {
            var model = _mobRepository.GetMany(x=>x.DeleteStatus==false);
            return model;
        }

        [HttpGet("{id}")]
        public Mob Get(int id)
        {
            return _mobRepository.Get(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Mob obj)
        {
            try
            {
                _mobRepository.Insert(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public Mob Patch(Mob obje)
        {
            var obj = _mobRepository.Get(x => x.Id == obje.Id);
            if (obj.UpdateTime == null)
            {
                obj.UpdateTime = DateTime.Now;
            }
            var files = HttpContext.Request.Form.Files;
            foreach (var Image in files)
            {
                if (Image != null && Image.Length > 0)
                {
                    var file = Image;
                    var uploads = Path.Combine(_appEnvironment.WebRootPath, "Uploads\\img");
                    if (file.Length > 0)
                    {
                        var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                        using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                        {
                            file.CopyTo(fileStream);
                            obj.Photo = "http://knightapi.turgutyazici.com/uploads/img/" + fileName;
                        }

                    }
                }
            }
            obj.DeleteStatus = false;
            _mobRepository.Update(obj);
            return obj;
        }


        [HttpPut]
        public IActionResult Put([FromBody] Mob obj)
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
                _mobRepository.Update(obj);
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
                _mobRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}