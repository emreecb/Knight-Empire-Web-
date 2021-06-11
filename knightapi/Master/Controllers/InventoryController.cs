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
    public class InventoryController : Controller
    {
        private IInventoryRepository _inventoryRepository;
        private readonly IHostingEnvironment _appEnvironment;
        private IItemRepository _itemRepository;
        private IItemLevelRepository _itemLevelRepository;
        private IPetRepository _petRepository;
        private ICharacterDetailsRepository _characterDetailsRepository;
        private ICharacterLevelRepository _characterLevelRepository;
        
        public InventoryController(IInventoryRepository inventoryRepository, ICharacterLevelRepository characterLevelRepository, ICharacterDetailsRepository characterDetailsRepository, IPetRepository petRepository, IHostingEnvironment appEnvironment, IItemRepository itemRepository, IItemLevelRepository itemLevelRepository)
        {
            _inventoryRepository = inventoryRepository;
            _appEnvironment = appEnvironment;
            _itemRepository = itemRepository;
            _itemLevelRepository = itemLevelRepository;
            _petRepository = petRepository;
            _characterDetailsRepository = characterDetailsRepository;
            _characterLevelRepository = characterLevelRepository;

        }
        [HttpGet]
        public IEnumerable<Inventory> Get()
        {
            var model = _inventoryRepository.GetAll();
            return model;
        }

        [HttpGet("{id}")]
        public IEnumerable<Inventory> Get(int id)
        {
            var model = _inventoryRepository.GetMany(x => x.CharacterDetailsID == id && x.DeleteStatus == false && x.PetId==null);
            foreach (var obj in model)
            {
                if (obj.ItemId != null)
                    obj.Item = _itemRepository.Get(x => x.Id == obj.ItemId);
                if (obj.PetId != null)
                    obj.Pet = _petRepository.Get(x => x.Id == obj.PetId);
            }
            return model;
        }

        [HttpGet("pet/{id}")]
        public IActionResult getpet(int id)
        {
            try
            {
                var model = _inventoryRepository.Get(x => x.CharacterDetailsID == id && x.PetId != null && x.DeleteStatus == false);
                if (model != null)
                {
                    model.Pet = _petRepository.Get(x => x.Id == model.PetId);

                }
                else
                {
                    model = new Inventory();
                    model.Active = true;
                    model.DeleteStatus = false;
                }
                return Ok(model);
            }
            catch
            {
                var model = new Inventory();
                return Ok(model);
            }

        }

        [HttpPost]
        public IActionResult Post([FromBody]Inventory obj)
        {
            try
            {
                _inventoryRepository.Insert(obj);
                var cont = new StatController(_characterDetailsRepository, _inventoryRepository, _itemRepository, _petRepository, _characterLevelRepository);
                cont.ControllerContext = ControllerContext;
                var id = Convert.ToInt32(obj.CharacterDetailsID);
                cont.statcalc(id);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }



        // PUT api/values/5
        [HttpPut]
        public IActionResult Put([FromBody] Inventory obj)
        {
            try
            {
                _inventoryRepository.Update(obj);
                var cont = new StatController(_characterDetailsRepository, _inventoryRepository, _itemRepository, _petRepository,_characterLevelRepository);
                cont.ControllerContext = ControllerContext;
                var id = Convert.ToInt32(obj.CharacterDetailsID);
                cont.statcalc(id);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPut("takeof")]
        public IActionResult Puttakeof([FromBody] Inventory obj)
        {
            try
            {
                obj.Wearing = false;
                _inventoryRepository.Update(obj);
                var cont = new StatController(_characterDetailsRepository, _inventoryRepository, _itemRepository, _petRepository, _characterLevelRepository);
                cont.ControllerContext = ControllerContext;
                var id = Convert.ToInt32(obj.CharacterDetailsID);
                cont.statcalc(id);
                return Ok(obj);
            }
            catch
            {
                return BadRequest();
            }
        }


        [HttpPut("wear")]
        public IActionResult Putwear([FromBody] Inventory obj)
        {
            try
            {
                obj.Wearing = true;
                var wearobj = _inventoryRepository.Get(x => x.CharacterDetailsID == obj.CharacterDetailsID && x.ItemType == obj.ItemType && x.Wearing == true && x.DeleteStatus == false);
                if (wearobj != null)
                {
                    wearobj.Wearing = false;
                    _inventoryRepository.Update(wearobj);
                }
                _inventoryRepository.Update(obj);
                var cont = new StatController(_characterDetailsRepository, _inventoryRepository, _itemRepository, _petRepository, _characterLevelRepository);
                cont.ControllerContext = ControllerContext;
                var id = Convert.ToInt32(obj.CharacterDetailsID);
                cont.statcalc(id);
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
                var model = _inventoryRepository.Get(x => x.Id == id);
                _inventoryRepository.Remove(model);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}