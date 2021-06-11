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
    public class PetController : Controller
    {
        private IPetRepository _petRepository;
        private readonly IHostingEnvironment _appEnvironment;

        public PetController(IPetRepository petRepository, IHostingEnvironment appEnvironment)
        {
            _petRepository = petRepository;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IEnumerable<Pet> Get()
        {
            var model = _petRepository.GetMany(x=>x.DeleteStatus==false);
            return model;
        }

        [HttpGet("{id}")]
        public Pet Get(int id)
        {
            return _petRepository.Get(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Pet obj)
        {
            try
            {
                _petRepository.Insert(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public Pet Patch(Pet obje)
        {
            var obj = _petRepository.Get(x => x.Id == obje.Id);
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
            _petRepository.Update(obj);
            return obj;
        }

        [HttpPut]
        public IActionResult Put([FromBody] Pet obj)
        {
            try
            {
                _petRepository.Update(obj);
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
                var model = _petRepository.Get(x => x.Id == id);
                _petRepository.Remove(model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}