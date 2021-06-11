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
    public class MoneyController : Controller
    {
        private IMoneyRepository _moneyRepository;
        private readonly IHostingEnvironment _appEnvironment;

        public MoneyController(IMoneyRepository moneyRepository, IHostingEnvironment appEnvironment)
        {
            _moneyRepository = moneyRepository;
            _appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IEnumerable<Money> Get()
        {
            var model = _moneyRepository.GetAll();
            return model;
        }

        [HttpGet("{id}")]
        public Money Get(int id)
        {
            return _moneyRepository.Get(x => x.CharacterDetailsId == id);
        }

        [HttpPost]
        public IActionResult Post([FromBody]Money obj)
        {
            try
            {
                _moneyRepository.Insert(obj);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

      
        [HttpPut]
        public IActionResult Put([FromBody] Money obj)
        {
            try
            {
                _moneyRepository.Update(obj);
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
                _moneyRepository.Delete(id);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}