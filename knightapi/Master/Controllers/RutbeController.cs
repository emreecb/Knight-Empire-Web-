using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Master.Infrastructure;
using Master.Model;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Authorization;

namespace Master.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class RutbeController : Controller
    {
        private IRutbeRepository _rutbeRepository;
        private readonly IHostingEnvironment _appEnvironment;

        public RutbeController(IRutbeRepository rutbeRepository, IHostingEnvironment appEnvironment)
        {
            _rutbeRepository = rutbeRepository;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IEnumerable<Rutbe> Get()
        {
            var model = _rutbeRepository.GetAll();
            return model;
        }

        [HttpGet("{id}")]
        public Rutbe Get(int id)
        {
            return _rutbeRepository.Get(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Rutbe obj)
        {
            try
            {
                _rutbeRepository.Insert(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public Rutbe Patch(Rutbe obje)
        {
            var obj = _rutbeRepository.Get(x => x.Id == obje.Id);
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
                            obj.Logo = "http://localhost:54153/uploads/img/" + fileName;
                        }

                    }
                }
            }
            _rutbeRepository.Update(obj);
            return obj;
        }

        [HttpPut]
        public IActionResult Put([FromBody] Rutbe obj)
        {
            try
            {
                _rutbeRepository.Update(obj);
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
                var model = _rutbeRepository.Get(x => x.Id == id);
            
                _rutbeRepository.Remove(model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}