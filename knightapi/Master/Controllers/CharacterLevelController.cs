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
    public class CharacterLevelController : Controller
    {
        private ICharacterLevelRepository _characterLevelRepository;
        private readonly IHostingEnvironment _appEnvironment;

        public CharacterLevelController(ICharacterLevelRepository characterLevelRepository, IHostingEnvironment appEnvironment)
        {
            _characterLevelRepository = characterLevelRepository;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IEnumerable<LevelTable> Get()
        {
            var model = _characterLevelRepository.GetAll();
            return model;
        }

        [HttpGet("{id}")]
        public LevelTable Get(int id)
        {
            return _characterLevelRepository.Get(x => x.Level == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]LevelTable obj)
        {
            try
            {
                _characterLevelRepository.Insert(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] LevelTable obj)
        {
            try
            {
                _characterLevelRepository.Update(obj);
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
                _characterLevelRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}