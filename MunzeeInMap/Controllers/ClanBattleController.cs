using System.Collections.Generic;
using System.Web.Mvc;
using MunzeeInMap.MunzeeAppObjects;

namespace MunzeeInMap.Controllers
{
    public class ClanBattleController : Controller
    {
        private string defaultToken = "exzY2t7g8pGRJfkI8oLWRa8Tj0WHG4TrL2Xu0HEx";
        string cookieName = "bassnick_munzee_in_map";
        string cookieNameId = "bassnick_munzee_in_map_userId";

        //
        // GET: /Klani/
        public ActionResult Klani()
        {
            List<Clan1612> clans = new List<Clan1612>();

            var top = ConcreteClanResults1612("Top.CZ", 591, 5);
            clans.Add(top);

            var top2 = ConcreteClanResults1612("Top.CZ 2", 719, 5);
            clans.Add(top2);

            var czech = ConcreteClanResults1612("CzechTeam", 149, 5);
            clans.Add(czech);

            var sharks = ConcreteClanResults1612("SHARKS", 497, 5);
            clans.Add(sharks);

            var klando = ConcreteClanResults1612("KLANdo", 927, 5);
            clans.Add(klando);

            var munzeeMania = ConcreteClanResults1612("MunzeeMania.cs.cz", 80, 3);
            clans.Add(munzeeMania);
            
            var bazanti = ConcreteClanResults1612("Bažanti", 442, 3);
            clans.Add(bazanti);

            var renegati = ConcreteClanResults1612("Renegades.CZ", 955, 2);
            clans.Add(renegati);

            
            //var topRezervy = ConcreteClanResults1612("TopRezervy.CZ", 906, 2);
            //clans.Add(topRezervy);
            

            //var topRelax = ConcreteClanResults1612("TopRelax.CZ", 896, 2);
            //clans.Add(topRelax);

            var ostrava = ConcreteClanResults1612("Ostrava!!!", 561, 1);
            clans.Add(ostrava);

            return View("Klani", "", clans);
        }

        private Clan1612 ConcreteClanResults1612(string clanName, int clanId, int declaredLevel)
        {
            FormCollection fd = new FormCollection();
            fd.Add("access_token", defaultToken);
            fd.Add("clan_id", clanId.ToString());
            string clanStat = Communicate.GetClanStatistics(fd);
            Battle1612 resultBattle = new Battle1612(clanStat, declaredLevel);

            if (resultBattle.finalLevel == 0 && Request.Cookies[cookieName] != null && Request.Cookies[cookieNameId] != null)
            {
                FormCollection fd2 = new FormCollection();
                fd2.Add("access_token", Request.Cookies[cookieName].Value);
                fd2.Add("clan_id", clanId.ToString());
                clanStat = Communicate.GetClanStatistics(fd2);
                resultBattle = new Battle1612(clanStat, declaredLevel);
            }
            Clan1612 resultClan = new Clan1612()
            {
                ClanId = clanId,
                ClanName = clanName,
                DetailScore = resultBattle
            };
            return resultClan;
        }

        /*
        //
        // GET: /Klani/
        public ActionResult Klani()
        {
            List<Clan1611> clans = new List<Clan1611>();

            var top = ConcreteClanResults1611("Top.CZ", 591, 5);
            clans.Add(top);

            var sharks = ConcreteClanResults1611("SHARKS", 497, 5);
            clans.Add(sharks);

            var czech = ConcreteClanResults1611("CzechTeam", 149, 4);
            clans.Add(czech);

            var top2 = ConcreteClanResults1611("Top.CZ 2", 719, 4);
            clans.Add(top2);

            var munzeeMania = ConcreteClanResults1611("MunzeeMania.cs.cz", 80, 3);
            clans.Add(munzeeMania);

            var klando = ConcreteClanResults1611("KLANdo", 927, 3);
            clans.Add(klando);

            var bazanti = ConcreteClanResults1611("Bažanti", 442, 2); 
            clans.Add(bazanti);

            var renegati = ConcreteClanResults1611("Renegades.CZ", 955, 2);
            clans.Add(renegati);

            
            //var topRezervy = ConcreteClanResults1611("TopRezervy.CZ", 906, 2);
            //clans.Add(topRezervy);
            

            var topRelax = ConcreteClanResults1611("TopRelax.CZ", 896, 2);
            clans.Add(topRelax);

            var ostrava = ConcreteClanResults1611("Ostrava!!!", 561, 1);
            clans.Add(ostrava);

            return View("Klani", "", clans);
        }

        private Clan1611 ConcreteClanResults1611(string clanName, int clanId, int declaredLevel)
        {
            FormCollection fd = new FormCollection();
            fd.Add("access_token", defaultToken);
            fd.Add("clan_id", clanId.ToString());
            string clanStat = Communicate.GetClanStatistics(fd);
            Battle1611 resultBattle = new Battle1611(clanStat, declaredLevel);

            if (resultBattle.finalLevel == 0 && Request.Cookies[cookieName] != null && Request.Cookies[cookieNameId] != null)
            {
                FormCollection fd2 = new FormCollection();
                fd2.Add("access_token", Request.Cookies[cookieName].Value);
                fd2.Add("clan_id", clanId.ToString());
                clanStat = Communicate.GetClanStatistics(fd2);
                resultBattle = new Battle1611(clanStat, declaredLevel);
            }
            Clan1611 resultClan = new Clan1611()
            {
                ClanId = clanId,
                ClanName = clanName,
                DetailScore = resultBattle
            };
            return resultClan;
        }
        */
    }
}
