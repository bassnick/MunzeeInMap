using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MunzeeInMap.MunzeeAppObjects
{



    public class Clan1709
    {
        public int ClanId { get; set; }
        public string ClanName { get; set; }
        public Battle1709 DetailScore { get; set; }
    }

    public class Battle1709 /* TODO HERE*/
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> activity_points = new Dictionary<string, int>(10);

        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1709(string str, int finalLevel)
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
            int indexOfActPts = str.IndexOf("\"activity points\":{");


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

            if (indexOfActPts != -1)
            {
                indexOfActPts += "\"activity points\":{".Length;
                int indexOfEndActPts = str.IndexOf('}', indexOfActPts);
                string[] AP = str.Substring(indexOfActPts, indexOfEndActPts - indexOfActPts).Split(',');
                activity_points = GetPlayers(AP);
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

    public class Clan1705
    {
        public int ClanId { get; set; }
        public string ClanName { get; set; }
        public Battle1705 DetailScore { get; set; }
    }

    public class Battle1705 /* TODO HERE*/
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> activity_points = new Dictionary<string, int>(10);

        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1705(string str, int finalLevel)
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
            int indexOfActPts = str.IndexOf("\"activity_points\":{");


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

            if (indexOfActPts != -1)
            {
                indexOfActPts += "\"activity_points\":{".Length;
                int indexOfEndActPts = str.IndexOf('}', indexOfActPts);
                string[] AP = str.Substring(indexOfActPts, indexOfEndActPts - indexOfActPts).Split(',');
                activity_points = GetPlayers(AP);
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



    public class Clan1704
    {
        public int ClanId { get; set; }
        public string ClanName { get; set; }
        public Battle1704 DetailScore { get; set; }
    }

    public class Battle1704 /* TODO HERE*/
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_deps_green = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_caps_green = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_caps_shamrock = new Dictionary<string, int>(10);

        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1704(string str, int finalLevel)
        {
            int indexOfResult = str.IndexOf('{', 5) + 1;
            if (indexOfResult == 0)
            {
                return;
            }
            /* deploy */
            //int indexOfDeployPts = str.IndexOf("\"deploy\":{");

            /* capture */
            int indexOfCapturePts = str.IndexOf("\"capture\":{");

            /* capture on*/
            //int indexOfCaptureOnPts = str.IndexOf("\"capture_on\":{");

            /* total */
            int indexOfTotalPts = str.IndexOf("\"total\":{");

            /* number deployed greenies*/
            //int indexOfNumberDeploysGreenies = str.IndexOf("\"number of deployed greenies\":{");

            /* number captured greenies*/
            //int indexOfNumberCapturesGreenies = str.IndexOf("\"number of captured greenies\":{");

            /* number captured shamrock*/
            //int indexOfNumberCapturesShamrocks = str.IndexOf("\"number of captured shamrocks\":{");

            //if (indexOfDeployPts != -1)
            //{
            //    indexOfDeployPts += "\"deploy\":{".Length;
            //    int indexOfEndDeployPts = str.IndexOf('}', indexOfDeployPts);

            //    string[] deployesPts =
            //        str.Substring(indexOfDeployPts, indexOfEndDeployPts - indexOfDeployPts).Split(',');
            //    deploy_points = GetPlayers(deployesPts);
            //}

            //if (indexOfCaptureOnPts != -1)
            //{
            //    indexOfCaptureOnPts += "\"capture_on\":{".Length;
            //    int indexOfEndCaptureOnPts = str.IndexOf('}', indexOfCaptureOnPts);
            //    string[] capturesOnPts =
            //        str.Substring(indexOfCaptureOnPts, indexOfEndCaptureOnPts - indexOfCaptureOnPts).Split(',');
            //    capture_on_points = GetPlayers(capturesOnPts);
            //}
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

            //if (indexOfNumberDeploysGreenies != -1)
            //{
            //    indexOfNumberDeploysGreenies += "\"number of deployed greenies\":{".Length;
            //    int indexOfEndNumberDeploysGreenies = str.IndexOf('}', indexOfNumberDeploysGreenies);
            //    string[] NDG = str.Substring(indexOfNumberDeploysGreenies, indexOfEndNumberDeploysGreenies - indexOfNumberDeploysGreenies).Split(',');
            //    number_deps_green = GetPlayers(NDG);
            //}

            //if (indexOfNumberCapturesGreenies != -1)
            //{
            //    indexOfNumberCapturesGreenies += "\"number of captured greenies\":{".Length;
            //    int indexOfEndNumberCapturesGreenies = str.IndexOf('}', indexOfNumberCapturesGreenies);
            //    string[] NCG = str.Substring(indexOfNumberCapturesGreenies, indexOfEndNumberCapturesGreenies - indexOfNumberCapturesGreenies).Split(',');
            //    number_caps_green = GetPlayers(NCG);
            //}
            //if (indexOfNumberCapturesShamrocks != -1)
            //{
            //    indexOfNumberCapturesShamrocks += "\"number of captured shamrocks\":{".Length;
            //    int indexOfEndNumberCapturesShamrocks = str.IndexOf('}', indexOfNumberCapturesShamrocks);
            //    string[] NCS = str.Substring(indexOfNumberCapturesShamrocks, indexOfEndNumberCapturesShamrocks - indexOfNumberCapturesShamrocks).Split(',');
            //    number_caps_shamrock = GetPlayers(NCS);
            //}

            List<int> list = total_points.Values.ToList();
            list.Sort();
            list.Reverse();

            for (int i = 0; i < 10;)
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


    public class NewClan1704
    {
        public int ClanId { get; set; }
        public string ClanName { get; set; }
        public NewBattle1704 DetailScore { get; set; }
    }

    public class NewBattle1704
    {
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
        public List<KeyValuePair<string, int>> sorted_total_points = new List<KeyValuePair<string, int>>(10);
        public Dictionary<string, int> caps_points = new Dictionary<string, int>(10);
        public List<string> usersInfo = new List<string>(10);
        
        public int finalLevel;
        public int actualLevel;

        public NewBattle1704(string str, int finalLevel)
        {

            int indexOfResult = str.IndexOf('{', 5) + 1;
            if (indexOfResult == 0)
            {
                return;
            }
            /* usersinfo */
            for (int i = 0; i < 10; i++)
            {
                int indexOfStartUserInfo = str.IndexOf("{\"username\":", indexOfResult);
                if (indexOfStartUserInfo != -1)
                {
                    indexOfResult = str.IndexOf("}", indexOfStartUserInfo);
                    usersInfo.Add(str.Substring(indexOfStartUserInfo, indexOfResult - indexOfStartUserInfo + "}".Length));
                }
                //else 
                //    usersInfo.Add(null);
            }

            /* total */
            foreach (var tempUser in usersInfo)
            {
                //if (userInfo != null)
                //    continue;
                int indexOfUserName = "{\"username\":\"".Length;
                int indexOfEndUserName = tempUser.IndexOf("\"", indexOfUserName);
                string userName = tempUser.Substring(indexOfUserName, indexOfEndUserName - indexOfUserName);

                int indexOfCapsPts = tempUser.IndexOf("\"capture_points\":");
                if (indexOfCapsPts != -1)
                {
                    indexOfCapsPts += "\"capture_points\":".Length;
                    int indexOfEndCapsPts = tempUser.IndexOf(",", indexOfCapsPts);
                    string totalsPts = tempUser.Substring(indexOfCapsPts, indexOfEndCapsPts - indexOfCapsPts);
                    int cp;
                    int.TryParse(totalsPts, out cp);
                    caps_points.Add(userName, cp);
                }
                else
                {
                    caps_points.Add(userName, 0);
                }

                int indexOfTotalPts = tempUser.IndexOf("\"total_points\":");
                if (indexOfTotalPts != -1)
                {
                    indexOfTotalPts += "\"total_points\":".Length;
                    int indexOfEndTotalPts = tempUser.IndexOfAny(new char[] {',','}'}, indexOfTotalPts);
                    string totalsPts = tempUser.Substring(indexOfTotalPts, indexOfEndTotalPts - indexOfTotalPts);
                    int tp;
                    int.TryParse(totalsPts, out tp);
                    total_points.Add(userName, tp);
                    
                }
                else
                {
                    total_points.Add(userName, 0);
                }
            }
            sorted_total_points = total_points.ToList();

            sorted_total_points.Sort((pair1, pair2) => pair2.Value.CompareTo(pair1.Value));

            

            this.finalLevel = finalLevel;
        }
    }

    
    public class Clan1702
    {
        public int ClanId { get; set; }
        public string ClanName { get; set; }
        public Battle1702 DetailScore { get; set; }
    }

    public class Battle1702 /* TODO HERE*/
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_deps = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_jewels_points = new Dictionary<string, int>(10);

        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1702(string str, int finalLevel)
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

            /* number deployed */
            int indexOfNumberDeploys = str.IndexOf("\"number of deployed\":{");

            /* number of captured recycle icons */
            int indexOfCapturePtsFromJewels = str.IndexOf("\"capture points from jewels\":{");

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

            if (indexOfNumberDeploys != -1)
            {
                indexOfNumberDeploys += "\"number of deployed\":{".Length;
                int indexOfEndNumberDeploys = str.IndexOf('}', indexOfNumberDeploys);
                string[] ND = str.Substring(indexOfNumberDeploys, indexOfEndNumberDeploys - indexOfNumberDeploys).Split(',');
                number_deps = GetPlayers(ND);
            }

            if (indexOfCapturePtsFromJewels != -1)
            {
                indexOfCapturePtsFromJewels += "\"capture points from jewels\":{".Length;
                int indexOfEndCapturePtsFromJewels = str.IndexOf('}', indexOfCapturePtsFromJewels);
                string[] NCJ = str.Substring(indexOfCapturePtsFromJewels, indexOfEndCapturePtsFromJewels - indexOfCapturePtsFromJewels).Split(',');
                capture_jewels_points = GetPlayers(NCJ);
            }


            List<int> list = total_points.Values.ToList();
            list.Sort();
            list.Reverse();

            for (int i = 0; i < 10;)
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

    public class Clan1701
    {
        public int ClanId { get; set; }
        public string ClanName { get; set; }
        public Battle1701 DetailScore { get; set; }
    }

    public class Battle1701 /* TODO HERE*/
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        //public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_deps = new Dictionary<string, int>(10);
        //public Dictionary<string, int> number_deps_green = new Dictionary<string, int>(10);
        //public Dictionary<string, int> number_caps = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_caps_recycled = new Dictionary<string, int>(10);

        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1701(string str, int finalLevel)
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

            /* total */
            int indexOfTotalPts = str.IndexOf("\"total\":{");

            /* number deployed */
            int indexOfNumberDeploys = str.IndexOf("\"number of deployed\":{");

            /* number of captured recycle icons */
            int indexOfNumberCapturesRecycled = str.IndexOf("\"number of captured recycle icons\":{");

            if (indexOfDeployPts != -1)
            {
                indexOfDeployPts += "\"deploy\":{".Length;
                int indexOfEndDeployPts = str.IndexOf('}', indexOfDeployPts);

                string[] deployesPts =
                    str.Substring(indexOfDeployPts, indexOfEndDeployPts - indexOfDeployPts).Split(',');
                deploy_points = GetPlayers(deployesPts);
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

            if (indexOfNumberDeploys != -1)
            {
                indexOfNumberDeploys += "\"number of deployed\":{".Length;
                int indexOfEndNumberDeploys = str.IndexOf('}', indexOfNumberDeploys);
                string[] ND = str.Substring(indexOfNumberDeploys, indexOfEndNumberDeploys - indexOfNumberDeploys).Split(',');
                number_deps = GetPlayers(ND);
            }

            if (indexOfNumberCapturesRecycled != -1)
            {
                indexOfNumberCapturesRecycled += "\"number of captured greenies\":{".Length;
                int indexOfEndNumberCapturesRecycled = str.IndexOf('}', indexOfNumberCapturesRecycled);
                string[] NCG = str.Substring(indexOfNumberCapturesRecycled, indexOfEndNumberCapturesRecycled - indexOfNumberCapturesRecycled).Split(',');
                number_caps_recycled = GetPlayers(NCG);
            }


            List<int> list = total_points.Values.ToList();
            list.Sort();
            list.Reverse();

            for (int i = 0; i < 10;)
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

    public class Clan1612
    {
        public int ClanId { get; set; }
        public string ClanName { get; set; }
        public Battle1612 DetailScore { get; set; }
    }

    public class Battle1612 /* TODO HERE*/
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_deps = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_deps_green = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_caps = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_caps_green = new Dictionary<string, int>(10);

        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1612(string str, int finalLevel)
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

            /* capture on */
            int indexOfCaptureOnPts = str.IndexOf("\"capture_on\":{");

            /* total */
            int indexOfTotalPts = str.IndexOf("\"total\":{");

            /* number deployed */
            int indexOfND = str.IndexOf("\"number of deployed\":{");

            /* number of deployed greenies */
            int indexOfNDGreen = str.IndexOf("\"number of deployed greenies\":{");
            
            /* number ceptured */
            int indexOfNC = str.IndexOf("\"number of captured\":{");

            /* number of captured greenies */
            int indexOfNCGreen = str.IndexOf("\"number of captured greenies\":{");

            if (indexOfDeployPts != -1)
            {
                indexOfDeployPts += "\"deploy\":{".Length;
                int indexOfEndDeployPts = str.IndexOf('}', indexOfDeployPts);

                string[] deployesPts =
                    str.Substring(indexOfDeployPts, indexOfEndDeployPts - indexOfDeployPts).Split(',');
                deploy_points = GetPlayers(deployesPts);
            }

            if (indexOfCapturePts != -1)
            {
                indexOfCapturePts += "\"capture\":{".Length;
                int indexOfEndCapturePts = str.IndexOf('}', indexOfCapturePts);
                string[] capturesPts =
                    str.Substring(indexOfCapturePts, indexOfEndCapturePts - indexOfCapturePts).Split(',');
                capture_points = GetPlayers(capturesPts);
            }
            if (indexOfCaptureOnPts != -1)
            {
                indexOfCaptureOnPts += "\"capture_on\":{".Length;
                int indexOfEndCaptureOnPts = str.IndexOf('}', indexOfCaptureOnPts);
                string[] capturesOnPts =
                    str.Substring(indexOfCaptureOnPts, indexOfEndCaptureOnPts - indexOfCaptureOnPts).Split(',');
                capture_on_points = GetPlayers(capturesOnPts);
            }
            if (indexOfTotalPts != -1)
            {
                indexOfTotalPts += "\"total\":{".Length;
                int indexOfEndTotalPts = str.IndexOf('}', indexOfTotalPts);
                string[] totalsPts = str.Substring(indexOfTotalPts, indexOfEndTotalPts - indexOfTotalPts).Split(',');
                total_points = GetPlayers(totalsPts);
                /*string[] totalModifiedPts = str.Substring(indexOfTotalModified, indexOEndTotalModified - indexOfTotalModified + 1).Split(',');*/
                total_points = GetPlayers(totalsPts);
            }

            if (indexOfND != -1)
            {
                indexOfND += "\"number of deployed\":{".Length;
                int indexOfEndND = str.IndexOf('}', indexOfND);
                string[] ND = str.Substring(indexOfND, indexOfEndND - indexOfND).Split(',');
                number_deps = GetPlayers(ND);
            }

            if (indexOfNDGreen != -1)
            {
                indexOfNDGreen += "\"number of deployed greenies\":{".Length;
                int indexOfEndNDGreen = str.IndexOf('}', indexOfNDGreen);
                string[] NDG = str.Substring(indexOfNDGreen, indexOfEndNDGreen - indexOfNDGreen).Split(',');
                number_deps_green = GetPlayers(NDG);
            }

            if (indexOfNC != -1)
            {
                indexOfNC += "\"number of captured\":{".Length;
                int indexOfEndNC = str.IndexOf('}', indexOfNC);
                string[] NC = str.Substring(indexOfNC, indexOfEndNC - indexOfNC).Split(',');
                number_caps = GetPlayers(NC);
            }

            if (indexOfNCGreen != -1)
            {
                indexOfNCGreen += "\"number of captured greenies\":{".Length;
                int indexOfEndNCGreen = str.IndexOf('}', indexOfNCGreen);
                string[] NCG = str.Substring(indexOfNCGreen, indexOfEndNCGreen - indexOfNCGreen).Split(',');
                number_caps_green = GetPlayers(NCG);
            }


            List<int> list = total_points.Values.ToList();
            list.Sort();
            list.Reverse();

            for (int i = 0; i < 10;)
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


    public class Clan1611
    {
        public int ClanId { get; set; }
        public string ClanName { get; set; }
        public Battle1611 DetailScore { get; set; }
    }

    public class NewClan1607
    {
        public int ClanId { get; set; }
        public string ClanName { get; set; }
        public NewBattle1607 DetailScore { get; set; }
    }

    public class Battle1611 /* TODO HERE*/
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_deps = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_caps = new Dictionary<string, int>(10);

        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1611(string str, int finalLevel)
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

            /* capture on */
            int indexOfCaptureOnPts = str.IndexOf("\"capture_on\":{");

            /* total */
            int indexOfTotalPts = str.IndexOf("\"total\":{");

            /* number deployed */
            int indexOfND = str.IndexOf("\"number of deployed\":{");

            /* number ceptured */
            int indexOfNC = str.IndexOf("\"number of captured\":{");

            if (indexOfDeployPts != -1)
            {
                indexOfDeployPts += "\"deploy\":{".Length;
                int indexOfEndDeployPts = str.IndexOf('}', indexOfDeployPts);

                string[] deployesPts =
                    str.Substring(indexOfDeployPts, indexOfEndDeployPts - indexOfDeployPts).Split(',');
                deploy_points = GetPlayers(deployesPts);
            }

            if (indexOfCapturePts != -1)
            {
                indexOfCapturePts += "\"capture\":{".Length;
                int indexOfEndCapturePts = str.IndexOf('}', indexOfCapturePts);
                string[] capturesPts =
                    str.Substring(indexOfCapturePts, indexOfEndCapturePts - indexOfCapturePts).Split(',');
                capture_points = GetPlayers(capturesPts);
            }
            if (indexOfCaptureOnPts != -1)
            {
                indexOfCaptureOnPts += "\"capture_on\":{".Length;
                int indexOfEndCaptureOnPts = str.IndexOf('}', indexOfCaptureOnPts);
                string[] capturesOnPts =
                    str.Substring(indexOfCaptureOnPts, indexOfEndCaptureOnPts - indexOfCaptureOnPts).Split(',');
                capture_on_points = GetPlayers(capturesOnPts);
            }
            if (indexOfTotalPts != -1)
            {
                indexOfTotalPts += "\"total\":{".Length;
                int indexOfEndTotalPts = str.IndexOf('}', indexOfTotalPts);
                string[] totalsPts = str.Substring(indexOfTotalPts, indexOfEndTotalPts - indexOfTotalPts).Split(',');
                total_points = GetPlayers(totalsPts);
                /*string[] totalModifiedPts = str.Substring(indexOfTotalModified, indexOEndTotalModified - indexOfTotalModified + 1).Split(',');*/
                total_points = GetPlayers(totalsPts);
            }

            if (indexOfND != -1)
            {
                indexOfND += "\"number of deployed\":{".Length;
                int indexOfEndND = str.IndexOf('}', indexOfND);
                string[] ND = str.Substring(indexOfND, indexOfEndND - indexOfND).Split(',');
                number_deps = GetPlayers(ND);
            }

            if (indexOfNC != -1)
            {
                indexOfNC += "\"number of captured\":{".Length;
                int indexOfEndNC = str.IndexOf('}', indexOfNC);
                string[] NC = str.Substring(indexOfNC, indexOfEndNC - indexOfNC).Split(',');
                number_caps = GetPlayers(NC);
            }


            List<int> list = total_points.Values.ToList();
            list.Sort();
            list.Reverse();

            for (int i = 0; i < 10;)
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

    public class NewBattle1607
    {
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
        public List<string> usersInfo = new List<string>(10);

        public int finalLevel;
        public int actualLevel;

        public NewBattle1607(string str, int finalLevel)
        {

            int indexOfResult = str.IndexOf('{', 5) + 1;
            if (indexOfResult == 0)
            {
                return;
            }
            /* usersinfo */
            for (int i = 0; i < 10; i++)
            {
                int indexOfStartUserInfo = str.IndexOf("{\"username\":", indexOfResult);
                if (indexOfStartUserInfo != -1)
                {
                    indexOfResult = str.IndexOf("}", indexOfStartUserInfo);
                    usersInfo.Add(str.Substring(indexOfStartUserInfo, indexOfResult - indexOfStartUserInfo + "}".Length));
                }
                //else 
                //    usersInfo.Add(null);
            }
            
            /* total */
            foreach (var userInfo in usersInfo)
            {
                //if (userInfo != null)
                //    continue;
                int indexOfUserName = "{\"username\":\"".Length;
                int indexOfEndUserName = userInfo.IndexOf("\"", indexOfUserName);
                string userName = userInfo.Substring(indexOfUserName, indexOfEndUserName - indexOfUserName);

                int indexOfTotalPts = userInfo.IndexOf("\"total_points\":");
                if (indexOfTotalPts != -1)
                {
                    indexOfTotalPts += "\"total_points\":".Length;
                    int indexOfEndTotalPts = userInfo.IndexOf(",", indexOfTotalPts);
                    string totalsPts = userInfo.Substring(indexOfTotalPts, indexOfEndTotalPts - indexOfTotalPts);
                    int tp;
                    int.TryParse(totalsPts, out tp);
                    total_points.Add(userName, tp);
                }
                else
                {
                    total_points.Add(userName, 0);
                }
            }

            this.finalLevel = finalLevel;
        }
    }

    public class Level1709
    {
        public Dictionary<int, Requirements1709> level = new Dictionary<int, Requirements1709>();

        public Level1709()
        {
            level.Add(1, new Requirements1709()
            {
                PlayerActivityPoints = 125,
                ClanActivityPoints = 2500,
                ClanTotalPoints = 30000
            });
            level.Add(2, new Requirements1709()
            {
                PlayerActivityPoints = 250,
                ClanActivityPoints = 4000,
                ClanTotalPoints = 75000
            });
            level.Add(3, new Requirements1709()
            {
                PlayerActivityPoints = 500,
                ClanActivityPoints = 7500,
                ClanTotalPoints = 145000
            });
            level.Add(4, new Requirements1709()
            {
                PlayerActivityPoints = 1000,
                ClanActivityPoints = 15000,
                ClanTotalPoints = 275000
            });
            level.Add(5, new Requirements1709()
            {
                PlayerActivityPoints = 2500,
                ClanActivityPoints = 40000,
                ClanTotalPoints = 450000

            });
        }
    }



    public class Level1705
    {
        public Dictionary<int, Requirements1705> level = new Dictionary<int, Requirements1705>();

        public Level1705()
        {
            level.Add(1, new Requirements1705()
            {
                PlayerActivityPoints = 120,
                ClanActivityPoints = 1600,
                ClanTotalPoints = 25000
            });
            level.Add(2, new Requirements1705()
            {
                PlayerActivityPoints = 225,
                ClanActivityPoints = 3250,
                ClanTotalPoints = 50000
            });
            level.Add(3, new Requirements1705()
            {
                PlayerActivityPoints = 600,
                ClanActivityPoints = 8000,
                ClanTotalPoints = 100000
            });
            level.Add(4, new Requirements1705()
            {
                PlayerActivityPoints = 1250,
                ClanActivityPoints = 17500,
                ClanTotalPoints = 250000
            });
            level.Add(5, new Requirements1705()
            {
                PlayerActivityPoints = 2250,
                ClanActivityPoints = 30000,
                ClanTotalPoints = 500000

            });
        }
    }


    public class Level1704
    {
        public Dictionary<int, Requirements1704> level = new Dictionary<int, Requirements1704>();

        public Level1704()
        {
            level.Add(1, new Requirements1704()
            {
                PlayerCapturePoints = 750,
                PlayerTotalPoints = 1250,
                ClanCapturePoints = 9000,
                ClanTotalPoints = 15000,
                ClanEventPins = 0
            });
            level.Add(2, new Requirements1704()
            {
                PlayerCapturePoints = 2000,
                PlayerTotalPoints = 3500,
                ClanCapturePoints = 30000,
                ClanTotalPoints = 55000,
                ClanEventPins = 0
            });
            level.Add(3, new Requirements1704()
            {
                PlayerCapturePoints = 4500,
                PlayerTotalPoints = 7000,
                ClanCapturePoints = 60000,
                ClanTotalPoints = 100000,
                ClanEventPins = 0
            });
            level.Add(4, new Requirements1704()
            {
                PlayerCapturePoints = 10000,
                PlayerTotalPoints = 15000,
                ClanCapturePoints = 140000,
                ClanTotalPoints = 200000,
                ClanEventPins = 0
            });
            level.Add(5, new Requirements1704()
            {
                PlayerCapturePoints = 20000,
                PlayerTotalPoints = 30000,
                ClanCapturePoints = 300000,
                ClanTotalPoints = 450000,
                ClanEventPins = 1
            });
        }
    }


    public class Level1703
    {
        public Dictionary<int, Requirements1703> level = new Dictionary<int, Requirements1703>();

        public Level1703()
        {
            level.Add(1, new Requirements1703()
            {
                PlayerPoints = 1500,
                PlayerGreenieDeploys = 15,
                ClanGreenieCaptures = 250,
                ClanShamrockCaptures = 0,
                ClanTotalPoints = 40000
            });
            level.Add(2, new Requirements1703()
            {
                PlayerPoints = 5000,
                PlayerGreenieDeploys = 30,
                ClanGreenieCaptures = 1000,
                ClanShamrockCaptures = 20,
                ClanTotalPoints = 150000
            });
            level.Add(3, new Requirements1703()
            {
                PlayerPoints = 12000,
                PlayerGreenieDeploys = 65,
                ClanGreenieCaptures = 1750,
                ClanShamrockCaptures = 40,
                ClanTotalPoints = 250000
            });
            level.Add(4, new Requirements1703()
            {
                PlayerPoints = 20000,
                PlayerGreenieDeploys = 100,
                ClanGreenieCaptures = 2500,
                ClanShamrockCaptures = 60,
                ClanTotalPoints = 400000
            });
            level.Add(5, new Requirements1703()
            {
                PlayerPoints = 30000,
                PlayerGreenieDeploys = 150,
                ClanGreenieCaptures = 4000,
                ClanShamrockCaptures = 100,
                ClanTotalPoints = 600000

            });
        }
    }


    public class Level1702
    {
        public Dictionary<int, Requirements1702> level = new Dictionary<int, Requirements1702>();

        public Level1702()
        {
            level.Add(1, new Requirements1702()
            {
               PlayerPoints = 1000,
               PlayerDeploys = 5,
               PlayerCapsJewelPoints = 0,
               ClanTotalPoints = 15000
            });
            level.Add(2, new Requirements1702()
            {
                PlayerPoints = 3500,
                PlayerDeploys = 15,
                PlayerCapsJewelPoints = 150,
                ClanTotalPoints = 37500
            });
            level.Add(3, new Requirements1702()
            {
                PlayerPoints = 7500,
                PlayerDeploys = 25,
                PlayerCapsJewelPoints = 300,
                ClanTotalPoints = 85000
            });
            level.Add(4, new Requirements1702()
            {
                PlayerPoints = 13000,
                PlayerDeploys = 35,
                PlayerCapsJewelPoints = 500,
                ClanTotalPoints = 150000
            });
            level.Add(5, new Requirements1702()
            {
                PlayerPoints = 18500,
                PlayerDeploys = 50,
                PlayerCapsJewelPoints = 750,
                ClanTotalPoints = 250000
                
            });
        }
    }

    public class Level1701
    {
        public Dictionary<int, Requirements1701> level = new Dictionary<int, Requirements1701>();

        public Level1701()
        {
            level.Add(1, new Requirements1701()
            {
             PlayerPointsWithoutCapOn = 1250,
             PlayerDeploys = 5,
             ClanRecycleCaps = 5,
             ClanPointsWithouCaps = 20000,
             ClanDeploys = 75
            });
            level.Add(2, new Requirements1701()
            {
                PlayerPointsWithoutCapOn = 3000,
                PlayerDeploys = 10,
                ClanRecycleCaps = 20,
                ClanPointsWithouCaps = 50000,
                ClanDeploys = 125
            });
            level.Add(3, new Requirements1701()
            {
                PlayerPointsWithoutCapOn = 6500,
                PlayerDeploys = 15,
                ClanRecycleCaps = 60,
                ClanPointsWithouCaps = 100000,
                ClanDeploys = 175
            });
            level.Add(4, new Requirements1701()
            {
                PlayerPointsWithoutCapOn = 12500,
                PlayerDeploys = 20,
                ClanRecycleCaps = 100,
                ClanPointsWithouCaps = 200000,
                ClanDeploys = 250
            });
            level.Add(5, new Requirements1701()
            {
                PlayerPointsWithoutCapOn = 17500,
                PlayerDeploys = 30,
                ClanRecycleCaps = 150,
                ClanPointsWithouCaps = 375000,
                ClanDeploys = 375
            });
        }
    }

    public class Level1612
    {
        public Dictionary<int, Requirements1612> level = new Dictionary<int, Requirements1612>();

        public Level1612()
        {
            level.Add(1, new Requirements1612()
            {
                PlayerDeployGreen = 2,
                PlayerCapturesGreen = 10,
                ClanDeploys = 35,
                ClanCaptures = 200

            });
            level.Add(2, new Requirements1612()
            {
                PlayerDeployGreen = 4,
                PlayerCapturesGreen = 20,
                ClanDeploys = 75,
                ClanCaptures = 400
            });
            level.Add(3, new Requirements1612()
            {
                PlayerDeployGreen = 6,
                PlayerCapturesGreen = 30,
                ClanDeploys = 125,
                ClanCaptures = 600
            });
            level.Add(4, new Requirements1612()
            {
                PlayerDeployGreen = 8,
                PlayerCapturesGreen = 40,
                ClanDeploys = 200,
                ClanCaptures = 800
            });
            level.Add(5, new Requirements1612()
            {
                PlayerDeployGreen = 10,
                PlayerCapturesGreen = 50,
                ClanDeploys = 300,
                ClanCaptures = 1000
            });
        }
    }

    public class Level1611
    {
        public Dictionary<int, Requirements1611> level = new Dictionary<int, Requirements1611>();

        public Level1611()
        {
            level.Add(1, new Requirements1611()
            {
                PlayerTotal = 1000,
                ClanTotal = 17500,
                ClanDeploys = 0,
                ClanCaptures = 125
                
            });
            level.Add(2, new Requirements1611()
            {
                PlayerTotal = 2500,
                ClanTotal = 40000,
                ClanDeploys = 75,
                ClanCaptures = 250
            });
            level.Add(3, new Requirements1611()
            {
                PlayerTotal = 6250,
                ClanTotal = 85000,
                ClanDeploys = 150,
                ClanCaptures = 475
            });
            level.Add(4, new Requirements1611()
            {
                PlayerTotal = 10000,
                ClanTotal = 175000,
                ClanDeploys = 300,
                ClanCaptures = 750
            });
            level.Add(5, new Requirements1611()
            {
                PlayerTotal = 15000,
                ClanTotal = 350000,
                ClanDeploys = 750,
                ClanCaptures = 1000
            });
        }
    }

    public class Requirements1709
    {
        public int PlayerActivityPoints;
        public int ClanActivityPoints;
        public int ClanTotalPoints;
    }

    public class Requirements1705
    {
        public int PlayerActivityPoints;
        public int ClanActivityPoints;
        public int ClanTotalPoints;
    }

    public class Requirements1704
    {
        public int PlayerTotalPoints;
        public int PlayerCapturePoints;
        public int ClanTotalPoints;
        public int ClanCapturePoints;
        public int ClanEventPins;

    }

    public class Requirements1703
    {
        public int PlayerPoints;
        public int PlayerGreenieDeploys;
        public int ClanGreenieCaptures;
        public int ClanShamrockCaptures;
        public int ClanTotalPoints;
    }

    public class Requirements1702
    {
        public int PlayerPoints;
        public int PlayerDeploys;
        public int PlayerCapsJewelPoints;
        public int ClanTotalPoints;
    }

    public class Requirements1701
    {
        public int PlayerPointsWithoutCapOn;
        public int PlayerDeploys;
        public int ClanRecycleCaps;
        public int ClanPointsWithouCaps;
        public int ClanDeploys;
    }


    public class Requirements1612
    {
        public int PlayerCapturesGreen;
        public int PlayerDeployGreen;
        public int ClanDeploys;
        public int ClanCaptures;
    }


    public class Requirements1611
    {
        public int PlayerTotal;
        public int ClanTotal;
        public int ClanDeploys;
        public int ClanCaptures;
    }
}