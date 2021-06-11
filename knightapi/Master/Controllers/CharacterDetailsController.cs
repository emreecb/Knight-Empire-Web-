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
    public class CharacterDetailsController : Controller
    {
        private ICharacterDetailsRepository _characterDetailsRepository;
        private readonly IHostingEnvironment _appEnvironment;

        public CharacterDetailsController(ICharacterDetailsRepository characterDetailsRepository, IHostingEnvironment appEnvironment)
        {
            _characterDetailsRepository = characterDetailsRepository;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IEnumerable<CharacterDetails> Get()
        {
            var model = _characterDetailsRepository.GetAll();
            model = model.OrderByDescending(o => o.NationalPoint);
            return model;
        }

        [HttpGet("{id}")]
        public CharacterDetails Get(int id)
        {
            return _characterDetailsRepository.Get(x => x.Id == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]CharacterDetails obj)
        {
            try
            {
                _characterDetailsRepository.Insert(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

        
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] CharacterDetails obj)
        {
            try
            {
                _characterDetailsRepository.Update(obj);
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
                _characterDetailsRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}