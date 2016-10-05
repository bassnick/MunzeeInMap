using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MunzeeInMap.MunzeeAppObjects
{
    public class Battle1610 /* TODO HERE*/
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> activity_points = new Dictionary<string, int>(10);
        
        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1610(string str, int finalLevel)
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

            /* activity */
            int indexOfActivityPts = str.IndexOf("\"activity points\":{");
            
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

            if (indexOfActivityPts != -1)
            {
                indexOfActivityPts += "\"total deploys\":{".Length;
                int indexOfEndTotalTotalJewelDeploys = str.IndexOf('}', indexOfActivityPts);
                string[] AP = str.Substring(indexOfActivityPts, indexOfEndTotalTotalJewelDeploys - indexOfActivityPts).Split(',');
                activity_points = GetPlayers(AP);
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


    public class Battle1609 
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_Deploys = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_Caps = new Dictionary<string, int>(10);

        public Dictionary<string, int> total_modified_points = new Dictionary<string, int>(10);

        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1609(string str, int finalLevel)
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

            /* total jewel deploy */
            int indexOfTotalDeploys = str.IndexOf("\"total deploys\":{");

            /* total jewel caps */
            int indexOfTotalCaps = str.IndexOf("\"total caps\":{");

            /*int indexOfTotalModified = str.IndexOf('{', indexOfEndTotalPts) + 1;
            int indexOEndTotalModified = str.IndexOf('}', indexOfTotalModified) - 1;
            */

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
                total_modified_points = GetPlayers(totalsPts);
            }

            if (indexOfTotalDeploys != -1)
            {
                indexOfTotalDeploys += "\"total deploys\":{".Length;
                int indexOfEndTotalTotalJewelDeploys = str.IndexOf('}', indexOfTotalDeploys);
                string[] totalsJD = str.Substring(indexOfTotalDeploys, indexOfEndTotalTotalJewelDeploys - indexOfTotalDeploys).Split(',');
                total_Deploys = GetPlayers(totalsJD);
            }
            if (indexOfTotalCaps != -1)
            {
                indexOfTotalCaps += "\"total caps\":{".Length;
                int indexOfEndTotalTotalJewelCaps = str.IndexOf('}', indexOfTotalCaps);
                string[] totalsJC = str.Substring(indexOfTotalCaps, indexOfEndTotalTotalJewelCaps - indexOfTotalCaps).Split(',');
                total_Caps = GetPlayers(totalsJC);
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

    public class Battle1608
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_JD = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_JC = new Dictionary<string, int>(10);

        public Dictionary<string, int> total_modified_points = new Dictionary<string, int>(10);

        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1608(string str, int finalLevel)
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

            /* total jewel deploy */
            int indexOfTotalJewelDeploys = str.IndexOf("\"total jewel deploys\":{");

            /* total jewel caps */
            int indexOfTotalJewelCaps = str.IndexOf("\"total jewel caps\":{");

            /*int indexOfTotalModified = str.IndexOf('{', indexOfEndTotalPts) + 1;
            int indexOEndTotalModified = str.IndexOf('}', indexOfTotalModified) - 1;
            */

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
                total_modified_points = GetPlayers(totalsPts);
            }

            if (indexOfTotalJewelDeploys != -1)
            {
                indexOfTotalJewelDeploys += "\"total jewel deploys\":{".Length;
                int indexOfEndTotalTotalJewelDeploys = str.IndexOf('}', indexOfTotalJewelDeploys);
                string[] totalsJD = str.Substring(indexOfTotalJewelDeploys, indexOfEndTotalTotalJewelDeploys - indexOfTotalJewelDeploys).Split(',');
                total_JD = GetPlayers(totalsJD);
            }
            if (indexOfTotalJewelCaps != -1)
            {
                indexOfTotalJewelCaps += "\"total jewel caps\":{".Length;
                int indexOfEndTotalTotalJewelCaps = str.IndexOf('}', indexOfTotalJewelCaps);
                string[] totalsJC = str.Substring(indexOfTotalJewelCaps, indexOfEndTotalTotalJewelCaps - indexOfTotalJewelCaps).Split(',');
                total_JC = GetPlayers(totalsJC);
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


    public class Battle1607
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);

        public Dictionary<string, int> total_modified_points = new Dictionary<string, int>(10);

        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1607(string str, int finalLevel)
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
            
            /*int indexOfTotalModified = str.IndexOf('{', indexOfEndTotalPts) + 1;
            int indexOEndTotalModified = str.IndexOf('}', indexOfTotalModified) - 1;
            */

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
                total_modified_points = GetPlayers(totalsPts);
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
    
    public class Battle1606
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);

        public Dictionary<string, int> deploys = new Dictionary<string, int>(10);

        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1606(string str, int finalLevel)
        {
            int indexOfResult = str.IndexOf('{', 5) + 1;
            if (indexOfResult == 0)
            {
                return;
            }
            int indexOfDeployPts = str.IndexOf('{', indexOfResult) + 1;
            int indexOfEndDeployPts = str.IndexOf('}', indexOfDeployPts) - 1;

            int indexOfCapturePts = str.IndexOf('{', indexOfEndDeployPts) + 1;
            int indexOfEndCapturePts = str.IndexOf('}', indexOfCapturePts) - 1;

            int indexOfCaptureOnPts = str.IndexOf('{', indexOfEndCapturePts) + 1;
            int indexOfEndCaptureOnPts = str.IndexOf('}', indexOfCaptureOnPts) - 1;

            int indexOfTotalPts = str.IndexOf('{', indexOfEndCaptureOnPts) + 1;
            int indexOfEndTotalPts = str.IndexOf('}', indexOfTotalPts) - 1;

            int indexOfDeploys = str.IndexOf('{', indexOfEndTotalPts) + 1;
            int indexOfEndDeploys = str.IndexOf('}', indexOfDeploys) - 1;



            string[] deployesPts = str.Substring(indexOfDeployPts, indexOfEndDeployPts - indexOfDeployPts + 1).Split(',');
            deploy_points = GetPlayers(deployesPts);
            string[] capturesPts = str.Substring(indexOfCapturePts, indexOfEndCapturePts - indexOfCapturePts + 1).Split(',');
            capture_points = GetPlayers(capturesPts);
            string[] capturesOnPts = str.Substring(indexOfCaptureOnPts, indexOfEndCaptureOnPts - indexOfCaptureOnPts + 1).Split(',');
            capture_on_points = GetPlayers(capturesOnPts);
            string[] totalsPts = str.Substring(indexOfTotalPts, indexOfEndTotalPts - indexOfTotalPts + 1).Split(',');
            total_points = GetPlayers(totalsPts);
            string[] numDeploys = str.Substring(indexOfDeploys, indexOfEndDeploys - indexOfDeploys + 1).Split(',');
            deploys = GetPlayers(numDeploys);

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
    public class Battle1605
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);

        public Dictionary<string, int> activity_points = new Dictionary<string, int>(10);
        
        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1605(string str, int finalLevel)
        {
            int indexOfResult = str.IndexOf('{', 5) + 1;
            if (indexOfResult == 0)
            {
                return;
            }
            int indexOfDeployPts = str.IndexOf('{', indexOfResult) + 1;
            int indexOfEndDeployPts = str.IndexOf('}', indexOfDeployPts) - 1;

            int indexOfCapturePts = str.IndexOf('{', indexOfEndDeployPts) + 1;
            int indexOfEndCapturePts = str.IndexOf('}', indexOfCapturePts) - 1;

            int indexOfCaptureOnPts = str.IndexOf('{', indexOfEndCapturePts) + 1;
            int indexOfEndCaptureOnPts = str.IndexOf('}', indexOfCaptureOnPts) - 1;

            int indexOfTotalPts = str.IndexOf('{', indexOfEndCaptureOnPts) + 1;
            int indexOfEndTotalPts = str.IndexOf('}', indexOfTotalPts) - 1;

            int indexOfActivityPoints= str.IndexOf('{', indexOfEndTotalPts) + 1;
            int indexOfEndActivityPoints = str.IndexOf('}', indexOfActivityPoints) - 1;

            

            string[] deployesPts = str.Substring(indexOfDeployPts, indexOfEndDeployPts - indexOfDeployPts + 1).Split(',');
            deploy_points = GetPlayers(deployesPts);
            string[] capturesPts = str.Substring(indexOfCapturePts, indexOfEndCapturePts - indexOfCapturePts + 1).Split(',');
            capture_points = GetPlayers(capturesPts);
            string[] capturesOnPts = str.Substring(indexOfCaptureOnPts, indexOfEndCaptureOnPts - indexOfCaptureOnPts + 1).Split(',');
            capture_on_points = GetPlayers(capturesOnPts);
            string[] totalsPts = str.Substring(indexOfTotalPts, indexOfEndTotalPts - indexOfTotalPts + 1).Split(',');
            total_points = GetPlayers(totalsPts);
            string[] activityPts = str.Substring(indexOfActivityPoints, indexOfEndActivityPoints - indexOfActivityPoints + 1).Split(',');
            activity_points = GetPlayers(activityPts);

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
    public class Battle1604
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);

        public Dictionary<string, int> total_greenies_and_nfc_captures = new Dictionary<string, int>(10);
        public Dictionary<string, int> specials_cap_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_deployed = new Dictionary<string, int>(10);




        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1604(string str, int finalLevel)
        {
            int indexOfResult = str.IndexOf('{', 5) + 1;
            if (indexOfResult == 0)
            {
                return;
            }
            int indexOfDeployPts = str.IndexOf('{', indexOfResult) + 1;
            int indexOfEndDeployPts = str.IndexOf('}', indexOfDeployPts) - 1;

            int indexOfCapturePts = str.IndexOf('{', indexOfEndDeployPts) + 1;
            int indexOfEndCapturePts = str.IndexOf('}', indexOfCapturePts) - 1;

            int indexOfCaptureOnPts = str.IndexOf('{', indexOfEndCapturePts) + 1;
            int indexOfEndCaptureOnPts = str.IndexOf('}', indexOfCaptureOnPts) - 1;

            int indexOfTotalPts = str.IndexOf('{', indexOfEndCaptureOnPts) + 1;
            int indexOfEndTotalPts = str.IndexOf('}', indexOfTotalPts) - 1;

            int indexOfNumGreeniesNFCCaps = str.IndexOf('{', indexOfEndTotalPts) + 1;
            int indexOfEndNumGreeniesNFCCaps = str.IndexOf('}', indexOfNumGreeniesNFCCaps) - 1;

            int indexOfSpecialsPts = str.IndexOf('{', indexOfEndNumGreeniesNFCCaps) + 1;
            int indexOfEndSpecialsPts = str.IndexOf('}', indexOfSpecialsPts) - 1;

            int indexOfNumDeploys = str.IndexOf('{', indexOfEndSpecialsPts) + 1;
            int indexOfEndNumDeploys = str.IndexOf('}', indexOfNumDeploys) - 1;


            string[] deployesPts = str.Substring(indexOfDeployPts, indexOfEndDeployPts - indexOfDeployPts + 1).Split(',');
            deploy_points = GetPlayers(deployesPts);
            string[] capturesPts = str.Substring(indexOfCapturePts, indexOfEndCapturePts - indexOfCapturePts + 1).Split(',');
            capture_points = GetPlayers(capturesPts);
            string[] capturesOnPts = str.Substring(indexOfCaptureOnPts, indexOfEndCaptureOnPts - indexOfCaptureOnPts + 1).Split(',');
            capture_on_points = GetPlayers(capturesOnPts);
            string[] totalsPts = str.Substring(indexOfTotalPts, indexOfEndTotalPts - indexOfTotalPts + 1).Split(',');
            total_points = GetPlayers(totalsPts);
            string[] greeniesNFCCaps = str.Substring(indexOfNumGreeniesNFCCaps, indexOfEndNumGreeniesNFCCaps - indexOfNumGreeniesNFCCaps + 1).Split(',');
            total_greenies_and_nfc_captures = GetPlayers(greeniesNFCCaps);

            string[] specialsPts = str.Substring(indexOfSpecialsPts, indexOfEndSpecialsPts - indexOfSpecialsPts + 1).Split(',');
            specials_cap_points = GetPlayers(specialsPts);
            string[] numDeployed = str.Substring(indexOfNumDeploys, indexOfEndNumDeploys - indexOfNumDeploys + 1).Split(',');
            number_deployed = GetPlayers(numDeployed);

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
    public class Battle1603
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);

        public Dictionary<string, int> total_greenies_captures = new Dictionary<string, int>(10);
        public Dictionary<string, int> jewels_captures = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_deployed = new Dictionary<string, int>(10);




        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1603(string str, int finalLevel)
        {
            int indexOfResult = str.IndexOf('{', 5) + 1;
            if (indexOfResult == 0)
            {
                return;
            }
            int indexOfDeployPts = str.IndexOf('{', indexOfResult) + 1;
            int indexOfEndDeployPts = str.IndexOf('}', indexOfDeployPts) - 1;

            int indexOfCapturePts = str.IndexOf('{', indexOfEndDeployPts) + 1;
            int indexOfEndCapturePts = str.IndexOf('}', indexOfCapturePts) - 1;

            int indexOfCaptureOnPts = str.IndexOf('{', indexOfEndCapturePts) + 1;
            int indexOfEndCaptureOnPts = str.IndexOf('}', indexOfCaptureOnPts) - 1;

            int indexOfTotalPts = str.IndexOf('{', indexOfEndCaptureOnPts) + 1;
            int indexOfEndTotalPts = str.IndexOf('}', indexOfTotalPts) - 1;

            int indexOfNumGreeniesCaps = str.IndexOf('{', indexOfEndTotalPts) + 1;
            int indexOfEndNumGreeniesCaps = str.IndexOf('}', indexOfNumGreeniesCaps) - 1;

            int indexOfNumJewelsCaps = str.IndexOf('{', indexOfEndNumGreeniesCaps) + 1;
            int indexOfEndNumJewelsCaps = str.IndexOf('}', indexOfNumJewelsCaps) - 1;

            int indexOfNumDeploys = str.IndexOf('{', indexOfEndNumJewelsCaps) + 1;
            int indexOfEndNumDeploys = str.IndexOf('}', indexOfNumDeploys) - 1;


            string[] deployesPts = str.Substring(indexOfDeployPts, indexOfEndDeployPts - indexOfDeployPts + 1).Split(',');
            deploy_points = GetPlayers(deployesPts);
            string[] capturesPts = str.Substring(indexOfCapturePts, indexOfEndCapturePts - indexOfCapturePts + 1).Split(',');
            capture_points = GetPlayers(capturesPts);
            string[] capturesOnPts = str.Substring(indexOfCaptureOnPts, indexOfEndCaptureOnPts - indexOfCaptureOnPts + 1).Split(',');
            capture_on_points = GetPlayers(capturesOnPts);
            string[] totalsPts = str.Substring(indexOfTotalPts, indexOfEndTotalPts - indexOfTotalPts + 1).Split(',');
            total_points = GetPlayers(totalsPts);
            string[] greeniesCaps = str.Substring(indexOfNumGreeniesCaps, indexOfEndNumGreeniesCaps - indexOfNumGreeniesCaps + 1).Split(',');
            total_greenies_captures = GetPlayers(greeniesCaps);

            string[] jewelsCaps = str.Substring(indexOfNumJewelsCaps, indexOfEndNumJewelsCaps - indexOfNumJewelsCaps + 1).Split(',');
            jewels_captures = GetPlayers(jewelsCaps);
            string[] numDeployed = str.Substring(indexOfNumDeploys, indexOfEndNumDeploys - indexOfNumDeploys + 1).Split(',');
            number_deployed = GetPlayers(numDeployed);

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


    public class Battle1512
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);

        public Dictionary<string, int> total_captures = new Dictionary<string, int>(10);
        public Dictionary<string, int> trail_stages_captures = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_deployed = new Dictionary<string, int>(10);
        



        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1512(string str, int finalLevel)
        {
            int indexOfResult = str.IndexOf('{', 5) + 1;
            if (indexOfResult == 0)
            {
                return;
            }
            int indexOfDeployPts = str.IndexOf('{', indexOfResult) + 1;
            int indexOfEndDeployPts = str.IndexOf('}', indexOfDeployPts) - 1;

            int indexOfCapturePts = str.IndexOf('{', indexOfEndDeployPts) + 1;
            int indexOfEndCapturePts = str.IndexOf('}', indexOfCapturePts) - 1;

            int indexOfCaptureOnPts = str.IndexOf('{', indexOfEndCapturePts) + 1;
            int indexOfEndCaptureOnPts = str.IndexOf('}', indexOfCaptureOnPts) - 1;

            int indexOfTotalPts = str.IndexOf('{', indexOfEndCaptureOnPts) + 1;
            int indexOfEndTotalPts = str.IndexOf('}', indexOfTotalPts) - 1;

            int indexOfTotalCaps = str.IndexOf('{', indexOfEndTotalPts) + 1;
            int indexOfEndTotalCaps = str.IndexOf('}', indexOfTotalCaps) - 1;

            int indexOfTrailStagesCaps = str.IndexOf('{', indexOfEndTotalCaps) + 1;
            int indexOfEndTrailStagesCaps = str.IndexOf('}', indexOfTrailStagesCaps) - 1;

            int indexOfNumDeploys = str.IndexOf('{', indexOfEndTrailStagesCaps) + 1;
            int indexOfEndNumDeploys = str.IndexOf('}', indexOfNumDeploys) - 1;

            
            string[] deployesPts = str.Substring(indexOfDeployPts, indexOfEndDeployPts - indexOfDeployPts + 1).Split(',');
            deploy_points = GetPlayers(deployesPts);
            string[] capturesPts = str.Substring(indexOfCapturePts, indexOfEndCapturePts - indexOfCapturePts + 1).Split(',');
            capture_points = GetPlayers(capturesPts);
            string[] capturesOnPts = str.Substring(indexOfCaptureOnPts, indexOfEndCaptureOnPts - indexOfCaptureOnPts + 1).Split(',');
            capture_on_points = GetPlayers(capturesOnPts);
            string[] totalsPts = str.Substring(indexOfTotalPts, indexOfEndTotalPts - indexOfTotalPts + 1).Split(',');
            total_points = GetPlayers(totalsPts);
            string[] totalsCaps = str.Substring(indexOfTotalCaps, indexOfEndTotalCaps - indexOfTotalCaps + 1).Split(',');
            total_captures = GetPlayers(totalsCaps);

            string[] trailStagesCaps = str.Substring(indexOfTrailStagesCaps, indexOfEndTrailStagesCaps - indexOfTrailStagesCaps + 1).Split(',');
            trail_stages_captures = GetPlayers(trailStagesCaps);
            string[] numDeployed = str.Substring(indexOfNumDeploys, indexOfEndNumDeploys - indexOfNumDeploys + 1).Split(',');
            number_deployed = GetPlayers(numDeployed);
            
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

    public class Battle1511
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);

        public Dictionary<string, int> total_captures             =new Dictionary<string, int>(10);
        public Dictionary<string, int> motel_hotel_captures       =new Dictionary<string, int>(10);
        public Dictionary<string, int> number_deployed            =new Dictionary<string, int>(10);
        public Dictionary<string, int> number_jews_deployed       =new Dictionary<string, int>(10);
            
            


        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1511(string str, int finalLevel)
        {
            int indexOfResult = str.IndexOf('{', 5) + 1;
            if (indexOfResult == 0)
            {
                return;
            }
            int indexOfDeployPts = str.IndexOf('{', indexOfResult) + 1;
            int indexOfEndDeployPts = str.IndexOf('}', indexOfDeployPts) - 1;

            int indexOfCapturePts = str.IndexOf('{', indexOfEndDeployPts) + 1;
            int indexOfEndCapturePts = str.IndexOf('}', indexOfCapturePts) - 1;

            int indexOfCaptureOnPts = str.IndexOf('{', indexOfEndCapturePts) + 1;
            int indexOfEndCaptureOnPts = str.IndexOf('}', indexOfCaptureOnPts) - 1;

            int indexOfTotalPts = str.IndexOf('{', indexOfEndCaptureOnPts) + 1;
            int indexOfEndTotalPts = str.IndexOf('}', indexOfTotalPts) - 1;

            int indexOfTotalCaps = str.IndexOf('{', indexOfEndTotalPts) + 1;
            int indexOfEndTotalCaps = str.IndexOf('}', indexOfTotalCaps) - 1;

            int indexOfMHCaps = str.IndexOf('{', indexOfEndTotalCaps) + 1;
            int indexOfEndMHCaps = str.IndexOf('}', indexOfMHCaps) - 1;

            int indexOfNumDeploys = str.IndexOf('{', indexOfEndMHCaps) + 1;
            int indexOfEndNumDeploys = str.IndexOf('}', indexOfNumDeploys) - 1;

            int indexOfNumDeployedJews = str.IndexOf('{', indexOfEndNumDeploys) + 1;
            int indexOfEndNumDeployedJews= str.IndexOf('}', indexOfNumDeployedJews) - 1;

            string[] deployesPts = str.Substring(indexOfDeployPts, indexOfEndDeployPts - indexOfDeployPts + 1).Split(',');
            deploy_points = GetPlayers(deployesPts);
            string[] capturesPts = str.Substring(indexOfCapturePts, indexOfEndCapturePts - indexOfCapturePts + 1).Split(',');
            capture_points = GetPlayers(capturesPts);
            string[] capturesOnPts = str.Substring(indexOfCaptureOnPts, indexOfEndCaptureOnPts - indexOfCaptureOnPts + 1).Split(',');
            capture_on_points = GetPlayers(capturesOnPts);
            string[] totalsPts = str.Substring(indexOfTotalPts, indexOfEndTotalPts - indexOfTotalPts + 1).Split(',');
            total_points = GetPlayers(totalsPts);
            string[] totalsCaps = str.Substring(indexOfTotalCaps, indexOfEndTotalCaps - indexOfTotalCaps + 1).Split(',');
            total_captures = GetPlayers(totalsCaps);

            string[] mhCaps = str.Substring(indexOfMHCaps, indexOfEndMHCaps - indexOfMHCaps + 1).Split(',');
            motel_hotel_captures = GetPlayers(mhCaps);
            string[] numDeployed = str.Substring(indexOfNumDeploys, indexOfEndNumDeploys - indexOfNumDeploys + 1).Split(',');
            number_deployed = GetPlayers(numDeployed);
            string[] numJewsDeployed = str.Substring(indexOfNumDeployedJews, indexOfEndNumDeployedJews - indexOfNumDeployedJews + 1).Split(',');
            number_jews_deployed = GetPlayers(numJewsDeployed);
            
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

    public class Battle1510
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);

        public Dictionary<string, int> jewels = new Dictionary<string, int>(10);
        
        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1510(string str, int finalLevel)
        {
            int indexOfResult = str.IndexOf('{', 5) + 1;
            if (indexOfResult == 0)
            {
                return;
            }
            int indexOfDeploy = str.IndexOf('{', indexOfResult) + 1;
            int indexOfEndDeploy = str.IndexOf('}', indexOfDeploy) - 1;

            int indexOfCapture = str.IndexOf('{', indexOfEndDeploy) + 1;
            int indexOfEndCapture = str.IndexOf('}', indexOfCapture) - 1;

            int indexOfCaptureOn = str.IndexOf('{', indexOfEndCapture) + 1;
            int indexOfEndCaptureOn = str.IndexOf('}', indexOfCaptureOn) - 1;

            int indexOfTotal = str.IndexOf('{', indexOfEndCaptureOn) + 1;
            int indexOfEndTotal = str.IndexOf('}', indexOfTotal) - 1;

            int indexOfJewels = str.IndexOf('{', indexOfEndTotal) + 1;
            int indexOfEndJewels = str.IndexOf('}', indexOfJewels) - 1;

            string[] deployes = str.Substring(indexOfDeploy, indexOfEndDeploy - indexOfDeploy + 1).Split(',');
            deploy_points = GetPlayers(deployes);
            string[] captures = str.Substring(indexOfCapture, indexOfEndCapture - indexOfCapture + 1).Split(',');
            capture_points = GetPlayers(captures);
            string[] capturesOn = str.Substring(indexOfCaptureOn, indexOfEndCaptureOn - indexOfCaptureOn + 1).Split(',');
            capture_on_points = GetPlayers(capturesOn);
            string[] totals = str.Substring(indexOfTotal, indexOfEndTotal - indexOfTotal + 1).Split(',');
            total_points = GetPlayers(totals);
            string[] jewels_num = str.Substring(indexOfJewels, indexOfEndJewels - indexOfJewels + 1).Split(',');
            jewels = GetPlayers(jewels_num);
            



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

    public class Battle1509
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
        
        public Dictionary<string, int> mysteries_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> num_deployed = new Dictionary<string, int>(10);
        public Dictionary<string, int> num_greens_deployed = new Dictionary<string, int>(10);

        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1509(string str, int finalLevel)
        {
            int indexOfResult = str.IndexOf('{', 5) + 1;
            if (indexOfResult == 0)
            {
                return;
            }
            int indexOfDeploy = str.IndexOf('{', indexOfResult) + 1;
            int indexOfEndDeploy = str.IndexOf('}', indexOfDeploy) - 1;

            int indexOfCapture = str.IndexOf('{', indexOfEndDeploy) + 1;
            int indexOfEndCapture = str.IndexOf('}', indexOfCapture) - 1;

            int indexOfCaptureOn = str.IndexOf('{', indexOfEndCapture) + 1;
            int indexOfEndCaptureOn = str.IndexOf('}', indexOfCaptureOn) - 1;

            int indexOfTotal = str.IndexOf('{', indexOfEndCaptureOn) + 1;
            int indexOfEndTotal = str.IndexOf('}', indexOfTotal) - 1;

            int indexOfMysteriesCOPoints = str.IndexOf('{', indexOfEndTotal) + 1;
            int indexOfEndMysteriesCOPoints = str.IndexOf('}', indexOfMysteriesCOPoints) - 1;

            int indexOfNumberDeployed = str.IndexOf('{', indexOfEndMysteriesCOPoints) + 1;
            int indexOfEndNumberDeployed = str.IndexOf('}', indexOfNumberDeployed) - 1;

            int indexOfNumberGreenDeployed = str.IndexOf('{', indexOfEndNumberDeployed) + 1;
            int indexOfEndNumberGreenDeployed = str.IndexOf('}', indexOfNumberGreenDeployed) - 1;

            string[] deployes = str.Substring(indexOfDeploy, indexOfEndDeploy - indexOfDeploy + 1).Split(',');
            deploy_points = GetPlayers(deployes);
            string[] captures = str.Substring(indexOfCapture, indexOfEndCapture - indexOfCapture + 1).Split(',');
            capture_points = GetPlayers(captures);
            string[] capturesOn = str.Substring(indexOfCaptureOn, indexOfEndCaptureOn - indexOfCaptureOn + 1).Split(',');
            capture_on_points = GetPlayers(capturesOn);
            string[] totals = str.Substring(indexOfTotal, indexOfEndTotal - indexOfTotal + 1).Split(',');
            total_points = GetPlayers(totals);
            string[] mysteries = str.Substring(indexOfMysteriesCOPoints, indexOfEndMysteriesCOPoints - indexOfMysteriesCOPoints + 1).Split(',');
            mysteries_points = GetPlayers(mysteries);
            string[] numberDeployeds = str.Substring(indexOfNumberDeployed, indexOfEndNumberDeployed - indexOfNumberDeployed + 1).Split(',');
            num_deployed = GetPlayers(numberDeployeds);
            string[] greens= str.Substring(indexOfNumberGreenDeployed, indexOfEndNumberGreenDeployed - indexOfNumberGreenDeployed + 1).Split(',');
            num_greens_deployed = GetPlayers(greens);




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

    public class Battle1507
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1507(string str, int finalLevel)
        {
            int indexOfResult = str.IndexOf('{', 5) + 1;
            if (indexOfResult == 0)
            {
                return;
            }
            int indexOfDeploy = str.IndexOf('{', indexOfResult) + 1;
            int indexOfEndDeploy = str.IndexOf('}', indexOfDeploy) - 1;

            int indexOfCapture = str.IndexOf('{', indexOfEndDeploy) + 1;
            int indexOfEndCapture = str.IndexOf('}', indexOfCapture) - 1;

            int indexOfCaptureOn = str.IndexOf('{', indexOfEndCapture) + 1;
            int indexOfEndCaptureOn = str.IndexOf('}', indexOfCaptureOn) - 1;

            int indexOfTotal = str.IndexOf('{', indexOfEndCaptureOn) + 1;
            int indexOfEndTotal = str.IndexOf('}', indexOfTotal) - 1;

            int indexOfEndResult = str.IndexOf('{', indexOfEndTotal) + 1;
            
            string[] deployes = str.Substring(indexOfDeploy, indexOfEndDeploy - indexOfDeploy + 1).Split(',');
            deploy_points = GetPlayers(deployes);
            string[] captures = str.Substring(indexOfCapture, indexOfEndCapture - indexOfCapture + 1).Split(',');
            capture_points = GetPlayers(captures);
            string[] capturesOn = str.Substring(indexOfCaptureOn, indexOfEndCaptureOn - indexOfCaptureOn + 1).Split(',');
            capture_on_points = GetPlayers(capturesOn);
            string[] totals = str.Substring(indexOfTotal, indexOfEndTotal - indexOfTotal + 1).Split(',');
            total_points = GetPlayers(totals);
            


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

    public class Battle1506
    {
        public Dictionary<string, int> deploy_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> total_points = new Dictionary<string, int>(10);
        public Dictionary<string, int> active_days = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_of_deployed = new Dictionary<string, int>(10);
        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1506(string str, int finalLevel)
        {
            int indexOfResult = str.IndexOf('{', 5) + 1;
            if (indexOfResult == 0)
            {
                return;
            }
            int indexOfDeploy = str.IndexOf('{', indexOfResult) + 1;
            int indexOfEndDeploy = str.IndexOf('}', indexOfDeploy) - 1;

            int indexOfCapture = str.IndexOf('{', indexOfEndDeploy) + 1;
            int indexOfEndCapture = str.IndexOf('}', indexOfCapture) - 1;

            int indexOfCaptureOn = str.IndexOf('{', indexOfEndCapture) + 1;
            int indexOfEndCaptureOn = str.IndexOf('}', indexOfCaptureOn) - 1;

            int indexOfTotal = str.IndexOf('{', indexOfEndCaptureOn) + 1;
            int indexOfEndTotal = str.IndexOf('}', indexOfTotal) - 1;

            int indexOfActiveDays = str.IndexOf('{', indexOfEndTotal) + 1;
            int indexOfEndActiveDays = str.IndexOf('}', indexOfActiveDays) - 1;

            int indexOfNumberOfDeploy = str.IndexOf('{', indexOfEndActiveDays) + 1;
            int indexOfNumberOfEndDeploy = str.IndexOf('}', indexOfNumberOfDeploy) - 1;

            int indexOfEndResult = str.IndexOf('}', indexOfNumberOfEndDeploy) - 1;


            string[] deployes = str.Substring(indexOfDeploy, indexOfEndDeploy - indexOfDeploy + 1).Split(',');
            deploy_points = GetPlayers(deployes);
            string[] captures = str.Substring(indexOfCapture, indexOfEndCapture - indexOfCapture + 1).Split(',');
            capture_points = GetPlayers(captures);
            string[] capturesOn = str.Substring(indexOfCaptureOn, indexOfEndCaptureOn - indexOfCaptureOn + 1).Split(',');
            capture_on_points = GetPlayers(capturesOn);
            string[] totals = str.Substring(indexOfTotal, indexOfEndTotal - indexOfTotal + 1).Split(',');
            total_points = GetPlayers(totals);
            string[] combined_captures = str.Substring(indexOfActiveDays, indexOfEndActiveDays - indexOfActiveDays + 1).Split(',');
            active_days = GetPlayers(combined_captures);
            string[] deploysNumber =
                str.Substring(indexOfNumberOfDeploy, indexOfNumberOfEndDeploy - indexOfNumberOfDeploy + 1).Split(',');
            number_of_deployed = GetPlayers(deploysNumber);


            List<int> list = total_points.Values.ToList();
            list.Sort();
            list.Reverse();

            for (int i = 0; i < 10; )
            {
                foreach (var playerRecord in total_points)
                {
                    if (i >= list.Count || playerRecord.Value == list[i])
                    {
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

    public class Battle1505
    {
        public Dictionary<string, int> deploy = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on = new Dictionary<string, int>(10);
        public Dictionary<string, int> total = new Dictionary<string, int>(10);
        public Dictionary<string, int> combined_capture = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_of_deployed = new Dictionary<string, int>(10);
        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel;
        public int actualLevel;

        public Battle1505(string str, int finalLevel)
        {
            int indexOfResult = str.IndexOf('{', 5) + 1;

            int indexOfDeploy = str.IndexOf('{', indexOfResult) + 1;
            int indexOfEndDeploy = str.IndexOf('}', indexOfDeploy) - 1;

            int indexOfCapture = str.IndexOf('{', indexOfEndDeploy) + 1;
            int indexOfEndCapture = str.IndexOf('}', indexOfCapture) - 1;

            int indexOfCaptureOn = str.IndexOf('{', indexOfEndCapture) + 1;
            int indexOfEndCaptureOn = str.IndexOf('}', indexOfCaptureOn) - 1;

            int indexOfTotal = str.IndexOf('{', indexOfEndCaptureOn) + 1;
            int indexOfEndTotal = str.IndexOf('}', indexOfTotal) - 1;

            int indexOfCombinedCapture = str.IndexOf('{', indexOfEndTotal) + 1;
            int indexOfEndCombinedCapture = str.IndexOf('}', indexOfCombinedCapture) - 1;

            int indexOfNumberOfDeploy = str.IndexOf('{', indexOfEndCombinedCapture) + 1;
            int indexOfNumberOfEndDeploy = str.IndexOf('}', indexOfNumberOfDeploy) - 1;
            
            int indexOfEndResult = str.IndexOf('}', indexOfNumberOfEndDeploy) - 1;


            string[] deployes = str.Substring(indexOfDeploy, indexOfEndDeploy - indexOfDeploy + 1).Split(',');
            deploy = GetPlayers(deployes);
            string[] captures = str.Substring(indexOfCapture, indexOfEndCapture - indexOfCapture + 1).Split(',');
            capture = GetPlayers(captures);
            string[] capturesOn = str.Substring(indexOfCaptureOn, indexOfEndCaptureOn - indexOfCaptureOn + 1).Split(',');
            capture_on = GetPlayers(capturesOn);
            string[] totals = str.Substring(indexOfTotal, indexOfEndTotal - indexOfTotal + 1).Split(',');
            total = GetPlayers(totals);
            string[] combined_captures = str.Substring(indexOfCombinedCapture, indexOfEndCombinedCapture - indexOfCombinedCapture + 1).Split(',');
            combined_capture = GetPlayers(combined_captures);
            string[] deploysNumber =
                str.Substring(indexOfNumberOfDeploy, indexOfNumberOfEndDeploy - indexOfNumberOfDeploy + 1).Split(',');
            number_of_deployed = GetPlayers(deploysNumber);


            List<int> list = total.Values.ToList();
            list.Sort();
            list.Reverse();

            for (int i = 0; i < 10;)
            {
                foreach (var playerRecord in total)
                {
                    if (i >= list.Count || playerRecord.Value == list[i])
                    {
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
                int.TryParse(d[1].Trim(new char[] {'"', ' '}), out value);
                playersScores.Add(d[0].Trim('"'), value);

            }
            return playersScores;
        }


    }

    public class Battle1504
    {
        public Dictionary<string, int> deploy = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture = new Dictionary<string, int>(10);
        public Dictionary<string, int> capture_on = new Dictionary<string, int>(10);
        public Dictionary<string, int> total = new Dictionary<string, int>(10);
        public Dictionary<string, int> number_of_deployed = new Dictionary<string, int>(10);
        public Dictionary<int, string> playerOrder = new Dictionary<int, string>(10);

        public int finalLevel = 5;
        public int actualLevel = 0;

        public Battle1504(string str)
        {
            int indexOfResult = str.IndexOf('{', 5) + 1;

            int indexOfDeploy = str.IndexOf('{', indexOfResult) + 1;
            int indexOfEndDeploy = str.IndexOf('}', indexOfDeploy) - 1;

            int indexOfCapture = str.IndexOf('{', indexOfEndDeploy) + 1;
            int indexOfEndCapture = str.IndexOf('}', indexOfCapture) - 1;

            int indexOfCaptureOn = str.IndexOf('{', indexOfEndCapture) + 1;
            int indexOfEndCaptureOn = str.IndexOf('}', indexOfCaptureOn) - 1;

            int indexOfTotal = str.IndexOf('{', indexOfEndCaptureOn) + 1;
            int indexOfEndTotal = str.IndexOf('}', indexOfTotal) - 1;

            int indexOfNumberOfDeploy = str.IndexOf('{', indexOfEndTotal) + 1;
            int indexOfNumberOfEndDeploy = str.IndexOf('}', indexOfNumberOfDeploy) - 1;

            int indexOfEndResult = str.IndexOf('}', indexOfNumberOfEndDeploy) - 1;


            string[] deployes = str.Substring(indexOfDeploy, indexOfEndDeploy - indexOfDeploy + 1).Split(',');
            deploy = GetPlayers(deployes);
            string[] captures = str.Substring(indexOfCapture, indexOfEndCapture - indexOfCapture + 1).Split(',');
            capture = GetPlayers(captures);
            string[] capturesOn =
                str.Substring(indexOfCaptureOn, indexOfEndCaptureOn - indexOfCaptureOn + 1).Split(',');
            capture_on = GetPlayers(capturesOn);
            string[] totals = str.Substring(indexOfTotal, indexOfEndTotal - indexOfTotal + 1).Split(',');
            total = GetPlayers(totals);
            string[] deploysNumber =
                str.Substring(indexOfNumberOfDeploy, indexOfNumberOfEndDeploy - indexOfNumberOfDeploy + 1)
                    .Split(',');
            number_of_deployed = GetPlayers(deploysNumber);

            List<int> list = total.Values.ToList();
            list.Sort();
            list.Reverse();

            for (int i = 0; i < 10;)
            {
                foreach (var playerRecord in total)
                {
                    if (i != list.Count && playerRecord.Value == list[i])
                    {
                        playerOrder.Add(i + 1, playerRecord.Key);
                        i++;
                    }
                }
            }
        }





        private static Dictionary<string, int> GetPlayers(string[] jsonString)
        {
            Dictionary<string, int> playersScores = new Dictionary<string, int>(10);
            foreach (var jstr in jsonString)
            {
                string[] d = jstr.Split(':');
                int value;
                int.TryParse(d[1].Trim(new char[] {'"', ' '}), out value);
                playersScores.Add(d[0].Trim('"'), value);

            }
            return playersScores;
        }
    }

    public class Level1610
    {
        public Dictionary<int, Requirements1610> level = new Dictionary<int, Requirements1610>();

        public Level1610()
        {
            level.Add(1, new Requirements1610()
            {
                PlayerActivity = 100,
                PlayerTotal = 1000,
                ClanActivity = 1500,
                ClanTotal = 15000
            });
            level.Add(2, new Requirements1610()
            {
                PlayerActivity = 200,
                PlayerTotal = 1750,
                ClanActivity = 3000,
                ClanTotal = 30000
            });
            level.Add(3, new Requirements1610()
            {
                PlayerActivity = 500,
                PlayerTotal = 3500,
                ClanActivity = 7500,
                ClanTotal = 75000
            });
            level.Add(4, new Requirements1610()
            {
                PlayerActivity = 1000,
                PlayerTotal = 5000,
                ClanActivity = 12000,
                ClanTotal = 200000
            });
            level.Add(5, new Requirements1610()
            {
                PlayerActivity = 2000,
                PlayerTotal = 15000,
                ClanActivity = 25000,
                ClanTotal = 350000

            });
        }
    }


    public class Level1609
    {
        public Dictionary<int, Requirements1609> level = new Dictionary<int, Requirements1609>();

        public Level1609()
        {
            level.Add(1, new Requirements1609()
            {
                PlayerPts = 1000,
                PlayerDeploys = 0,
                ClanDeploys = 25,
                ClanCaps = 100,
                ClanPts = 15000
            });
            level.Add(2, new Requirements1609()
            {
                PlayerPts = 2000,
                PlayerDeploys = 5,
                ClanDeploys = 75,
                ClanCaps = 200,
                ClanPts = 35000
            });
            level.Add(3, new Requirements1609()
            {
                PlayerPts = 5000,
                PlayerDeploys = 10,
                ClanDeploys = 150,
                ClanCaps = 350,
                ClanPts = 75000
            });
            level.Add(4, new Requirements1609()
            {
                PlayerPts = 12500,
                PlayerDeploys = 25,
                ClanDeploys = 300,
                ClanCaps = 500,
                ClanPts = 175000
            });
            level.Add(5, new Requirements1609()
            {
                PlayerPts = 25000,
                PlayerDeploys = 50,
                ClanDeploys = 600,
                ClanCaps = 1000,
                ClanPts = 350000
                
            });
        }
    }

    public class Level1608
    {
        public Dictionary<int, Requirements1608> level = new Dictionary<int, Requirements1608>();

        public Level1608()
        {
            level.Add(1, new Requirements1608()
            {
                PlayerPts = 1000,
                ClanJewelCaps = 100,
                ClanJewelDeploys = 25,
                ClanPts = 20000
            });
            level.Add(2, new Requirements1608()
            {
                PlayerPts = 2000,
                ClanJewelCaps = 300,
                ClanJewelDeploys = 75,
                ClanPts = 40000
            });
            level.Add(3, new Requirements1608()
            {
                PlayerPts = 5000,
                ClanJewelCaps = 750,
                ClanJewelDeploys = 175,
                ClanPts = 80000

            });
            level.Add(4, new Requirements1608()
            {
                PlayerPts = 15000,
                ClanJewelCaps = 1200,
                ClanJewelDeploys = 325,
                ClanPts = 160000
            });
            level.Add(5, new Requirements1608()
            {
                PlayerPts = 25000,
                ClanJewelCaps = 1800,
                ClanJewelDeploys = 500,
                ClanPts = 320000
            });
        }
    }


    public class Level1607
    {
        public Dictionary<int, Requirements1607> level = new Dictionary<int, Requirements1607>();

        public Level1607()
        {
            level.Add(1, new Requirements1607()
            {
                ModifiedPts = 1000,
                ClanModifiedPts = 12000
            });
            level.Add(2, new Requirements1607()
            {
                ModifiedPts = 5000,
                ClanModifiedPts = 60000 
            });
            level.Add(3, new Requirements1607()
            {
                ModifiedPts = 8000 ,
                ClanModifiedPts = 100000
            });
            level.Add(4, new Requirements1607()
            {
                ModifiedPts = 14000,
                ClanModifiedPts = 170000 

            });
            level.Add(5, new Requirements1607()
            {
                ModifiedPts = 18000,
                ClanModifiedPts = 220000 
            });
        }
    }

    public class Level1606
    {
        public Dictionary<int, Requirements1606> level = new Dictionary<int, Requirements1606>();

        public Level1606()
        {
            level.Add(1, new Requirements1606()
            {
                ClanNumDeploys = 50,
                PlayerPoints = 1000,
                ClanPoints = 12000
            });
            level.Add(2, new Requirements1606()
            {
                ClanNumDeploys = 75,
                PlayerPoints = 2000,
                ClanPoints = 30000
            });
            level.Add(3, new Requirements1606()
            {
                ClanNumDeploys = 150,
                PlayerPoints = 5000,
                ClanPoints = 70000
            });
            level.Add(4, new Requirements1606()
            {
                ClanNumDeploys = 400,
                PlayerPoints = 10000,
                ClanPoints = 200000

            });
            level.Add(5, new Requirements1606()
            {
                ClanNumDeploys = 600,
                PlayerPoints = 20000,
                ClanPoints = 380000
            });
        }
    }


    public class Level1605
    {
        public Dictionary<int, Requirements1605> level = new Dictionary<int, Requirements1605>();

        public Level1605()
        {
            level.Add(1, new Requirements1605()
            {
                ClanActivityPts = 310,
                ClanPoints = 12000
            });
            level.Add(2, new Requirements1605()
            {
                ClanActivityPts = 620,
                ClanPoints = 30000
            });
            level.Add(3, new Requirements1605()
            {
                ClanActivityPts = 1240,
                ClanPoints = 70000
            });
            level.Add(4, new Requirements1605()
            {
                ClanActivityPts = 3100,
                ClanPoints = 200000
            });
            level.Add(5, new Requirements1605()
            {
                ClanActivityPts = 6200,
                ClanPoints = 380000
            });
        }
    }

    public class Level1604
    {
        public Dictionary<int, Requirements1604> level = new Dictionary<int, Requirements1604>();

        public Level1604()
        {
            level.Add(1, new Requirements1604()
            {
                PlayerPoints = 1000,
                ClanGreenieAndNfcCaptures = 200,
                ClanSpecialsCapPts = 2000,
                ClanDeploys = 30,
                ClanPoints = 12000,
            });
            level.Add(2, new Requirements1604()
            {
                PlayerPoints = 2000,
                ClanGreenieAndNfcCaptures = 400,
                ClanSpecialsCapPts = 4000,
                ClanDeploys = 80,
                ClanPoints = 30000
            });
            level.Add(3, new Requirements1604()
            {
                PlayerPoints = 5000,
                ClanGreenieAndNfcCaptures = 600,
                ClanSpecialsCapPts = 6000,
                ClanDeploys = 150,
                ClanPoints = 70000
            });
            level.Add(4, new Requirements1604()
            {
                PlayerPoints = 16000,
                ClanGreenieAndNfcCaptures = 900,
                ClanSpecialsCapPts = 8000,
                ClanDeploys = 300,
                ClanPoints = 200000

            });
            level.Add(5, new Requirements1604()
            {
                PlayerPoints = 28000,
                ClanGreenieAndNfcCaptures = 1250,
                ClanSpecialsCapPts = 12000,
                ClanDeploys = 500,
                ClanPoints = 380000
            });
        }
    }

    public class Level1603
    {
        public Dictionary<int, Requirements1603> level = new Dictionary<int, Requirements1603>();

        public Level1603()
        {
            level.Add(1, new Requirements1603()
            {
                PlayerPoints = 1000,
                ClanGreenieCaptures = 300,
                ClanJewelsCap = 30,
                ClanDeploys = 50,
                ClanPoints = 12000,
            });
            level.Add(2, new Requirements1603()
            {
                PlayerPoints = 2000,
                ClanGreenieCaptures = 1000,
                ClanJewelsCap = 100,
                ClanDeploys = 100,
                ClanPoints = 30000
            });
            level.Add(3, new Requirements1603()
            {
                PlayerPoints = 5000,
                ClanGreenieCaptures = 1500,
                ClanJewelsCap = 150,
                ClanDeploys = 150,
                ClanPoints = 70000
            });
            level.Add(4, new Requirements1603()
            {
                PlayerPoints = 15000,
                ClanGreenieCaptures = 2500,
                ClanJewelsCap = 200,
                ClanDeploys = 300,
                ClanPoints = 200000

            });
            level.Add(5, new Requirements1603()
            {
                PlayerPoints = 25000,
                ClanGreenieCaptures = 3000,
                ClanJewelsCap = 300, 
                ClanDeploys = 500,
                ClanPoints = 350000
            });
        }
    }

    public class Level1512
    {
        public Dictionary<int, Requirements1512> level = new Dictionary<int, Requirements1512>();

        public Level1512()
        {
            level.Add(1, new Requirements1512()
            {
                PlayerPoints = 1000,
                ClanCaptures = 200,
                ClanDeploys = 10,
                ClanTrailStagesCaptures = 5,
                ClanPoints = 12000,
            });
            level.Add(2, new Requirements1512()
            {
                PlayerPoints = 2000,
                ClanCaptures = 800,
                ClanDeploys = 80,
                ClanTrailStagesCaptures = 15,
                ClanPoints = 30000
            });
            level.Add(3, new Requirements1512()
            {
                PlayerPoints = 4000,
                ClanCaptures = 1600,
                ClanDeploys = 120,
                ClanTrailStagesCaptures = 20,
                ClanPoints = 70000
            });
            level.Add(4, new Requirements1512()
            {
                PlayerPoints = 12000,
                ClanCaptures = 2300,
                ClanDeploys = 200,
                ClanTrailStagesCaptures = 40,
                ClanPoints = 180000

            });
            level.Add(5, new Requirements1512()
            {
                PlayerPoints = 20000,
                ClanCaptures = 2800,
                ClanDeploys = 600,
                ClanTrailStagesCaptures = 60,
                ClanPoints = 350000
            });
        }
    }



    public class Level1511
    {
        public Dictionary<int, Requirements1511> level = new Dictionary<int, Requirements1511>();

        public Level1511()
        {
            level.Add(1, new Requirements1511()
            {
                PlayerPoints = 1000,
                ClanCaptures = 200,
                ClanMotelsHotels = 5,
                ClanDeploys = 20,
                ClanPoints = 12000,
            });
            level.Add(2, new Requirements1511()
            {
                PlayerPoints = 2000,
                ClanCaptures = 800,
                ClanMotelsHotels = 10,
                ClanDeploys = 100,
                ClanPoints = 30000
            });
            level.Add(3, new Requirements1511()
            {
                PlayerPoints = 5000,
                ClanCaptures = 1600,
                ClanMotelsHotels = 15,
                ClanDeploys = 150,
                ClanPoints = 70000
            });
            level.Add(4, new Requirements1511()
            {
                PlayerPoints = 15000,
                ClanCaptures = 2300,
                ClanMotelsHotels = 25,
                ClanDeploys = 300,
                ClanPoints = 200000
                
            });
            level.Add(5, new Requirements1511()
            {
                PlayerPoints = 20000,
                ClanCaptures = 2800,
                ClanMotelsHotels = 35,
                ClanDeploys = 600,
                ClanPoints = 350000
            });
        }
    }

    public class Level1509
    {
        public Dictionary<int, Requirements1509> level = new Dictionary<int, Requirements1509>();

        public Level1509()
        {
            level.Add(1, new Requirements1509()
            {
                PlayerPoints = 1000,
                ClanPoints = 12000,
                ClanDeployGreens = 100,
                ClanDeployNumber = 150,
                ClanFyzicalMysteryCapturePoints = 2500

            });
            level.Add(2, new Requirements1509()
            {
                PlayerPoints = 2000,
                ClanPoints = 30000,
                ClanDeployGreens = 200,
                ClanDeployNumber = 300,
                ClanFyzicalMysteryCapturePoints = 4000
            });
            level.Add(3, new Requirements1509()
            {
                PlayerPoints = 5000,
                ClanPoints = 70000,
                ClanDeployGreens = 400,
                ClanDeployNumber = 600,
                ClanFyzicalMysteryCapturePoints = 6000
            });
            level.Add(4, new Requirements1509()
            {
                PlayerPoints = 15000,
                ClanPoints = 200000,
                ClanDeployGreens = 700,
                ClanDeployNumber = 1000,
                ClanFyzicalMysteryCapturePoints = 8500
            });
            level.Add(5, new Requirements1509()
            {
                PlayerPoints = 25000,
                ClanPoints = 350000,
                ClanDeployGreens = 1000,
                ClanDeployNumber = 1500,
                ClanFyzicalMysteryCapturePoints = 12000
            });
        }
    }
    public class Level1510
    {
        public Dictionary<int, Requirements1510> level = new Dictionary<int, Requirements1510>();

        public Level1510()
        {
            level.Add(1, new Requirements1510()
            {
                JewelsNumbers = 1,
                ClanJewels   = 20,
                ClanPoints = 1000
               

            });
            level.Add(2, new Requirements1510()
            {
                JewelsNumbers = 5,
                ClanJewels   = 100,
                ClanPoints= 7000
            });
            level.Add(3, new Requirements1510()
            {
                JewelsNumbers = 15,
                ClanJewels   = 250,
                ClanPoints = 35000
            });
            level.Add(4, new Requirements1510()
            {
                JewelsNumbers = 30,
                ClanJewels   = 450,
                ClanPoints = 75000
            });
            level.Add(5, new Requirements1510()
            {
                JewelsNumbers = 50,
                ClanJewels  = 700,
                ClanPoints = 100000
            });
        }
    }


    public class Level1507
    {
        public Dictionary<int, Requirements1507> level = new Dictionary<int, Requirements1507>();

        public Level1507()
        {
            level.Add(1, new Requirements1507()
            {
                ActivePoints = 100,
                ClanActivePoints = 1200
            });
            level.Add(2, new Requirements1507()
            {
                ActivePoints = 250,
                ClanActivePoints = 3000
            });
            level.Add(3, new Requirements1507()
            {
                ActivePoints = 500,
                ClanActivePoints = 6000
            });
            level.Add(4, new Requirements1507()
            {
                ActivePoints = 1500,
                ClanActivePoints = 18000
            });
            level.Add(5, new Requirements1507()
            {
                ActivePoints = 3000,
                ClanActivePoints = 35000
            });
        }
    }

    public class Level1506
    {
        public Dictionary<int, Requirements1506> level = new Dictionary<int, Requirements1506>();

        public Level1506()
        {
            level.Add(1, new Requirements1506()
            {
                NumberOfDeploy = 0,
                ActiveDays = 0,
                PlayerCapturePoints = 0,
                PlayerPoints = 800,
                ClanPoints = 10000
            });
            level.Add(2, new Requirements1506()
            {
                NumberOfDeploy = 5,
                ActiveDays = 0,
                PlayerCapturePoints = 800,
                PlayerPoints = 1500,
                ClanPoints = 20000
            });
            level.Add(3, new Requirements1506()
            {
                NumberOfDeploy = 20,
                ActiveDays = 10,
                PlayerCapturePoints = 2000,
                PlayerPoints = 4000,
                ClanPoints = 50000
            });
            level.Add(4, new Requirements1506()
            {
                NumberOfDeploy = 30,
                ActiveDays = 14,
                PlayerCapturePoints = 5000,
                PlayerPoints = 10000,
                ClanPoints = 140000
            });
            level.Add(5, new Requirements1506()
            {
                NumberOfDeploy = 50,
                ActiveDays = 21,
                PlayerCapturePoints = 10000,
                PlayerPoints = 20000,
                ClanPoints = 250000
            });
        }
    }

    public class Level1505
    {
        public Dictionary<int, Requirements1505> level = new Dictionary<int, Requirements1505>();

        public Level1505()
        {
            level.Add(1, new Requirements1505()
            {
                NumberOfDeploy = 0,
                SpecialPlayerPoints = 0,
                PlayerPoints = 800,
                ClanPoints = 10000
            });
            level.Add(2, new Requirements1505()
            {
                NumberOfDeploy = 5,
                SpecialPlayerPoints = 100,
                PlayerPoints = 1500,
                ClanPoints = 20000
            });
            level.Add(3, new Requirements1505()
            {
                NumberOfDeploy = 15,
                SpecialPlayerPoints = 150,
                PlayerPoints = 3000,
                ClanPoints = 40000
            });
            level.Add(4, new Requirements1505()
            {
                NumberOfDeploy = 25,
                SpecialPlayerPoints = 300,
                PlayerPoints = 10000,
                ClanPoints = 110000

            });
            level.Add(5, new Requirements1505()
            {
                NumberOfDeploy = 50,
                SpecialPlayerPoints = 500,
                PlayerPoints = 18000,
                ClanPoints = 220000
            });
        }
    }

    public class Requirements1610
    {
        public int PlayerTotal;
        public int PlayerActivity;
        public int ClanTotal;
        public int ClanActivity;
    }

    public class Requirements1609
    {
        public int PlayerPts;
        public int PlayerDeploys;
        public int ClanDeploys;
        public int ClanCaps;
        public int ClanPts;
    }

    public class Requirements1608
    {
        public int PlayerPts;
        public int ClanJewelDeploys;
        public int ClanJewelCaps;
        public int ClanPts;
    }


    public class Requirements1607
    {
        public int ModifiedPts;
        public int ClanModifiedPts;
    }

    public class Requirements1606
    {
        public int PlayerPoints;
        public int ClanNumDeploys;
        public int ClanPoints;
    }


    public class Requirements1605
    {
        public int ClanActivityPts;
        public int ClanPoints;
    }

    public class Requirements1604
    {
        public int PlayerPoints;
        public int ClanGreenieAndNfcCaptures;
        public int ClanSpecialsCapPts;
        public int ClanDeploys;
        public int ClanPoints;
    }

    public class Requirements1603
    {
        public int PlayerPoints;
        public int ClanGreenieCaptures;
        public int ClanJewelsCap;
        public int ClanDeploys;
        public int ClanPoints;
    }

    public class Requirements1512
    {
        public int PlayerPoints;
        public int ClanCaptures;
        public int ClanDeploys;
        public int ClanTrailStagesCaptures;
        public int ClanPoints;
    }

    public class Requirements1511
    {
        public int PlayerPoints;
        public int ClanCaptures;
        public int ClanMotelsHotels;
        public int ClanDeploys;
        public int ClanPoints;
    }

    public class Requirements1510
    {
        public int JewelsNumbers;
        public int ClanPoints;
        public int ClanJewels;
    }

    public class Requirements1509
    {
        public int ClanDeployNumber;
        public int ClanDeployGreens;
        public int ClanFyzicalMysteryCapturePoints;
        public int PlayerPoints;
        public int ClanPoints;
    }

    public class Requirements1507
    {
        public int ActivePoints;
        public int ClanActivePoints;
    }

    public class Requirements1506
    {
        public int NumberOfDeploy;
        public int ActiveDays;
        public int PlayerCapturePoints;
        public int PlayerPoints;
        public int ClanPoints;
    }

    public class Requirements1505
    {
        public int NumberOfDeploy;
        public int SpecialPlayerPoints;
        public int PlayerPoints;
        public int ClanPoints;
    }
}