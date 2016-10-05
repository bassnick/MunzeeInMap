using System.Collections.Generic;
using System.Web.Mvc;
using MunzeeInMap.MunzeeAppObjects;

namespace MunzeeInMap.Controllers
{
    public class ClanBattleController : Controller
    {
        private string defaultToken = "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC";
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

        public ActionResult Klani1609()
        {

            List<Clan1609> clans = new List<Clan1609>();

            var top = ConcreteClanResults1609("Top.CZ", 591, 5);
            clans.Add(top);

            var sharks = ConcreteClanResults1609("SHARKS", 497, 5);
            clans.Add(sharks);

            var czech = ConcreteClanResults1609("CzechTeam", 149, 4);
            clans.Add(czech);

            var klando = ConcreteClanResults1609("KLANdo", 927, 3);
            clans.Add(klando);

            var munzeeMania = ConcreteClanResults1609("MunzeeMania.cs.cz", 80, 3);
            clans.Add(munzeeMania);

            var bazanti = ConcreteClanResults1609("Bažanti", 442, 2);
            clans.Add(bazanti);

            var top2 = ConcreteClanResults1609("Top.CZ 2", 719, 2);
            clans.Add(top2);
            /*
            var ostrava = ConcreteClanResults1609("Ostrava!!!", 561, 2);
            clans.Add(ostrava);
            */
            var renegati = ConcreteClanResults1609("Renegades.CZ", 955, 2);
            clans.Add(renegati);

            /*
            var topRezervy = ConcreteClanResults1609("TopRezervy.CZ", 906, 2);
            clans.Add(topRezervy);
            */

            var topRelax = ConcreteClanResults1609("TopRelax.CZ", 896, 1);
            clans.Add(topRelax);

            return View("Klani1609", "", clans);
        }

        private Clan1609 ConcreteClanResults1609(string clanName, int clanId, int declaredLevel)
        {
            FormCollection fd = new FormCollection();
            fd.Add("access_token", defaultToken);
            fd.Add("clan_id", clanId.ToString());
            string clanStat = Communicate.GetClanStatistics(fd);
            Battle1609 resultBattle = new Battle1609(clanStat, declaredLevel);

            if (resultBattle.finalLevel == 0 && Request.Cookies[cookieName] != null && Request.Cookies[cookieNameId] != null)
            {
                FormCollection fd2 = new FormCollection();
                fd2.Add("access_token", Request.Cookies[cookieName].Value);
                fd2.Add("clan_id", clanId.ToString());
                clanStat = Communicate.GetClanStatistics(fd2);
                resultBattle = new Battle1609(clanStat, declaredLevel);
            }
            Clan1609 resultClan = new Clan1609()
            {
                ClanId = clanId,
                ClanName = clanName,
                DetailScore = resultBattle
            };
            return resultClan;
        }


        //
        // GET: /Klani/
        public ActionResult Klani1608()
        {

            List<Clan1608> clans = new List<Clan1608>();

            var top = ConcreteClanResults1608("Top.CZ", 591, 5);
            clans.Add(top);

            var czech = ConcreteClanResults1608("CzechTeam", 149, 3);
            clans.Add(czech);

            var klando = ConcreteClanResults1608("KLANdo", 927, 2);
            clans.Add(klando);

            var munzeeMania = ConcreteClanResults1608("MunzeeMania.cs.cz", 80, 2);
            clans.Add(munzeeMania);

            var bazanti = ConcreteClanResults1608("Bažanti", 442, 2);
            clans.Add(bazanti);
            
            var top2 = ConcreteClanResults1608("Top.CZ 2", 719, 2);
            clans.Add(top2);

            var ostrava = ConcreteClanResults1608("Ostrava!!!", 561, 2);
            clans.Add(ostrava);
            
            var renegati = ConcreteClanResults1608("Renegades.CZ", 955, 2);
            clans.Add(renegati);

            /*
            var topRezervy = ConcreteClanResults1608("TopRezervy.CZ", 906, 2);
            clans.Add(topRezervy);
            */

            var topRelax = ConcreteClanResults1608("TopRelax.CZ", 896, 1);
            clans.Add(topRelax);

            return View("Klani", "", clans);
        }

        private Clan1608 ConcreteClanResults1608(string clanName, int clanId, int declaredLevel)
        {
            FormCollection fd = new FormCollection();
            fd.Add("access_token", defaultToken);
            fd.Add("clan_id", clanId.ToString());
            string clanStat = Communicate.GetClanStatistics(fd);
            Battle1608 resultBattle = new Battle1608(clanStat, declaredLevel);

            if (resultBattle.finalLevel == 0 && Request.Cookies[cookieName] != null && Request.Cookies[cookieNameId] != null)
            {
                FormCollection fd2 = new FormCollection();
                fd2.Add("access_token", Request.Cookies[cookieName].Value);
                fd2.Add("clan_id", clanId.ToString());
                clanStat = Communicate.GetClanStatistics(fd2);
                resultBattle = new Battle1608(clanStat, declaredLevel);
            }
            Clan1608 resultClan = new Clan1608()
            {
                ClanId = clanId,
                ClanName = clanName,
                DetailScore = resultBattle
            };
            return resultClan;
        }
        
        public ActionResult Klani1607()
        {

            List<Clan1607> clans = new List<Clan1607>();

            var top= ConcreteClanResults1607("Top.CZ", 591, 5);
            clans.Add(top);
            
            var czech = ConcreteClanResults1607("CzechTeam", 149, 4);
            clans.Add(czech);

            var top2 = ConcreteClanResults1607("Top.CZ 2", 719, 3);
            clans.Add(top2);

            var ostrava = ConcreteClanResults1607("Ostrava!!!", 561, 2);
            clans.Add(ostrava);

            var klando = ConcreteClanResults1607("KLANdo", 927, 2);
            clans.Add(klando);

            var munzeeMania = ConcreteClanResults1607("MunzeeMania.cs.cz", 80, 2);
            clans.Add(munzeeMania);

            var bazanti = ConcreteClanResults1607("Bažanti", 442, 2);
            clans.Add(bazanti);

            var renegati = ConcreteClanResults1607("Renegades.CZ", 955, 1);
            clans.Add(renegati);

            /*
            var topRezervy = ConcreteClanResults1607("TopRezervy.CZ", 906, 2);
            clans.Add(topRezervy);
            */
            
            var topRelax = ConcreteClanResults1607("TopRelax.CZ", 896, 1);
            clans.Add(topRelax);
            
            return View("Klani", "", clans);
        }

        private Clan1607 ConcreteClanResults1607(string clanName, int clanId, int declaredLevel)
        {
            FormCollection fd = new FormCollection();
            fd.Add("access_token", defaultToken);
            fd.Add("clan_id", clanId.ToString());
            string clanStat = Communicate.GetClanStatistics(fd);
            Battle1607 resultBattle = new Battle1607(clanStat, declaredLevel);

            if (resultBattle.finalLevel == 0 && Request.Cookies[cookieName] != null && Request.Cookies[cookieNameId] != null)
            {
                FormCollection fd2 = new FormCollection();
                fd2.Add("access_token", Request.Cookies[cookieName].Value);
                fd2.Add("clan_id", clanId.ToString());
                clanStat = Communicate.GetClanStatistics(fd2);
                resultBattle = new Battle1607(clanStat, declaredLevel);
            }
            Clan1607 resultClan = new Clan1607()
            {
                ClanId = clanId,
                ClanName = clanName,
                DetailScore = resultBattle
            };
            return resultClan;
        }

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

            /*
            var topRezervy = ConcreteNewClanResults("TopRezervy.CZ", 906, 2);
            clans.Add(topRezervy);
            */

            var topRelax = ConcreteNewClanResults("TopRelax.CZ", 896, 1);
            clans.Add(topRelax);

            return View("NoveKlani", "", clans);
        }

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

        public ActionResult Klani1606()
        {

            List<Clan1606> clans = new List<Clan1606>();

            var top = ConcreteClanResults1606("Top.CZ", 591, 5);
            clans.Add(top);

            var czech = ConcreteClanResults1606("CzechTeam", 149, 5);
            clans.Add(czech);

            var munzeeMania = ConcreteClanResults1606("MunzeeMania.cs.cz", 80, 5);
            clans.Add(munzeeMania);

            var top2 = ConcreteClanResults1606("Top.CZ 2", 719, 4);
            clans.Add(top2);

            var klando = ConcreteClanResults1606("KLANdo", 927, 3);
            clans.Add(klando);

            var ostrava = ConcreteClanResults1606("Ostrava!!!", 561, 3);
            clans.Add(ostrava);

            var bazanti = ConcreteClanResults1606("Bažanti", 442, 3);
            clans.Add(bazanti);

            var topRezervy = ConcreteClanResults1606("TopRezervy.CZ", 906, 2);
            clans.Add(topRezervy);

            var renedati = ConcreteClanResults1606("Renegades.CZ", 955, 2);
            clans.Add(renedati);

            var topRelax = ConcreteClanResults1606("TopRelax.CZ", 896, 1);
            clans.Add(topRelax);

            return View("Klani", "", clans);
        }

        private Clan1606 ConcreteClanResults1606(string clanName, int clanId, int declaredLevel)
        {
            FormCollection fd = new FormCollection();
            fd.Add("access_token", defaultToken);
            fd.Add("clan_id", clanId.ToString());
            string clanStat = Communicate.GetClanStatistics(fd);
            Battle1606 resultBattle = new Battle1606(clanStat, declaredLevel);

            if (resultBattle.finalLevel == 0 && Request.Cookies[cookieName] != null && Request.Cookies[cookieNameId] != null)
            {
                FormCollection fd2 = new FormCollection();
                fd2.Add("access_token", Request.Cookies[cookieName].Value);
                fd2.Add("clan_id", clanId.ToString());
                clanStat = Communicate.GetClanStatistics(fd2);
                resultBattle = new Battle1606(clanStat, declaredLevel);
            }
            Clan1606 resultClan = new Clan1606()
            {
                ClanId = clanId,
                ClanName = clanName,
                DetailScore = resultBattle
            };
            return resultClan;
        }

        public ActionResult Klani1605()
        {
            List<Clan1605> clans = new List<Clan1605>();

            FormCollection fdTopCZ = new FormCollection();
            fdTopCZ.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdTopCZ.Add("clan_id", "591");
            string topCZ = Communicate.GetClanStatistics(fdTopCZ);
            Battle1605 resultTopCZ = new Battle1605(topCZ, 5);

            clans.Add(new Clan1605()
            {
                ClanId = 591,
                ClanName = "Top.CZ",
                DetailScore = resultTopCZ
            });

            FormCollection fdCzechteam = new FormCollection();
            fdCzechteam.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdCzechteam.Add("clan_id", "149");
            string czechteam = Communicate.GetClanStatistics(fdCzechteam);
            Battle1605 resultCzechTeam = new Battle1605(czechteam, 5);

            clans.Add(new Clan1605()
            {
                ClanId = 149,
                ClanName = "CzechTeam",
                DetailScore = resultCzechTeam
            });

            FormCollection fdMunzeeMania = new FormCollection();
            fdMunzeeMania.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdMunzeeMania.Add("clan_id", "759");
            string munzeeMania = Communicate.GetClanStatistics(fdMunzeeMania);
            Battle1605 resultMunzeeMania = new Battle1605(munzeeMania, 5);

            clans.Add(new Clan1605()
            {
                ClanId = 759,
                ClanName = "MunzeeMania.cs.cz",
                DetailScore = resultMunzeeMania
            });

            FormCollection fdklando = new FormCollection();
            fdklando.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdklando.Add("clan_id", "927");
            string klando = Communicate.GetClanStatistics(fdklando);
            Battle1605 resultklando = new Battle1605(klando, 4);

            clans.Add(new Clan1605()
            {
                ClanId = 927,
                ClanName = "KLANdo",
                DetailScore = resultklando
            });

            FormCollection fdTopCZ2 = new FormCollection();
            fdTopCZ2.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdTopCZ2.Add("clan_id", "719");
            string topCZ2 = Communicate.GetClanStatistics(fdTopCZ2);
            Battle1605 resultTopCZ2 = new Battle1605(topCZ2, 4);

            clans.Add(new Clan1605()
            {
                ClanId = 719,
                ClanName = "Top.CZ 2",
                DetailScore = resultTopCZ2
            });


            FormCollection fdOstrava = new FormCollection();
            fdOstrava.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdOstrava.Add("clan_id", "561");
            string ostrava = Communicate.GetClanStatistics(fdOstrava);
            Battle1605 resultOstrava = new Battle1605(ostrava, 3);

            clans.Add(new Clan1605()
            {
                ClanId = 561,
                ClanName = "Ostrava!!!",
                DetailScore = resultOstrava
            });

            FormCollection fdBazanti = new FormCollection();
            fdBazanti.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdBazanti.Add("clan_id", "442");
            string bazanti = Communicate.GetClanStatistics(fdBazanti);
            Battle1605 resultBazanti = new Battle1605(bazanti, 3);

            clans.Add(new Clan1605()
            {
                ClanId = 442,
                ClanName = "Bažanti",
                DetailScore = resultBazanti
            });

            FormCollection fdtoprezervy = new FormCollection();
            fdtoprezervy.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdtoprezervy.Add("clan_id", "906");
            string rezervy = Communicate.GetClanStatistics(fdtoprezervy);
            Battle1605 resultRezervy = new Battle1605(rezervy, 2);

            clans.Add(new Clan1605()
            {
                ClanId = 906,
                ClanName = "TopRezervy.CZ",
                DetailScore = resultRezervy
            });


            FormCollection fdrenegades = new FormCollection();
            fdrenegades.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdrenegades.Add("clan_id", "955");
            string renegades = Communicate.GetClanStatistics(fdrenegades);
            Battle1605 resultRenegades = new Battle1605(renegades, 3);

            clans.Add(new Clan1605()
            {
                ClanId = 955,
                ClanName = "Renegades.CZ",
                DetailScore = resultRenegades
            });


            FormCollection fdrelax = new FormCollection();
            fdrelax.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdrelax.Add("clan_id", "896");
            string relax = Communicate.GetClanStatistics(fdrelax);
            Battle1605 resultRelax = new Battle1605(relax, 2);

            clans.Add(new Clan1605()
            {
                ClanId = 896,
                ClanName = "TopRelax.CZ",
                DetailScore = resultRelax
            });

            return View("Klani", "", clans);
        }

        public ActionResult Klani1604()
        {

            List<Clan1604> clans = new List<Clan1604>();

            FormCollection fdTopCZ = new FormCollection();
            fdTopCZ.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdTopCZ.Add("clan_id", "591");
            string topCZ = Communicate.GetClanStatistics(fdTopCZ);
            Battle1604 resultTopCZ = new Battle1604(topCZ, 5);

            clans.Add(new Clan1604()
            {
                ClanId = 591,
                ClanName = "Top.CZ",
                DetailScore = resultTopCZ
            });

            FormCollection fdCzechteam = new FormCollection();
            fdCzechteam.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdCzechteam.Add("clan_id", "149");
            string czechteam = Communicate.GetClanStatistics(fdCzechteam);
            Battle1604 resultCzechTeam = new Battle1604(czechteam, 4);

            clans.Add(new Clan1604()
            {
                ClanId = 149,
                ClanName = "CzechTeam",
                DetailScore = resultCzechTeam
            });
            /*
            FormCollection fdTopCZ2 = new FormCollection();
            fdTopCZ2.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdTopCZ2.Add("clan_id", "719");
            string topCZ2 = Communicate.GetClanStatistics(fdTopCZ2);
            Battle1604 resultTopCZ2 = new Battle1604(topCZ2, 3);

            clans.Add(new Clan1604()
            {
                ClanId = 719,
                ClanName = "Top.CZ 2",
                DetailScore = resultTopCZ2
            });
            */
            FormCollection fdklando = new FormCollection();
            fdklando.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdklando.Add("clan_id", "927");
            string klando = Communicate.GetClanStatistics(fdklando);
            Battle1604 resultklando = new Battle1604(klando, 4);

            clans.Add(new Clan1604()
            {
                ClanId = 927,
                ClanName = "KLANdo",
                DetailScore = resultklando
            });

            FormCollection fdOstrava = new FormCollection();
            fdOstrava.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdOstrava.Add("clan_id", "561");
            string ostrava = Communicate.GetClanStatistics(fdOstrava);
            Battle1604 resultOstrava = new Battle1604(ostrava, 3);

            clans.Add(new Clan1604()
            {
                ClanId = 561,
                ClanName = "Ostrava!!!",
                DetailScore = resultOstrava
            });

            FormCollection fdMunzeeMania = new FormCollection();
            fdMunzeeMania.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdMunzeeMania.Add("clan_id", "759");
            string munzeeMania = Communicate.GetClanStatistics(fdMunzeeMania);
            Battle1604 resultMunzeeMania = new Battle1604(munzeeMania, 2);

            clans.Add(new Clan1604()
            {
                ClanId = 759,
                ClanName = "MunzeeMania.cs.cz",
                DetailScore = resultMunzeeMania
            });

            FormCollection fdrenegades = new FormCollection();
            fdrenegades.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdrenegades.Add("clan_id", "955");
            string renegades = Communicate.GetClanStatistics(fdrenegades);
            Battle1604 resultRenegades = new Battle1604(renegades, 2);

            clans.Add(new Clan1604()
            {
                ClanId = 955,
                ClanName = "Renegades.CZ",
                DetailScore = resultRenegades
            });


            FormCollection fdtoprezervy = new FormCollection();
            fdtoprezervy.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdtoprezervy.Add("clan_id", "906");
            string rezervy = Communicate.GetClanStatistics(fdtoprezervy);
            Battle1604 resultRezervy = new Battle1604(rezervy, 3);

            clans.Add(new Clan1604()
            {
                ClanId = 906,
                ClanName = "TopRezervy.CZ",
                DetailScore = resultRezervy
            });


            FormCollection fdBazanti = new FormCollection();
            fdBazanti.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdBazanti.Add("clan_id", "442");
            string bazanti = Communicate.GetClanStatistics(fdBazanti);
            Battle1604 resultBazanti = new Battle1604(bazanti, 3);

            clans.Add(new Clan1604()
            {
                ClanId = 442,
                ClanName = "Bažanti",
                DetailScore = resultBazanti
            });

            FormCollection fdrelax = new FormCollection();
            fdrelax.Add("access_token", "RQWp5YTNQSg4ShNEOEvr1d82zbrXYShYiyi2rGwC");
            fdrelax.Add("clan_id", "896");
            string relax = Communicate.GetClanStatistics(fdrelax);
            Battle1604 resultRelax = new Battle1604(relax, 2);

            clans.Add(new Clan1604()
            {
                ClanId = 896,
                ClanName = "TopRelax.CZ",
                DetailScore = resultRelax
            });

            return View("Klani", "", clans);
        }
    }
}
