using System;
using System.Collections.Generic;
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
    public class ItemLevelController : Controller
    {
        private IItemLevelRepository _itemLevelRepository;
        private readonly IHostingEnvironment _appEnvironment;

        public ItemLevelController(IItemLevelRepository itemLevelRepository, IHostingEnvironment appEnvironment)
        {
            _itemLevelRepository = itemLevelRepository;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IEnumerable<ItemLevel> Get()
        {
            var model = _itemLevelRepository.GetAll();
            return model;
        }

        [HttpGet("{id}")]
        public ItemLevel Get(int id)
        {
            return _itemLevelRepository.Get(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]ItemLevel obj)
        {
            try
            {
                _itemLevelRepository.Insert(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPut]
        public IActionResult Put([FromBody] ItemLevel obj)
        {
            try
            {
                _itemLevelRepository.Update(obj);
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
                var model = _itemLevelRepository.Get(x => x.Id == id);
                _itemLevelRepository.Remove(model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}