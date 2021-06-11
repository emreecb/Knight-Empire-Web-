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
    public class AreaController : Controller
    {
        private IAreaRepository _areaRepository;
        private readonly IHostingEnvironment _appEnvironment;

        public AreaController(IAreaRepository areaRepository, IHostingEnvironment appEnvironment)
        {
            _areaRepository = areaRepository;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IEnumerable<Area> Get()
        {
            var model = _areaRepository.GetMany(x=>x.DeleteStatus==false);
            return model;
        }

        [HttpGet("{id}")]
        public Area Get(int id)
        {
            return _areaRepository.Get(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Area obj)
        {
            try
            {
                _areaRepository.Insert(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch]
        public Area Patch(Area obje)
        {
            var obj = _areaRepository.Get(x => x.Id == obje.Id);
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
            obj.UpdateTime = DateTime.Now;
            _areaRepository.Update(obj);
            return obj;
        }


        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Area obj)
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
                _areaRepository.Update(obj);
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
                _areaRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}