using System.Collections.Generic;
using System.Web.Mvc;
using MunzeeInMap.MunzeeAppObjects;

namespace MunzeeInMap.Controllers
{
    public class ClanBattleController : Controller
    {
        private string defaultToken = "YaEijcDcJ0iLo2j8XOGvmrYuQXSn8qw19t3vOtL8";
        string cookieName = "bassnick_munzee_in_map";
        string cookieNameId = "bassnick_munzee_in_map_userId";

        //
        // GET: /Klani/
        public ActionResult Klani()
        {
            List<Clan1705> clans = new List<Clan1705>();

            var czech = ConcreteClanResults1705("CzechTeam", 149, 5);
            clans.Add(czech);

            var top = ConcreteClanResults1705("Top.CZ", 591, 4);
            clans.Add(top);

            var munzeeMania = ConcreteClanResults1705("MunzeeMania.cs.cz", 80, 3);
            clans.Add(munzeeMania);
            
            var klando = ConcreteClanResults1705("KLANdo", 927, 3);
            clans.Add(klando);

            var top2 = ConcreteClanResults1705("Top.CZ 2", 719, 2);
            clans.Add(top2);

            var ostrava = ConcreteClanResults1705("Ostrava!!!", 561, 2);
            clans.Add(ostrava);

            var sharks = ConcreteClanResults1705("SHARKS", 497, 2);
            clans.Add(sharks);

            
            var renegati = ConcreteClanResults1705("Renegades.CZ", 955, 2);
            clans.Add(renegati);


            //var topRezervy = ConcreteClanResults1705("TopRezervy.CZ", 906, 2);
            //clans.Add(topRezervy);

            var bazanti = ConcreteClanResults1705("Bažanti", 442, 1);
            clans.Add(bazanti);

            var topRelax = ConcreteClanResults1705("TopRelax.CZ", 896, 1);
            clans.Add(topRelax);

            
            
            return View("Klani", "", clans);
        }

        private Clan1705 ConcreteClanResults1705(string clanName, int clanId, int declaredLevel)
        {
            FormCollection fd = new FormCollection();
            fd.Add("access_token", defaultToken);
            fd.Add("clan_id", clanId.ToString());
            string clanStat = Communicate.GetClanStatistics(fd);
            Battle1705 resultBattle = new Battle1705(clanStat, declaredLevel);

            if (resultBattle.finalLevel == 0 && Request.Cookies[cookieName] != null && Request.Cookies[cookieNameId] != null)
            {
                FormCollection fd2 = new FormCollection();
                fd2.Add("access_token", Request.Cookies[cookieName].Value);
                fd2.Add("clan_id", clanId.ToString());
                clanStat = Communicate.GetClanStatistics(fd2);
                resultBattle = new Battle1705(clanStat, declaredLevel);
            }
            Clan1705 resultClan = new Clan1705()
            {
                ClanId = clanId,
                ClanName = clanName,
                DetailScore = resultBattle
            };
            return resultClan;
        }


        ////
        //// GET: /Klani/
        //public ActionResult Klani()
        //{
        //    List<NewClan1704> clans = new List<NewClan1704>();

        //    var top = ConcreteClanResults1704("Top.CZ", 591, 5);
        //    clans.Add(top);

        //    var top2 = ConcreteClanResults1704("Top.CZ 2", 719, 5);
        //    clans.Add(top2);

        //    var czech = ConcreteClanResults1704("CzechTeam", 149, 5);
        //    clans.Add(czech);

        //    var munzeeMania = ConcreteClanResults1704("MunzeeMania.cs.cz", 80, 4);
        //    clans.Add(munzeeMania);

        //    var klando = ConcreteClanResults1704("KLANdo", 927, 4);
        //    clans.Add(klando);

        //    var ostrava = ConcreteClanResults1704("Ostrava!!!", 561, 4);
        //    clans.Add(ostrava);

        //    var sharks = ConcreteClanResults1704("SHARKS", 497, 3);
        //    clans.Add(sharks);

        //    var bazanti = ConcreteClanResults1704("Bažanti", 442, 2);
        //    clans.Add(bazanti);

        //    var renegati = ConcreteClanResults1704("Renegades.CZ", 955, 2);
        //    clans.Add(renegati);

        //    var topRelax = ConcreteClanResults1704("TopRelax.CZ", 896, 1);
        //    clans.Add(topRelax);

        //    //var topRezervy = ConcreteClanResults1704("TopRezervy.CZ", 906, 2);
        //    //clans.Add(topRezervy);

        //    return View("Klani", "", clans);
        //}

        //private NewClan1704 ConcreteClanResults1704(string clanName, int clanId, int declaredLevel)
        //{
        //    FormCollection fd = new FormCollection();
        //    fd.Add("access_token", defaultToken);
        //    fd.Add("clan_id", clanId.ToString());
        //    string clanStat = Communicate.GetClanDetails(fd);
        //    NewBattle1704 resultBattle = new NewBattle1704(clanStat, declaredLevel);

        //    if (resultBattle.finalLevel == 0 && Request.Cookies[cookieName] != null && Request.Cookies[cookieNameId] != null)
        //    {
        //        FormCollection fd2 = new FormCollection();
        //        fd2.Add("access_token", Request.Cookies[cookieName].Value);
        //        fd2.Add("clan_id", clanId.ToString());
        //        clanStat = Communicate.GetClanStatistics(fd2);
        //        resultBattle = new NewBattle1704(clanStat, declaredLevel);
        //    }
        //    NewClan1704 resultClan = new NewClan1704()
        //    {
        //        ClanId = clanId,
        //        ClanName = clanName,
        //        DetailScore = resultBattle
        //    };
        //    return resultClan;
        //}


    }
}
