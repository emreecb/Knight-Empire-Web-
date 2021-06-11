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
    public class MarketController : Controller
    {
        private IMarketRepository _marketRepository;
        private readonly IHostingEnvironment _appEnvironment;
        private IPetRepository _petRepository;

        public MarketController(IMarketRepository marketRepository, IHostingEnvironment appEnvironment,IPetRepository petRepository)
        {
            _marketRepository = marketRepository;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IEnumerable<Market> Get()
        {
            var model = _marketRepository.GetMany(x=>x.DeleteStatus==false);
            return model;
        }

        [HttpGet("{id}")]
        public Market Get(int id)
        {
            return _marketRepository.Get(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Market obj)
        {
            try
            {
                _marketRepository.Insert(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public Market Patch(Market obje)
        {
            var obj = _marketRepository.Get(x => x.Id == obje.Id);
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
            _marketRepository.Update(obj);
            return obj;
        }


        [HttpPut]
        public IActionResult Put([FromBody] Market obj)
        {
            try
            {
                _marketRepository.Update(obj);
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
                _marketRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}