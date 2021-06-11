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
    public class ItemController : Controller
    {
        private IItemRepository _itemRepository;
        private readonly IHostingEnvironment _appEnvironment;

        public ItemController(IItemRepository itemRepository, IHostingEnvironment appEnvironment)
        {
            _itemRepository = itemRepository;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IEnumerable<Item> Get()
        {
            var model = _itemRepository.GetMany(x=>x.DeleteStatus==false);
            return model;
        }

        [HttpGet("{id}")]
        public Item Get(int id)
        {
            return _itemRepository.Get(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Item obj)
        {
            try
            {
                _itemRepository.Insert(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPatch("{id}")]
        public Item Patch(Item obje)
        {
            var obj = _itemRepository.Get(x => x.Id == obje.Id);
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
            _itemRepository.Update(obj);
            return obj;
        }


        [HttpPut]
        public IActionResult Put([FromBody] Item obj)
        {
            try
            {
                _itemRepository.Update(obj);
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
                var model = _itemRepository.Get(x => x.Id == id);
                _itemRepository.Remove(model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}