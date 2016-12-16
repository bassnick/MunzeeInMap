using System;
using System.Data.Common.CommandTrees;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;

namespace MunzeeInMap
{
    public class Communicate
    {
        public static async Task<string> Login()
        {
            string token = "AlJnQBamnf5yW2Irt2arCQFPmwzXTXYiy31J64Nc";
            string result = await LogIn(new Uri("https://api.munzee.com/oauth/login"), token);
            return result;
        }

        
        internal static string GetMunzeeById(FormCollection fd)
        {
            fd["data"] = "{\"munzee_id\":" + fd["munzee_id"] + "}";
            fd.Remove("munzee_id");
            string result = Send(new Uri("https://api.munzee.com/munzee/"), fd);
            return result;
        }
        internal static string GetMunzeeByUrl(FormCollection fd)
        {
            fd["data"] = "{\"url\":\"" + fd["munzee_url"] + "\"}";
            fd.Remove("munzee_url");
            string result = Send(new Uri("https://api.munzee.com/munzee/"), fd);
            return result;
        }


        internal static string GetRecentLogsOfMunzeeById(FormCollection fd)
        {
            fd["data"] = "{\"munzee_id\":" + fd["munzee_id"] + "}";
            fd.Remove("munzee_id");
            string result = Send(new Uri("https://api.munzee.com/munzee/logs/"), fd);
            return result;
        }

        private static async Task<string> LogIn(Uri uri, string token)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer",
                token);
            var builder = new UriBuilder(uri);
            

            var httpResponse =
                await client.PostAsync(builder.Uri, null);

            if (httpResponse.StatusCode == HttpStatusCode.OK)
            {
                return await httpResponse.Content.ReadAsStringAsync();
            }

            throw new Exception("HTTP chybka - " + httpResponse.StatusCode);
        }

        public static string Send(Uri uri, FormCollection nameValueCollection)
        {
            var webClient = new WebClient();
            try
            {
                byte[] responseArray = webClient.UploadValues(uri, nameValueCollection);
                return System.Text.Encoding.UTF8.GetString(responseArray);
            }
            catch (WebException e)
            {
                return string.Format("Chyba {0}", e.Message);
            }  
        }

        internal static string GetPlayerByName(FormCollection fd)
        {
            fd["data"] = "{\"username\":\"" + fd["username"] + "\"}";
            fd.Remove("username");
            string result = Send(new Uri("https://api.munzee.com/user/"), fd);
            return result;
        }

        internal static string GetPlayerById(FormCollection fd)
        {
            fd["data"] = "{\"user_id\":" + fd["user_id"] + "}";
            fd.Remove("user_id");
            string result = Send(new Uri("https://api.munzee.com/user/"), fd);
            return result;
        }

        internal static string GetDailyPlayerStats(FormCollection fd)
        {
            fd["data"] = "{\"day\":\"" + fd["day"] + "\"}";
            fd.Remove("day");
            string result = Send(new Uri("https://api.munzee.com/statzee/player/day/"), fd);
            return result;
        }

        internal static string GetCapturedTypesStats(FormCollection fd)
        {
            fd["data"] = "{\"username\":\"" + fd["username"] + "\"}";
            fd.Remove("username");
            string result = Send(new Uri("https://api.munzee.com/statzee/player/captures/types/"), fd);
            return result;
        }

        internal static string GetDeployedTypesStats(FormCollection fd)
        {
            fd["data"] = "{\"username\":\"" + fd["username"] + "\"}";
            fd.Remove("username");
            string result = Send(new Uri("https://api.munzee.com/statzee/player/deploys/types/"), fd);
            return result;
        }

        internal static string GetClanId(FormCollection fd)
        {
            fd["data"] = "{\"simple_name\":\"" + fd["simple_name"] + "\"}";
            fd.Remove("simple_name");
            string result = Send(new Uri("https://api.munzee.com/clan/id/"), fd);
            return result;
        }

        internal static string GetClanDetails(FormCollection fd)
        {
            fd["data"] = "{\"clan_id\":" + fd["clan_id"] + "}";
            fd.Remove("clan_id");
            string result = Send(new Uri("https://api.munzee.com/clan/"), fd);
            return result;
        }

        internal static string GetClanStatistics(FormCollection fd)
        {
            fd["data"] = "{\"clan_id\":" + fd["clan_id"] + "}";
            fd.Remove("clan_id");
            string result = Send(new Uri("https://api.munzee.com/clan/stats/"), fd);
            return result;
        }

        internal static string GetCaptureDaysStats(FormCollection fd)
        {
            fd["data"] = "{\"username\":\"" + fd["username"] + "\"}";
            fd.Remove("username");
            string result = Send(new Uri("https://api.munzee.com/statzee/player/captures/"), fd);
            return result;
        }

        internal static string GetDeployDaysStats(FormCollection fd)
        {
            fd["data"] = "{\"username\":\"" + fd["username"] + "\"}";
            fd.Remove("username");
            string result = Send(new Uri("https://api.munzee.com/statzee/player/deploys/"), fd);
            return result;
        }

        internal static string GetGlobalStats(FormCollection fd)
        {
            fd["data"] = "{\"limit\":" + fd["limit"] + "}";
            fd.Remove("limit");
            string result = Send(new Uri("https://api.munzee.com/leaderboard/players/overall/"), fd);
            return result;
        }

        internal static string GetForRange(FormCollection fd)
        {
            fd["data"] = "{\"start\":\"" + fd["start"] + "\",\"end\":\""+fd["end"]+  "\", \"limit\":" + fd["limit"] + "}";
            fd.Remove("limit");
            fd.Remove("start");
            fd.Remove("end");
            string result = Send(new Uri("https://api.munzee.com/leaderboard/players/"), fd);
            return result;
        }

        public static string BoundingBox(FormCollection fd)
        {
            string points;
            if (!fd["points"].IsNullOrWhiteSpace())
            {
                points = fd["points"];
            }
            else
            {


                float centerLat = float.Parse(fd["centerLat"].Replace('.', ','));
                float centerLng = float.Parse(fd["centerLng"].Replace('.', ','));
                float radiusKm = float.Parse(fd["radiusKm"].Replace('.', ','));
                GpsObject center = new GpsObject(centerLng, centerLat);
                GpsObject[] boundary = center.GetBoundary(radiusKm);

                points =
                    "{\"box1\":{\"timestamp\": 0,\"lat2\":" + boundary[1].Latitude.ToString().Replace(',', '.') +
                    ",\"lng1\":" + boundary[0].Longitude.ToString().Replace(',', '.') + ",\"lng2\":" +
                    boundary[1].Longitude.ToString().Replace(',', '.') + ",\"lat1\":" +
                    boundary[0].Latitude.ToString().Replace(',', '.') + "}}";
            }

            fd["data"] = "{\"exclude\":\"" + fd["exclude"] + "\", \"limit\":" + fd["limit"] + ",\"fields\":\"" +
                         fd["fields"] + "\",\"points\":" + points + "}";
            fd.Remove("exclude");
            fd.Remove("limit");
            fd.Remove("fields");
            fd.Remove("points");
            fd.Remove("centerLat");
            fd.Remove("centerLng");
            fd.Remove("radiusKm");
            string result = Send(new Uri("https://api.munzee.com/map/boundingbox/"), fd);
            return result;

        }
    }
}