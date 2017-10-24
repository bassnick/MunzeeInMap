using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MunzeeInMap.MunzeeAppObjects
{

    public class Clan1710
    {
        public int ClanId { get; set; }
        public string ClanName { get; set; }
        public Battle1710 DetailScore { get; set; }
    }

    public class Battle1710 
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_deployed_greenies = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_captured_greenies = new Dictionary<string, int>(10);
        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);
        public int finalLevel;
        public int actualLevel;

        public Battle1710(string str, int finalLevel)
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

            /* number deployed greenies*/
            int indexOfDepGreen = str.IndexOf("\"number of deployed greenies\":{");

            /* number captured greenies*/
            int indexOfCapGreen = str.IndexOf("\"number of captured greenies\":{");
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

            if (indexOfDepGreen != -1)
            {
                indexOfDepGreen += "\"number of deployed greenies\":{".Length;
                int indexOfEndDepGreen = str.IndexOf('}', indexOfDepGreen);
                string[] NDG = str.Substring(indexOfDepGreen, indexOfEndDepGreen - indexOfDepGreen).Split(',');
                number_deployed_greenies = GetPlayers(NDG);
            }
            if (indexOfCapGreen != -1)
            {
                indexOfCapGreen += "\"number of captured greenies\":{".Length;
                int indexOfEndCapGreen = str.IndexOf('}', indexOfCapGreen);
                string[] NCG = str.Substring(indexOfCapGreen, indexOfEndCapGreen - indexOfCapGreen).Split(',');
                number_captured_greenies = GetPlayers(NCG);
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

    public class Level1710
    {
        public Dictionary<int, Requirements1710> level = new Dictionary<int, Requirements1710>();

        public Level1710()
        {
            level.Add(1, new Requirements1710()
            {
               PlayerPoints = 5000,
               PlayerCapturedGreenies = 10,
               ClanCapturedGreenies = 125,
               ClanDeployedGreenies = 30,
               ClanTotalPoints = 75000
            });
            level.Add(2, new Requirements1710()
            {
                PlayerPoints = 10000,
                PlayerCapturedGreenies = 15,
                ClanCapturedGreenies = 200,
                ClanDeployedGreenies = 60,
                ClanTotalPoints = 125000
            });
            level.Add(3, new Requirements1710()
            {
                PlayerPoints = 17500,
                PlayerCapturedGreenies = 20,
                ClanCapturedGreenies = 300,
                ClanDeployedGreenies = 90,
                ClanTotalPoints = 200000
            });
            level.Add(4, new Requirements1710()
            {
                PlayerPoints = 25000,
                PlayerCapturedGreenies = 25,
                ClanCapturedGreenies = 350,
                ClanDeployedGreenies = 120,
                ClanTotalPoints = 300000
            });
            level.Add(5, new Requirements1710()
            {
                PlayerPoints = 40000,
                PlayerCapturedGreenies = 50,
                ClanCapturedGreenies = 750,
                ClanDeployedGreenies = 300,
                ClanTotalPoints = 450000
            });
        }
    }

    public class Requirements1710
    {
        public int PlayerPoints;
        public int PlayerCapturedGreenies;
        public int ClanCapturedGreenies;
        public int ClanDeployedGreenies;
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