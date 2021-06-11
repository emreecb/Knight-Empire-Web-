using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Master.Infrastructure;
using Master.Model;
using Microsoft.AspNetCore.Authorization;

namespace Master.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    public class GiftController : Controller
    {

        private IGiftRepository _giftRepository;

        public GiftController(IGiftRepository giftRepository) {

            _giftRepository = giftRepository;
        }

        [HttpGet]
        public IEnumerable<Gift> getall()
        {
            var model = _giftRepository.GetAll();
            return model;

        }

    }
}