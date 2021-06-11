using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Master.Infrastructure;
using Master.Model;
using Master.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Master.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class AcilisBildirimController : Controller
    {
        private IAcilisBildirimRepository _acilisBildirimRepository;
        private readonly IHostingEnvironment _appEnvironment;

        public AcilisBildirimController(IAcilisBildirimRepository acilisBildirimRepository, IHostingEnvironment appEnvironment)
        {
            _acilisBildirimRepository = acilisBildirimRepository;
            _appEnvironment = appEnvironment;
        }
        [HttpGet]
        public IEnumerable<AcilisBildirim> Get()
        {
            var model = _acilisBildirimRepository.GetMany(x => x.DeleteStatus == false);
            return model;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public AcilisBildirim Get(int id)
        {
            return _acilisBildirimRepository.Get(x => x.Id == id);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody]AcilisBildirim obj)
        {
            try
            {
                obj.DeleteStatus = false;
                obj.Active = true;
                obj.CreateTime = DateTime.Now;
                _acilisBildirimRepository.Insert(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public AcilisBildirim Patch(AcilisBildirim obje)
        {
            var obj = _acilisBildirimRepository.Get(x => x.Id == obje.Id);
            var files = HttpContext.Request.Form.Files;
            foreach (var Image in files)
            {
                if (Image != null && Image.Length > 0)
                {
                    var file = Image;
                    //There is an error here
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
            obj.Active = true;
            obj.CreateTime = DateTime.Now;
            _acilisBildirimRepository.Update(obj);
            return obj;
        }


        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] AcilisBildirim obj)
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
                _acilisBildirimRepository.Update(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //_acilisBildirimRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}