using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FLS;
using FLS.Rules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Master.Infrastructure;
using Master.Model;
using Microsoft.AspNetCore.Authorization;

namespace Master.Repository
{
    [Route("api/[controller]")]
    [Authorize]
    public class FuzzyController : Controller
    {
        private ICharacterDetailsRepository _repository;
        private IRutbeRepository _rutbeRepository;

        public FuzzyController (ICharacterDetailsRepository repository,IRutbeRepository rutbeRepository)
        {
            _repository = repository;
            _rutbeRepository = rutbeRepository;
        }

        [HttpGet("{characterId}")]
        public Rutbe Fuzzy(int characterId)
        {
            var model = _repository.Get(x => x.Id == characterId);
            var id = model.Attack + model.Defence + model.Health;

            //character'e yakın statlarda bulunan moblar
            var statPoint = new LinguisticVariable("StatPoint");
            var zombie = statPoint.MembershipFunctions.AddTrapezoid("Zombie", 0, 0, 630, 1030);
            var smilodon = statPoint.MembershipFunctions.AddTriangle("Smilodon", 730, 1530, 2010);
            var orcwatcher = statPoint.MembershipFunctions.AddTriangle("OrcWatcher", 1710, 2235, 2760);
            var sabertooth = statPoint.MembershipFunctions.AddTriangle("SaberTooth", 2460, 3635, 4410);
            var hornet = statPoint.MembershipFunctions.AddTriangle("Hornet", 4110, 5115, 6015);
            var dts = statPoint.MembershipFunctions.AddTriangle("Dts", 5715, 6530, 7150);
            var haunga = statPoint.MembershipFunctions.AddTriangle("Haunga", 6850, 7995, 8940);
            var troll = statPoint.MembershipFunctions.AddTriangle("Troll", 8640, 9140, 9440);
            var titan = statPoint.MembershipFunctions.AddTriangle("Titan", 9140, 9940, 10740);
            var felankor = statPoint.MembershipFunctions.AddTriangle("Felankor", 10340, 20000, 30000);


            //güce göre belirlenmiş rütbeler
            var powerofChar = new LinguisticVariable("Power of Character");
            var er = powerofChar.MembershipFunctions.AddTriangle("er", 0, 6, 12);
            var cavus = powerofChar.MembershipFunctions.AddTriangle("cavus", 9, 16, 22);
            var subay = powerofChar.MembershipFunctions.AddTriangle("subay", 19, 26, 32);
            var tegmen = powerofChar.MembershipFunctions.AddTriangle("tegmen", 29, 36, 42);
            var yuzbasi = powerofChar.MembershipFunctions.AddTriangle("yuzbasi", 39, 46, 52);
            var binbasi = powerofChar.MembershipFunctions.AddTriangle("binbasi", 49, 56, 62);
            var yarbay = powerofChar.MembershipFunctions.AddTriangle("yarbay", 59, 66, 72);
            var albay = powerofChar.MembershipFunctions.AddTriangle("albay", 69, 76, 82);
            var amiral = powerofChar.MembershipFunctions.AddTriangle("amiral", 80, 86, 92);
            var general = powerofChar.MembershipFunctions.AddTriangle("general", 89, 95, 100);

            IFuzzyEngine fuzzyEngine = new FuzzyEngineFactory().Default();

            //güçler ve rütbelerin bir kurala bağlanması
            var rule1 = Rule.If(statPoint.Is(zombie)).Then(powerofChar.Is(er));
            var rule2 = Rule.If(statPoint.Is(smilodon)).Then(powerofChar.Is(cavus));
            var rule3 = Rule.If(statPoint.Is(orcwatcher)).Then(powerofChar.Is(subay));
            var rule4 = Rule.If(statPoint.Is(sabertooth)).Then(powerofChar.Is(tegmen));
            var rule5 = Rule.If(statPoint.Is(hornet)).Then(powerofChar.Is(yuzbasi));
            var rule6 = Rule.If(statPoint.Is(dts)).Then(powerofChar.Is(binbasi));
            var rule7 = Rule.If(statPoint.Is(haunga)).Then(powerofChar.Is(yarbay));
            var rule8 = Rule.If(statPoint.Is(troll)).Then(powerofChar.Is(albay));
            var rule9 = Rule.If(statPoint.Is(titan)).Then(powerofChar.Is(amiral));
            var rule10 = Rule.If(statPoint.Is(felankor)).Then(powerofChar.Is(general));
            fuzzyEngine.Rules.Add(rule1, rule2, rule3, rule4, rule5, rule6, rule7, rule8, rule9, rule10);

            var result = fuzzyEngine.Defuzzify(new { statPoint = id });
            var sonuc = _rutbeRepository.Get(x => x.Min < result && x.Max >= result);
            return sonuc;
        }
    }
}