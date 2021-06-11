using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Master.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Master.Model;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Master.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class HaberController : Controller
    {
        private IHaberRepository _haberRepository;
        private readonly IHostingEnvironment _appEnvironment;

        public HaberController(IHaberRepository haberRepository, IHostingEnvironment appEnvironment)
        {
            _haberRepository = haberRepository;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IEnumerable<Haber> Get()
        {
            var model = _haberRepository.GetMany(x => x.DeleteStatus == false && x.Active==true);
            return model;
        }

        [HttpGet("{id}")]
        public Haber Get(int id)
        {
            return _haberRepository.Get(x => x.Id == id && x.DeleteStatus == false && x.Active == true);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Haber obj)
        {
            try
            {
                _haberRepository.Insert(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public Haber Patch(Haber obje)
        {
            var obj = _haberRepository.Get(x => x.Id == obje.Id);
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
                            obj.Picture = "http://localhost:54153/uploads/img/" + fileName;
                        }
                    }
                }
            }
            _haberRepository.Update(obj);
            return obj;
        }


        [HttpPut]
        public IActionResult Put([FromBody] Haber obj)
        {
            try
            {
                if (obj.Id == 0)
                {
                    obj.AddTime = new DateTimeOffset();
                }
                else
                {
                    obj.UpdateTime = new DateTimeOffset();
                }
                _haberRepository.Update(obj);
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
                _haberRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}