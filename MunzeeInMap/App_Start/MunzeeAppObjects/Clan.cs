using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MunzeeInMap.MunzeeAppObjects
{

    public class Clan1711
    {
        public int ClanId { get; set; }
        public string ClanName { get; set; }
        public Battle1711 DetailScore { get; set; }
    }

    public class Battle1711 
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_deployed_jewels = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_captured_jewels = new Dictionary<string, int>(10);
        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);
        public int finalLevel;
        public int actualLevel;

        public Battle1711(string str, int finalLevel)
        {
            int indexOfResult = str.IndexOf('{', 5) + 1;
            if (indexOfResult == 0)
            {
                return;
            }
            /* deploy */
            int indexOfDeployPts = str.IndexOf("\"deploy\":{");

            /* capture */
            int indexOfCapturePts = str.IndexOf("\"capture\":{");

            /* capture on*/
            int indexOfCaptureOnPts = str.IndexOf("\"capture_on\":{");

            /* total */
            int indexOfTotalPts = str.IndexOf("\"total\":{");

            /* number deployed jewels*/
            int indexOfDepJewels = str.IndexOf("\"number of deployed jewels\":{");

            /* number captured jewels*/
            int indexOfCapJewels = str.IndexOf("\"number of captured jewels\":{");
            if (indexOfDeployPts != -1)
            {
                indexOfDeployPts += "\"deploy\":{".Length;
                int indexOfEndDeployPts = str.IndexOf('}', indexOfDeployPts);

                string[] deployesPts =
                    str.Substring(indexOfDeployPts, indexOfEndDeployPts - indexOfDeployPts).Split(',');
                deploy_points = GetPlayers(deployesPts);
            }

            if (indexOfCaptureOnPts != -1)
            {
                indexOfCaptureOnPts += "\"capture_on\":{".Length;
                int indexOfEndCaptureOnPts = str.IndexOf('}', indexOfCaptureOnPts);
                string[] capturesOnPts =
                    str.Substring(indexOfCaptureOnPts, indexOfEndCaptureOnPts - indexOfCaptureOnPts).Split(',');
                capture_on_points = GetPlayers(capturesOnPts);
            }
            if (indexOfCapturePts != -1)
            {
                indexOfCapturePts += "\"capture\":{".Length;
                int indexOfEndCapturePts = str.IndexOf('}', indexOfCapturePts);
                string[] capturesPts =
                    str.Substring(indexOfCapturePts, indexOfEndCapturePts - indexOfCapturePts).Split(',');
                capture_points = GetPlayers(capturesPts);
            }

            if (indexOfTotalPts != -1)
            {
                indexOfTotalPts += "\"total\":{".Length;
                int indexOfEndTotalPts = str.IndexOf('}', indexOfTotalPts);
                string[] totalsPts = str.Substring(indexOfTotalPts, indexOfEndTotalPts - indexOfTotalPts).Split(',');
                total_points = GetPlayers(totalsPts);

            }

            if (indexOfDepJewels != -1)
            {
                indexOfDepJewels += "\"number of deployed jewels\":{".Length;
                int indexOfEndDepJewels = str.IndexOf('}', indexOfDepJewels);
                string[] NDJ = str.Substring(indexOfDepJewels, indexOfEndDepJewels - indexOfDepJewels).Split(',');
                number_deployed_jewels = GetPlayers(NDJ);
            }
            if (indexOfCapJewels != -1)
            {
                indexOfCapJewels += "\"number of captured jewels\":{".Length;
                int indexOfEndCapJewels = str.IndexOf('}', indexOfCapJewels);
                string[] NCJ = str.Substring(indexOfCapJewels, indexOfEndCapJewels - indexOfCapJewels).Split(',');
                number_captured_jewels = GetPlayers(NCJ);
            }

            List<int> list = total_points.Values.ToList();
            list.Sort();
            list.Reverse();

            for (int i = 0; i < 10; )
            {
                foreach (var playerRecord in total_points)
                {
                    if (i >= list.Count || playerRecord.Value == list[i])
                    {
                        if (!playerOrder.ContainsValue(playerRecord.Key))
                            playerOrder.Add(i + 1, playerRecord.Key);
                        i++;
                    }
                }
            }
            this.finalLevel = finalLevel;
        }
        private static Dictionary<string, int> GetPlayers(string[] jsonString)
        {
            Dictionary<string, int> playersScores = new Dictionary<string, int>(10);
            foreach (var jstr in jsonString)
            {
                string[] d = jstr.Split(':');
                int value;
                int.TryParse(d[1].Trim(new char[] { '"', ' ' }), out value);
                playersScores.Add(d[0].Trim('"'), value);

            }
            return playersScores;
        }
    }

    public class Level1711
    {
        public Dictionary<int, Requirements1711> level = new Dictionary<int, Requirements1711>();

        public Level1711()
        {
            level.Add(1, new Requirements1711()
            {
                PlayerCapturedJewels = 0,
                PlayerPoints = 3500,
               ClanCapturedJewels = 100,
               ClanDeployedJewels = 0,
               ClanTotalPoints = 50000
            });
            level.Add(2, new Requirements1711()
            {
                PlayerCapturedJewels = 0,
                PlayerPoints = 10000,
                ClanCapturedJewels = 200,
                ClanDeployedJewels = 50,
                ClanTotalPoints = 150000
               
            });
            level.Add(3, new Requirements1711()
            {
               PlayerCapturedJewels = 25,
               PlayerPoints = 20000,
               ClanCapturedJewels = 300,
               ClanDeployedJewels = 125,
               ClanTotalPoints = 225000
            });
            level.Add(4, new Requirements1711()
            {
               PlayerCapturedJewels = 35,
               PlayerPoints = 30000,
               ClanCapturedJewels = 400,
               ClanDeployedJewels = 175,
               ClanTotalPoints = 350000
            });
            level.Add(5, new Requirements1711()
            {
               PlayerCapturedJewels = 50,
               PlayerPoints = 40000,
               ClanCapturedJewels = 550,
               ClanDeployedJewels = 250,
               ClanTotalPoints = 450000
            });
        }
    }

    public class Requirements1711
    {
        public int PlayerCapturedJewels;
        public int PlayerPoints;
        public int ClanCapturedJewels;
        public int ClanDeployedJewels;
        public int ClanTotalPoints;
        
        
    }


    //public class Clan1709
    //{
    //    public int ClanId { get; set; }
    //    public string ClanName { get; set; }
    //    public Battle1709 DetailScore { get; set; }
    //}

    //public class Battle1709 /* TODO HERE*/
    //{
    //    public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
    //    public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
    //    public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
    //    public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
    //    public Dictionary<string, int> activity_points = new Dictionary<string, int>(10);

    //    public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

    //    public int finalLevel;
    //    public int actualLevel;

    //    public Battle1709(string str, int finalLevel)
    //    {
    //        int indexOfResult = str.IndexOf('{', 5) + 1;
    //        if (indexOfResult == 0)
    //        {
    //            return;
    //        }
    //        /* deploy */
    //        int indexOfDeployPts = str.IndexOf("\"deploy\":{");

    //        /* capture */
    //        int indexOfCapturePts = str.IndexOf("\"capture\":{");

    //        /* capture on*/
    //        int indexOfCaptureOnPts = str.IndexOf("\"capture_on\":{");

    //        /* total */
    //        int indexOfTotalPts = str.IndexOf("\"total\":{");

    //        /* number deployed greenies*/
    //        int indexOfActPts = str.IndexOf("\"activity points\":{");


    //        if (indexOfDeployPts != -1)
    //        {
    //            indexOfDeployPts += "\"deploy\":{".Length;
    //            int indexOfEndDeployPts = str.IndexOf('}', indexOfDeployPts);

    //            string[] deployesPts =
    //                str.Substring(indexOfDeployPts, indexOfEndDeployPts - indexOfDeployPts).Split(',');
    //            deploy_points = GetPlayers(deployesPts);
    //        }

    //        if (indexOfCaptureOnPts != -1)
    //        {
    //            indexOfCaptureOnPts += "\"capture_on\":{".Length;
    //            int indexOfEndCaptureOnPts = str.IndexOf('}', indexOfCaptureOnPts);
    //            string[] capturesOnPts =
    //                str.Substring(indexOfCaptureOnPts, indexOfEndCaptureOnPts - indexOfCaptureOnPts).Split(',');
    //            capture_on_points = GetPlayers(capturesOnPts);
    //        }
    //        if (indexOfCapturePts != -1)
    //        {
    //            indexOfCapturePts += "\"capture\":{".Length;
    //            int indexOfEndCapturePts = str.IndexOf('}', indexOfCapturePts);
    //            string[] capturesPts =
    //                str.Substring(indexOfCapturePts, indexOfEndCapturePts - indexOfCapturePts).Split(',');
    //            capture_points = GetPlayers(capturesPts);
    //        }

    //        if (indexOfTotalPts != -1)
    //        {
    //            indexOfTotalPts += "\"total\":{".Length;
    //            int indexOfEndTotalPts = str.IndexOf('}', indexOfTotalPts);
    //            string[] totalsPts = str.Substring(indexOfTotalPts, indexOfEndTotalPts - indexOfTotalPts).Split(',');
    //            total_points = GetPlayers(totalsPts);

    //        }

    //        if (indexOfActPts != -1)
    //        {
    //            indexOfActPts += "\"activity points\":{".Length;
    //            int indexOfEndActPts = str.IndexOf('}', indexOfActPts);
    //            string[] AP = str.Substring(indexOfActPts, indexOfEndActPts - indexOfActPts).Split(',');
    //            activity_points = GetPlayers(AP);
    //        }

    //        List<int> list = total_points.Values.ToList();
    //        list.Sort();
    //        list.Reverse();

    //        for (int i = 0; i < 10; )
    //        {
    //            foreach (var playerRecord in total_points)
    //            {
    //                if (i >= list.Count || playerRecord.Value == list[i])
    //                {
    //                    if (!playerOrder.ContainsValue(playerRecord.Key))
    //                        playerOrder.Add(i + 1, playerRecord.Key);
    //                    i++;
    //                }
    //            }
    //        }
    //        this.finalLevel = finalLevel;
    //    }
    //    private static Dictionary<string, int> GetPlayers(string[] jsonString)
    //    {
    //        Dictionary<string, int> playersScores = new Dictionary<string, int>(10);
    //        foreach (var jstr in jsonString)
    //        {
    //            string[] d = jstr.Split(':');
    //            int value;
    //            int.TryParse(d[1].Trim(new char[] { '"', ' ' }), out value);
    //            playersScores.Add(d[0].Trim('"'), value);

    //        }
    //        return playersScores;
    //    }
    //}

    //public class Level1709
    //{
    //    public Dictionary<int, Requirements1709> level = new Dictionary<int, Requirements1709>();

    //    public Level1709()
    //    {
    //        level.Add(1, new Requirements1709()
    //        {
    //            PlayerActivityPoints = 125,
    //            ClanActivityPoints = 2500,
    //            ClanTotalPoints = 30000
    //        });
    //        level.Add(2, new Requirements1709()
    //        {
    //            PlayerActivityPoints = 250,
    //            ClanActivityPoints = 4000,
    //            ClanTotalPoints = 75000
    //        });
    //        level.Add(3, new Requirements1709()
    //        {
    //            PlayerActivityPoints = 500,
    //            ClanActivityPoints = 7500,
    //            ClanTotalPoints = 145000
    //        });
    //        level.Add(4, new Requirements1709()
    //        {
    //            PlayerActivityPoints = 1000,
    //            ClanActivityPoints = 15000,
    //            ClanTotalPoints = 275000
    //        });
    //        level.Add(5, new Requirements1709()
    //        {
    //            PlayerActivityPoints = 2500,
    //            ClanActivityPoints = 40000,
    //            ClanTotalPoints = 450000

    //        });
    //    }
    //}

    //public class Requirements1709
    //{
    //    public int PlayerActivityPoints;
    //    public int ClanActivityPoints;
    //    public int ClanTotalPoints;
    //}

}