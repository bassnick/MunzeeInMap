using System.Collections.Generic;
using System.Web.Mvc;
using MunzeeInMap.MunzeeAppObjects;

namespace MunzeeInMap.Controllers
{
    public class ClanBattleController : Controller
    {
        private string defaultToken = "X9IAwzIrWBaneF64BBSeIwFRJ8am87Jeur1KQQxF";
        string cookieName = "bassnick_munzee_in_map";
        string cookieNameId = "bassnick_munzee_in_map_userId";

        //
        // GET: /Klani/
        public ActionResult Klani()
        {
            List<NewClan1704> clans = new List<NewClan1704>();

            var top = ConcreteClanResults1704("Top.CZ", 591, 5);
            clans.Add(top);

            var top2 = ConcreteClanResults1704("Top.CZ 2", 719, 5);
            clans.Add(top2);

            var czech = ConcreteClanResults1704("CzechTeam", 149, 5);
            clans.Add(czech);

            var munzeeMania = ConcreteClanResults1704("MunzeeMania.cs.cz", 80, 4);
            clans.Add(munzeeMania);

            var klando = ConcreteClanResults1704("KLANdo", 927, 4);
            clans.Add(klando);

            var ostrava = ConcreteClanResults1704("Ostrava!!!", 561, 4);
            clans.Add(ostrava);

            var sharks = ConcreteClanResults1704("SHARKS", 497, 3);
            clans.Add(sharks);

            var bazanti = ConcreteClanResults1704("Bažanti", 442, 2);
            clans.Add(bazanti);

            var renegati = ConcreteClanResults1704("Renegades.CZ", 955, 2);
            clans.Add(renegati);

            var topRelax = ConcreteClanResults1704("TopRelax.CZ", 896, 1);
            clans.Add(topRelax);

            //var topRezervy = ConcreteClanResults1704("TopRezervy.CZ", 906, 2);
            //clans.Add(topRezervy);
            
            return View("Klani", "", clans);
        }

        private NewClan1704 ConcreteClanResults1704(string clanName, int clanId, int declaredLevel)
        {
            FormCollection fd = new FormCollection();
            fd.Add("access_token", defaultToken);
            fd.Add("clan_id", clanId.ToString());
            string clanStat = Communicate.GetClanDetails(fd);
            NewBattle1704 resultBattle = new NewBattle1704(clanStat, declaredLevel);

            if (resultBattle.finalLevel == 0 && Request.Cookies[cookieName] != null && Request.Cookies[cookieNameId] != null)
            {
                FormCollection fd2 = new FormCollection();
                fd2.Add("access_token", Request.Cookies[cookieName].Value);
                fd2.Add("clan_id", clanId.ToString());
                clanStat = Communicate.GetClanStatistics(fd2);
                resultBattle = new NewBattle1704(clanStat, declaredLevel);
            }
            NewClan1704 resultClan = new NewClan1704()
            {
                ClanId = clanId,
                ClanName = clanName,
                DetailScore = resultBattle
            };
            return resultClan;
        }

        //
        // GET: /Klani/
        //    public ActionResult Klani()
        //    {
        //        List<Clan1703> clans = new List<Clan1703>();

        //        var top = ConcreteClanResults1703("Top.CZ", 591, 5);
        //        clans.Add(top);

        //        var munzeeMania = ConcreteClanResults1703("MunzeeMania.cs.cz", 80, 3);
        //        clans.Add(munzeeMania);

        //        var czech = ConcreteClanResults1703("CzechTeam", 149, 2);
        //        clans.Add(czech);

        //        var klando = ConcreteClanResults1703("KLANdo", 927, 2);
        //        clans.Add(klando);

        //        var sharks = ConcreteClanResults1703("SHARKS", 497, 1);
        //        clans.Add(sharks);

        //        var top2 = ConcreteClanResults1703("Top.CZ 2", 719, 1);
        //        clans.Add(top2);

        //        //var renegati = ConcreteClanResults1703("Renegades.CZ", 955, 1);
        //        //clans.Add(renegati);


        //        //var topRezervy = ConcreteClanResults1703("TopRezervy.CZ", 906, 2);
        //        //clans.Add(topRezervy);


        //        var topRelax = ConcreteClanResults1703("TopRelax.CZ", 896, 1);
        //        clans.Add(topRelax);

        //        var bazanti = ConcreteClanResults1703("Bažanti", 442, 1);
        //        clans.Add(bazanti);

        //        //var ostrava = ConcreteClanResults1703("Ostrava!!!", 561, 1);
        //        //clans.Add(ostrava);

        //        return View("Klani", "", clans);
        //    }

        //    private Clan1703 ConcreteClanResults1703(string clanName, int clanId, int declaredLevel)
        //    {
        //        FormCollection fd = new FormCollection();
        //        fd.Add("access_token", defaultToken);
        //        fd.Add("clan_id", clanId.ToString());
        //        string clanStat = Communicate.GetClanStatistics(fd);
        //        Battle1703 resultBattle = new Battle1703(clanStat, declaredLevel);

        //        if (resultBattle.finalLevel == 0 && Request.Cookies[cookieName] != null && Request.Cookies[cookieNameId] != null)
        //        {
        //            FormCollection fd2 = new FormCollection();
        //            fd2.Add("access_token", Request.Cookies[cookieName].Value);
        //            fd2.Add("clan_id", clanId.ToString());
        //            clanStat = Communicate.GetClanStatistics(fd2);
        //            resultBattle = new Battle1703(clanStat, declaredLevel);
        //        }
        //        Clan1703 resultClan = new Clan1703()
        //        {
        //            ClanId = clanId,
        //            ClanName = clanName,
        //            DetailScore = resultBattle
        //        };
        //        return resultClan;
        //    }
        //
    }
}
