using System.Collections.Generic;
using System.Web.Mvc;
using MunzeeInMap.MunzeeAppObjects;

namespace MunzeeInMap.Controllers
{
    public class ClanBattleController : Controller
    {
        private string defaultToken = "EBlSpSxFAZJ6cZ2q4em10sHIr8a7AxT6FuyaAAvc";
        string cookieName = "bassnick_munzee_in_map";
        string cookieNameId = "bassnick_munzee_in_map_userId";

        //
        // GET: /Klani/
        public ActionResult Klani()
        {
            List<Clan1710> clans = new List<Clan1710>();

            var top = ConcreteClanResults1710("Top.CZ", 591, 5);
            clans.Add(top);

            var czech = ConcreteClanResults1710("CzechTeam", 149, 5);
            clans.Add(czech);
            //var top2 = ConcreteClanResults1710("Top.CZ 2", 719, 5);
            //clans.Add(top2);

            var sharks = ConcreteClanResults1710("SHARKS", 497, 4);
            clans.Add(sharks);
            
            var munzeeMania = ConcreteClanResults1710("MunzeeMania.cs.cz", 80, 3);
            clans.Add(munzeeMania);

            var klando = ConcreteClanResults1710("KLANdo", 927, 2);
            clans.Add(klando);

            var bazanti = ConcreteClanResults1710("Bažanti", 442, 2);
            clans.Add(bazanti);

            var renegati = ConcreteClanResults1710("Renegades.CZ", 955, 1);
            clans.Add(renegati);

            var topRelax = ConcreteClanResults1710("TopRelax.CZ", 896, 1);
            clans.Add(topRelax);

            
            
            
            
            
            //var ostrava = ConcreteClanResults1710("Ostrava!!!", 561, 2);
            //clans.Add(ostrava);

            


            //var topRezervy = ConcreteClanResults1710("TopRezervy.CZ", 906, 2);
            //clans.Add(topRezervy);


            
            
            return View("Klani", "", clans);
        }

        private Clan1710 ConcreteClanResults1710(string clanName, int clanId, int declaredLevel)
        {
            FormCollection fd = new FormCollection();
            fd.Add("access_token", defaultToken);
            fd.Add("clan_id", clanId.ToString());
            string clanStat = Communicate.GetClanStatistics(fd);
            Battle1710 resultBattle = new Battle1710(clanStat, declaredLevel);

            if (resultBattle.finalLevel == 0 && Request.Cookies[cookieName] != null && Request.Cookies[cookieNameId] != null)
            {
                FormCollection fd2 = new FormCollection();
                fd2.Add("access_token", Request.Cookies[cookieName].Value);
                fd2.Add("clan_id", clanId.ToString());
                clanStat = Communicate.GetClanStatistics(fd2);
                resultBattle = new Battle1710(clanStat, declaredLevel);
            }
            Clan1710 resultClan = new Clan1710()
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
        //    List<Clan1709> clans = new List<Clan1709>();

        //    var top = ConcreteClanResults1709("Top.CZ", 591, 5);
        //    clans.Add(top);

        //    var top2 = ConcreteClanResults1709("Top.CZ 2", 719, 4);
        //    clans.Add(top2);

        //    var sharks = ConcreteClanResults1709("SHARKS", 497, 3);
        //    clans.Add(sharks);

        //    var czech = ConcreteClanResults1709("CzechTeam", 149, 3);
        //    clans.Add(czech);

        //    var munzeeMania = ConcreteClanResults1709("MunzeeMania.cs.cz", 80, 3);
        //    clans.Add(munzeeMania);

        //    var klando = ConcreteClanResults1709("KLANdo", 927, 2);
        //    clans.Add(klando);

        //    var renegati = ConcreteClanResults1709("Renegades.CZ", 955, 2);
        //    clans.Add(renegati);

        //    var bazanti = ConcreteClanResults1709("Bažanti", 442, 1);
        //    clans.Add(bazanti);

        //    var topRelax = ConcreteClanResults1709("TopRelax.CZ", 896, 1);
        //    clans.Add(topRelax);






        //    //var ostrava = ConcreteClanResults1709("Ostrava!!!", 561, 2);
        //    //clans.Add(ostrava);




        //    //var topRezervy = ConcreteClanResults1709("TopRezervy.CZ", 906, 2);
        //    //clans.Add(topRezervy);




        //    return View("Klani", "", clans);
        //}

        //private Clan1709 ConcreteClanResults1709(string clanName, int clanId, int declaredLevel)
        //{
        //    FormCollection fd = new FormCollection();
        //    fd.Add("access_token", defaultToken);
        //    fd.Add("clan_id", clanId.ToString());
        //    string clanStat = Communicate.GetClanStatistics(fd);
        //    Battle1709 resultBattle = new Battle1709(clanStat, declaredLevel);

        //    if (resultBattle.finalLevel == 0 && Request.Cookies[cookieName] != null && Request.Cookies[cookieNameId] != null)
        //    {
        //        FormCollection fd2 = new FormCollection();
        //        fd2.Add("access_token", Request.Cookies[cookieName].Value);
        //        fd2.Add("clan_id", clanId.ToString());
        //        clanStat = Communicate.GetClanStatistics(fd2);
        //        resultBattle = new Battle1709(clanStat, declaredLevel);
        //    }
        //    Clan1709 resultClan = new Clan1709()
        //    {
        //        ClanId = clanId,
        //        ClanName = clanName,
        //        DetailScore = resultBattle
        //    };
        //    return resultClan;
        //}
    }
}
