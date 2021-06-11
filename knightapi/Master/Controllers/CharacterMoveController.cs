using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Master.Model;
using Master.Infrastructure;
using Master.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Authorization;

namespace Master.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class CharacterMoveController : Controller
    {
        private ICharacterMoveRepository _repository;
        private ICharacterDetailsRepository _characterDetailsRepository;
        private IMoneyRepository _moneyRepository;
        private ICharacterLevelRepository _LevelRepository;
        private IInventoryRepository _inventoryRepository;
        private readonly IHostingEnvironment _appEnvironment;
        private IItemRepository _itemRepository;
        private IItemLevelRepository _itemLevelRepository;
        private IPetRepository _petRepository;
        private IGiftRepository _giftRepository;

        public CharacterMoveController(ICharacterMoveRepository repository,
            ICharacterLevelRepository characterLevelRepository,
            IGiftRepository giftRepository,
            ICharacterDetailsRepository characterDetailsRepository,
            IInventoryRepository inventoryRepository,IHostingEnvironment appEnvironment,
            IItemRepository itemRepository,IItemLevelRepository itemLevelRepository,
            IPetRepository petRepository,
            IMoneyRepository moneyRepository)
        {
            _repository = repository;
            _characterDetailsRepository = characterDetailsRepository;
            _moneyRepository = moneyRepository;
            _LevelRepository = characterLevelRepository;
            _inventoryRepository = inventoryRepository;
            _appEnvironment = appEnvironment;
            _itemRepository = itemRepository;
            _itemLevelRepository = itemLevelRepository;
            _petRepository = petRepository;
            _giftRepository = giftRepository;
            

        }

        [HttpGet("{id}")]
        public CharacterMove getid(int id)
        {
            var model = _repository.Get(x => x.CharacterDetailsId == id && x.DeleteStatus == false);
            return model;
        }

        [HttpPut("sonuclandir")]
        public Boolean sonuclandir([FromBody] movefinish obj)
        {
            var degisken = false;
            var model = _characterDetailsRepository.Get(x => x.Id == obj.id);
            decimal minutes = obj.day * 24 * 60 + obj.hours * 60 + obj.minutes;
            var carpan = Math.Floor(minutes / 2);
            int carpanint = Convert.ToInt32(carpan);
            if (obj.type == 1)
            {
                model.Mana +=  carpanint* 2;
                if (model.Mana > 100)
                    model.Mana = 100;
                _characterDetailsRepository.Update(model);
            }
            else if (obj.type == 2)
            {
                model.Experience += carpanint * 2;
                while (true)
                {
                    var levelexp = _LevelRepository.Get(y => y.Level == model.CharacterLevel);
                    if (model.Experience >= levelexp.Experience)
                    {
                        model.Experience = model.Experience - levelexp.Experience;
                        model.CharacterLevel++;
                        if (model.CharacterLevel % 10 == 0)
                        {
                            var gift = _giftRepository.Get(x => x.Level == model.CharacterLevel);
                            var money = _moneyRepository.Get(x => x.CharacterDetailsId == obj.id);
                            money.Coin += gift.Coin;
                            money.KnightPoint = gift.KPoint;
                            model.Mana += gift.Mana;
                            if (model.Mana > 100)
                            {
                                model.Mana = 100;
                            }
                            _moneyRepository.Update(money);
                        }
                        degisken = true;
                    }
                    else
                        break;
                }
                _characterDetailsRepository.Update(model);

            }
            else
            {
                var money = _moneyRepository.Get(y => y.CharacterDetailsId == obj.id);
                money.Coin += carpanint * 2;
                _moneyRepository.Update(money);
            }
            if (degisken)
            {
                var cont = new StatController(_characterDetailsRepository, _inventoryRepository, _itemRepository, _petRepository, _LevelRepository);
                cont.ControllerContext = ControllerContext;
                cont.statcalc(obj.id);
            }
            var move =_repository.Get(z => z.CharacterDetailsId == obj.id && z.DeleteStatus == false);
            move.DeleteStatus = true;
            _repository.Update(move);

            return true;
        }

        [HttpPut]
        public CharacterMove put([FromBody] CharacterMove obj)
        {
            _repository.Update(obj);
            return obj;
        }

        [HttpDelete("{id}")]
        public IActionResult delet(int id)
        {
            var model = _repository.Get(x => x.CharacterDetailsId == id);
            _repository.Delete(model.Id);
            return Ok();
        }


    }
}