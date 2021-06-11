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
    public class SliderController : Controller
    {
        private ISliderRepository _sliderRepository;
        private readonly IHostingEnvironment _appEnvironment;

        public SliderController(ISliderRepository sliderRepository, IHostingEnvironment appEnvironment)
        {
            _sliderRepository = sliderRepository;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IEnumerable<Slider> Get()
        {
            var model = _sliderRepository.GetMany(x => x.DeleteStatus == false);
            return model;
        }

        [HttpGet("{id}")]
        public Slider Get(int id)
        {
            return _sliderRepository.Get(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Slider obj)
        {
            try
            {
                obj.DeleteStatus = false;
                obj.Active = true;
                obj.CreateTime = DateTime.Now;
                _sliderRepository.Insert(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public Slider Patch(Slider marka)
        {
            var obj = _sliderRepository.Get(x => x.Id == marka.Id);
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
            _sliderRepository.Update(obj);
            return obj;
        }


        [HttpPut]
        public IActionResult Put([FromBody] Slider obj)
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
                _sliderRepository.Update(obj);
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
                _sliderRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}