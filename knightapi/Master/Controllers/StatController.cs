using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Master.Infrastructure;
using Microsoft.AspNetCore.Authorization;

namespace Master.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class StatController : Controller
    {
        private ICharacterDetailsRepository _characterDetailsRepository;
        private IInventoryRepository _inventoryRepository;
        private IItemRepository _itemRepository;
        private IPetRepository _petRepository;
        private ICharacterLevelRepository _characterLevelRepository;


        public StatController(ICharacterDetailsRepository characterDetailsRepository, IInventoryRepository inventoryRepository,
            IItemRepository itemRepository, IPetRepository petRepository, ICharacterLevelRepository characterLevelRepository
        )
        {
            _inventoryRepository = inventoryRepository;
            _characterDetailsRepository = characterDetailsRepository;
            _itemRepository = itemRepository;
            _petRepository = petRepository;
            _characterLevelRepository = characterLevelRepository;
        }

        [HttpGet("id")]
        public bool statcalc(int id)
        {
            var user = _characterDetailsRepository.Get(x => x.Id == id);
            var item = _inventoryRepository.GetMany(x => x.CharacterDetailsID == id && x.Wearing == true);
            foreach (var obj in item)
            {
                if (obj.ItemId != null)
                    obj.Item = _itemRepository.Get(x => x.Id == obj.ItemId);
                if (obj.PetId != null)
                    obj.Pet = _petRepository.Get(x => x.Id == obj.PetId);
            }
            var level = _characterLevelRepository.Get(x => x.Level == user.CharacterLevel);

            user.Attack = level.BaseStats;
            user.Defence = level.BaseStats;
            user.Health = level.BaseStats;
            user.PoisonBonus = 0;
            user.GlacierBonus = 0;
            user.LightningBonus = 0;
            user.FlameBonus = 0;

            foreach (var obj in item)
            {
                if (obj.PetId != null)
                {
                    user.Attack += obj.Pet.AttackBonus;
                    user.Defence += obj.Pet.DefenceBonus;
                    user.Health += obj.Pet.HealthBonus;

                }
                else
                {
                    user.Attack += (obj.Item.Attack + obj.Item.StatMultiplier * obj.ItemLevel);
                    user.Defence += (obj.Item.Defence + obj.Item.StatMultiplier * obj.ItemLevel);
                    user.Health += (obj.Item.Health + obj.Item.StatMultiplier * obj.ItemLevel);
                    user.PoisonBonus += (obj.Item.PoisonBonus + obj.Item.BonusMultiplier * obj.ItemLevel);
                    user.LightningBonus += (obj.Item.LightningBonus + obj.Item.BonusMultiplier * obj.ItemLevel);
                    user.GlacierBonus += (obj.Item.GlacierBonus + obj.Item.BonusMultiplier * obj.ItemLevel);
                    user.FlameBonus += (obj.Item.FlameBonus + obj.Item.BonusMultiplier * obj.ItemLevel);
                }
            }
            _characterDetailsRepository.Update(user);
            return true;
        }
    }
}