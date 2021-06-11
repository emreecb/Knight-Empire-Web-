using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Master.Infrastructure;
using Master.Extensions;
using Master.Model;
using Microsoft.AspNetCore.Authorization;

namespace Master.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class BattleController : Controller
    {
        private IMobRepository _mobRepository;
        private ICharacterDetailsRepository _characterDetailsRepository;
        private IItemRepository _itemRepository;
        private IMoneyRepository _moneyRepository;
        private IInventoryRepository _inventoryRepository;
        private ICharacterLevelRepository _characterLevelRepository;
        private IPetRepository _petRepository;
        private IGiftRepository _giftRepository;
        private BattleResult result = new BattleResult();
        Gift gift = new Gift();

        public BattleController(IMobRepository mobRepository,
            IMoneyRepository moneyRepository, IInventoryRepository inventoryRepository, IGiftRepository giftRepository,
            ICharacterLevelRepository characterLevelRepository,IPetRepository petRepository,
            IItemRepository itemRepository, ICharacterDetailsRepository characterDetailsRepository)
        {
            _mobRepository = mobRepository;
            _giftRepository = giftRepository;
            _characterDetailsRepository = characterDetailsRepository;
            _petRepository = petRepository;
            _itemRepository = itemRepository;
            _moneyRepository = moneyRepository;
            _inventoryRepository = inventoryRepository;
            _characterLevelRepository = characterLevelRepository;

        }

        [HttpPost]
        public BattleResult battle([FromBody] BattleModel obj)
        {
            gift.Mana = 0;
            var mob = _mobRepository.Get(x => x.Id == obj.MobId);
            var character = _characterDetailsRepository.Get(y => y.Id == obj.CharacterId);
            int? mobstat = 0;
            int? characterstat = 0;
            mobstat += (mob.Attack + mob.Defense + mob.Health);
            characterstat += (character.Attack + character.Health + character.Defence);

            if (characterstat >= mobstat)
            {
                result = battleResult(obj.MobId);
                coincalc(result.Coin, character.Id);
                expcalc(result.Exp, character.Id);
                if (result.Item != null)
                    itemcalc(result.Item, character.Id);

                character.Mana = character.Mana - mob.ManaValue;
                character.Mana += gift.Mana;
                if (character.Mana > 100)
                    character.Mana = 100;
                character.MobWon += 1;
                _characterDetailsRepository.Update(character);

            }
            else
            {
                character.MobLost += 1;

                character.Mana = character.Mana - mob.ManaValue;
                _characterDetailsRepository.Update(character);

            }


            return result;



        }

        private BattleResult battleResult(int id)
        {
            BattleResult result = new BattleResult();
            var mob = _mobRepository.Get(x => x.Id == id);

            Random random = new System.Random();
            int value = random.Next(mob.MinExp, mob.MaxExp);
            result.Exp = value;
            int value2 = random.Next(mob.MinCoin, mob.MaxCoin);
            result.Coin = value2;
            int value3 = random.Next(0, 100);
            if (value3 <= mob.Drop)
            {
                var list = _itemRepository.GetMany(x => x.DropGroup == mob.DropGroup).ToList<Item>();
                int r = random.Next(list.Count);
                result.Item = list[r].Id;

            }
            else
            {
                result.Item = null;
            }
            result.level = false;

            return result;
        }

        private IActionResult coincalc(int coin, int id)
        {
            var model = _moneyRepository.Get(x => x.CharacterDetailsId == id);
            model.Coin += coin;
            _moneyRepository.Update(model);
            return Ok();

        }

        private IActionResult expcalc(int exp, int id)
        {
            var model = _characterDetailsRepository.Get(x => x.Id == id);
            model.Experience += exp;
            var degisken = false;
            while (true)
            {
                var levelobj = _characterLevelRepository.Get(x => x.Level == model.CharacterLevel);
                result.level = false;
                
                if (model.Experience >= levelobj.Experience)
                {
                    model.Experience = model.Experience - levelobj.Experience;
                    model.CharacterLevel++;
                    if (model.CharacterLevel % 10 == 0)
                    {
                        gift = _giftRepository.Get(x => x.Level == model.CharacterLevel);
                        var money = _moneyRepository.Get(x => x.CharacterDetailsId == id);
                        money.Coin += gift.Coin;
                        money.KnightPoint = gift.KPoint;
                        _moneyRepository.Update(money);
                    }
                    degisken = true;
                    result.level = true;
                }
                else
                    break;
            }

            if (degisken)
            {
                var cont = new StatController(_characterDetailsRepository, _inventoryRepository, _itemRepository, _petRepository, _characterLevelRepository);
                cont.ControllerContext = ControllerContext;
                cont.statcalc(id);
            }

            _characterDetailsRepository.Update(model);


            return Ok();
        }

        private IActionResult itemcalc(int? item, int id)
        {
            Inventory inn = new Inventory();
            var model = _itemRepository.Get(x => x.Id == item);
            inn.CharacterDetailsID = id;
            inn.Active = true;
            inn.CreateTime = new DateTime();
            inn.DeleteStatus = false;
            inn.ItemId = item;
            inn.Wearing = false;
            inn.ItemLevel = 1;
            inn.ItemType = model.ItemType;
            _inventoryRepository.Update(inn);
            return Ok();

        }


    }
}