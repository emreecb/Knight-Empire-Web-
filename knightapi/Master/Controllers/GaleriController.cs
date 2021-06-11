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
    public class GaleriController : Controller
    {
        private IGaleriRepository _galeriRepository;
        private readonly IHostingEnvironment _appEnvironment;

        public GaleriController(IGaleriRepository galeriRepository, IHostingEnvironment appEnvironment)
        {
            _galeriRepository = galeriRepository;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IEnumerable<Galeri> Get()
        {
            var model = _galeriRepository.GetMany(x => x.DeleteStatus == false);
            foreach (var item in model)
            {
            }
            return model;
        }

        [HttpGet("{id}")]
        public Galeri Get(int id)
        {
            var model = _galeriRepository.Get(x => x.Id == id);

            return model;
        }

        [HttpPost]
        public IActionResult Post([FromBody]Galeri obj)
        {
            try
            {
                obj.DeleteStatus = false;
                obj.Active = true;
                obj.CreateTime = DateTime.Now;
                _galeriRepository.Insert(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public Galeri Patch(Galeri obje)
        {
            var obj = _galeriRepository.Get(x => x.Id == obje.Id);
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
            obj.Active = true;
            obj.CreateTime = DateTime.Now;
            _galeriRepository.Update(obj);
            return obj;
        }

        [HttpPut]
        public IActionResult Put([FromBody] Galeri obj)
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
                _galeriRepository.Update(obj);
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
                _galeriRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}