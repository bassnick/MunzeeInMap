using System.Collections.Generic;
using System.Web.Mvc;
using MunzeeInMap.MunzeeAppObjects;

namespace MunzeeInMap.Controllers
{
    public class ClanBattleController : Controller
    {
        private string defaultToken = "lrj2RzH7kTkQEQwSLmDAbBRWYRtY7Hs9qhIO4OAZ";
        string cookieName = "bassnick_munzee_in_map";
        string cookieNameId = "bassnick_munzee_in_map_userId";

        //
        // GET: /Klani/
        public ActionResult Klani()
        {
            List<Clan1610> clans = new List<Clan1610>();

            var top = ConcreteClanResults1610("Top.CZ", 591, 5);
            clans.Add(top);

            var sharks = ConcreteClanResults1610("SHARKS", 497, 5);
            clans.Add(sharks);

            var czech = ConcreteClanResults1610("CzechTeam", 149, 4);
            clans.Add(czech);

            var top2 = ConcreteClanResults1610("Top.CZ 2", 719, 3);
            clans.Add(top2);

            var munzeeMania = ConcreteClanResults1610("MunzeeMania.cs.cz", 80, 3);
            clans.Add(munzeeMania);

            var bazanti = ConcreteClanResults1610("Bažanti", 442, 2); // možná 3
            clans.Add(bazanti);

            var klando = ConcreteClanResults1610("KLANdo", 927, 2);
            clans.Add(klando);

            /*
            var ostrava = ConcreteClanResults1610("Ostrava!!!", 561, 2);
            clans.Add(ostrava);
            */
            var renegati = ConcreteClanResults1610("Renegades.CZ", 955, 2);
            clans.Add(renegati);

            /*
            var topRezervy = ConcreteClanResults1610("TopRezervy.CZ", 906, 2);
            clans.Add(topRezervy);
            */

            var topRelax = ConcreteClanResults1610("TopRelax.CZ", 896, 1);
            clans.Add(topRelax);

            return View("Klani", "", clans);
        }

        private Clan1610 ConcreteClanResults1610(string clanName, int clanId, int declaredLevel)
        {
            FormCollection fd = new FormCollection();
            fd.Add("access_token", defaultToken);
            fd.Add("clan_id", clanId.ToString());
            string clanStat = Communicate.GetClanStatistics(fd);
            Battle1610 resultBattle = new Battle1610(clanStat, declaredLevel);

            if (resultBattle.finalLevel == 0 && Request.Cookies[cookieName] != null && Request.Cookies[cookieNameId] != null)
            {
                FormCollection fd2 = new FormCollection();
                fd2.Add("access_token", Request.Cookies[cookieName].Value);
                fd2.Add("clan_id", clanId.ToString());
                clanStat = Communicate.GetClanStatistics(fd2);
                resultBattle = new Battle1610(clanStat, declaredLevel);
            }
            Clan1610 resultClan = new Clan1610()
            {
                ClanId = clanId,
                ClanName = clanName,
                DetailScore = resultBattle
            };
            return resultClan;
        }
/*
        public ActionResult NoveKlani()
        {

            List<NewClan1607> clans = new List<NewClan1607>();

            var top = ConcreteNewClanResults("Top.CZ", 591, 5);
            clans.Add(top);

            var czech = ConcreteNewClanResults("CzechTeam", 149, 4);
            clans.Add(czech);

            var top2 = ConcreteNewClanResults("Top.CZ 2", 719, 3);
            clans.Add(top2);

            var ostrava = ConcreteNewClanResults("Ostrava!!!", 561, 2);
            clans.Add(ostrava);

            var klando = ConcreteNewClanResults("KLANdo", 927, 2);
            clans.Add(klando);

            var munzeeMania = ConcreteNewClanResults("MunzeeMania.cs.cz", 80, 2);
            clans.Add(munzeeMania);

            var bazanti = ConcreteNewClanResults("Bažanti", 442, 2);
            clans.Add(bazanti);

            var renegati = ConcreteNewClanResults("Renegades.CZ", 955, 1);
            clans.Add(renegati);

           
           // var topRezervy = ConcreteNewClanResults("TopRezervy.CZ", 906, 2);
           // clans.Add(topRezervy);
            

            var topRelax = ConcreteNewClanResults("TopRelax.CZ", 896, 1);
            clans.Add(topRelax);

            return View("NoveKlani", "", clans);
        }
    */
        private NewClan1607 ConcreteNewClanResults(string clanName, int clanId, int declaredLevel)
        {
            FormCollection fd = new FormCollection();
            fd.Add("access_token", defaultToken);
            fd.Add("clan_id", clanId.ToString());
            string clanDetails = Communicate.GetClanDetails(fd);
            NewBattle1607 resultBattle = new NewBattle1607(clanDetails, declaredLevel);

            if (resultBattle.finalLevel == 0 && Request.Cookies[cookieName] != null && Request.Cookies[cookieNameId] != null)
            {
                FormCollection fd2 = new FormCollection();
                fd2.Add("access_token", Request.Cookies[cookieName].Value);
                fd2.Add("clan_id", clanId.ToString());
                clanDetails = Communicate.GetClanDetails(fd2);
                resultBattle = new NewBattle1607(clanDetails, declaredLevel);
            }
            NewClan1607 resultClan = new NewClan1607()
            {
                ClanId = clanId,
                ClanName = clanName,
                DetailScore = resultBattle
            };
            return resultClan;
        }
    }
}
