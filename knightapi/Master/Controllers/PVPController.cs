using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Master.Infrastructure;
using Master.Model;
using Master.Extensions;
using Microsoft.AspNetCore.Authorization;

namespace Master.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class PVPController : Controller
    {
        private ICharacterDetailsRepository _characterDetailsRepository;
        private IMoneyRepository _moneyRepository;

        public PVPController(ICharacterDetailsRepository characterDetailsRepository, IMoneyRepository moneyRepository)
        {
            _characterDetailsRepository = characterDetailsRepository;
            _moneyRepository = moneyRepository;
        }


        [HttpGet("finduser/{id}")]
        public CharacterDetails FindUser(int id)
        {
            var model = _characterDetailsRepository.GetAll().ToList<CharacterDetails>();
            var user = _characterDetailsRepository.Get(x => x.Id == id);
            CharacterDetails obj = new CharacterDetails();
            while (true)
            {
                Random random = new System.Random();
                int value = random.Next(0, model.Count());
                obj = model[value];
                if (obj != user)
                {
                    break;
                }
            }
            return obj;
        }

        [HttpPost("fight")]
        public Boolean Fight([FromBody] PVP obj)
        {
            var user = _characterDetailsRepository.Get(x => x.Id == obj.UserId);
            var opponent = _characterDetailsRepository.Get(y => y.Id == obj.OpponentId);

            var userdeger = ((100 + user.FlameBonus) / 100) * user.Attack + ((100 + user.LightningBonus) / 100) * user.Health + ((100 + user.GlacierBonus) / 100) * user.Defence + (user.Attack + user.Defence + user.Health);
            var opponentdeger = ((100 + opponent.FlameBonus) / 100) * opponent.Attack + ((100 + opponent.LightningBonus) / 100) * opponent.Health + ((100 + opponent.GlacierBonus) / 100) * opponent.Defence + (opponent.Attack + opponent.Defence + opponent.Health);

            if (userdeger >= opponentdeger)
            {
                user.PvpWon++;
                user.NationalPoint += 50;
                opponent.PvpLost++;
                _characterDetailsRepository.Update(user);
                _characterDetailsRepository.Update(opponent);
                return true;
            }
            else
            {
                user.PvpLost++;
                opponent.PvpWon++;
                _characterDetailsRepository.Update(user);
                _characterDetailsRepository.Update(opponent);
                return false;
            }
        }
    }
}