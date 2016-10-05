using MunzeeInMap.MunzeeAppObjects;
using System;
using System.Collections.Generic;
using System.Data.Metadata.Edm;
using System.EnterpriseServices;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.XPath;
using Microsoft.Ajax.Utilities;
using WebGrease.Css.ImageAssemblyAnalysis.LogModel;

namespace MunzeeInMap.Controllers
{
    public static class Extension
    {
        public static string ToXMLString(this DateTime d)
        {
            int year = d.Year;
            int month = d.Month;
            int day = d.Day;
            int hour = d.Hour;
            int minute = d.Minute;
            int second = d.Second;
            int millisecond = d.Millisecond;

            //2015-05-12T23:27:58.191
            string result = string.Format("{0}-{1}-{2}T{3}:{4}:{5}.{6}", year, month, day, hour, minute, second,
                millisecond);
            return result;
        }
    }


    public class MunzeeInMapController : Controller
    {
        //
        // GET: /
        [HttpGet]
        public ActionResult Index()
        {
            string dayStr = CitesLogic.GetCiteOfToday();
            return View("Index", "",  dayStr);
        }

        //
        // GET: /MunzeeeInMap
        [HttpGet]
        public async Task<ActionResult> MunzeeApp()
        {
            string str = await Communicate.Login();
            return View("MunzeeApp");
        }

        public ActionResult Print()
        {
            return View();
        }

        //
        // GET: /MunzeeeInMap/GetMunzeeById
        [HttpGet]
        public async Task<ActionResult> GetMunzeeById()
        {
            string str = await Communicate.Login();

            return View("GetMunzeeById", "", str);
        }

        //
        // POST: /MunzeeInMap/GetMunzeeById
        [HttpPost]
        public ActionResult GetMunzeeById(FormCollection fd)
        {
            string str = Communicate.GetMunzeeById(fd);

            MunzeeById data = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<MunzeeById>(str);
            return View("DisplayResult", "", str);
        }
        //
        // GET: /MunzeeeInMap/GetMunzeeByUrl
        [HttpGet]
        public async Task<ActionResult> GetMunzeeByUrl()
        {
            string str = await Communicate.Login();

            return View("GetMunzeeByUrl", "", str);
        }

        //
        // POST: /MunzeeInMap/GetMunzeeByUrl
        [HttpPost]
        public ActionResult GetMunzeeByUrl(FormCollection fd)
        {
            string str = Communicate.GetMunzeeByUrl(fd);

            MunzeeById data = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<MunzeeById>(str);
            return View("DisplayResult", "", str);
        }
        
        //
        // GET: /MunzeeeInMap/GetMunzeeRecentLogs
        [HttpGet]
        public async Task<ActionResult> GetMunzeeRecentLogs()
        {
            string str = await Communicate.Login();

            return View("GetMunzeeRecentLogs", "", str);
        }

        //
        // POST: /MunzeeInMap/GetMunzeeRecentLogs
        [HttpPost]
        public ActionResult GetMunzeeRecentLogs(FormCollection fd)
        {
            string str = Communicate.GetRecentLogsOfMunzeeById(fd);

            MunzeeLogs data = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<MunzeeLogs>(str);
            return View("DisplayResult", "", str);
        }

        //
        // GET: /MunzeeeInMap/GetPlayerByName
        [HttpGet]
        public async Task<ActionResult> GetPlayerByName()
        {
            string str = await Communicate.Login();

            return View("GetPlayerByName", "", str);
        }

        //
        // POST: /MunzeeInMap/GetMunzeeRecentLogs
        [HttpPost]
        public ActionResult GetPlayerByName(FormCollection fd)
        {
            string str = Communicate.GetPlayerByName(fd);

            PlayerInfo data = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<PlayerInfo>(str);
            return View("DisplayResult", "", str);
        }

        //
        // GET: /MunzeeeInMap/GetPlayerByName
        [HttpGet]
        public async Task<ActionResult> GetPlayerById()
        {
            string str = await Communicate.Login();

            return View("GetPlayerById", "", str);
        }

        //
        // POST: /MunzeeInMap/GetMunzeeRecentLogs
        [HttpPost]
        public ActionResult GetPlayerById(FormCollection fd)
        {
            string str = Communicate.GetPlayerById(fd);

            PlayerInfo data = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<PlayerInfo>(str);
            return View("DisplayResult", "", str);
        }

        //
        // GET: /MunzeeeInMap/GetPlayerByName
        [HttpGet]
        public async Task<ActionResult> GetDailyPlayerStats()
        {
            string str = await Communicate.Login();

            return View("GetDailyPlayerStats", "", str);
        }

        //
        // POST: /MunzeeInMap/GetMunzeeRecentLogs
        [HttpPost]
        public ActionResult GetDailyPlayerStats(FormCollection fd)
        {
            string str = Communicate.GetDailyPlayerStats(fd);

            DailyPlayerStats data = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<DailyPlayerStats>(str);
            return View("DisplayResult", "", str);
        }

        //
        // GET: /MunzeeeInMap/GetPlayerByName
        [HttpGet]
        public async Task<ActionResult> GetCapturedTypesStats()
        {
            string str = await Communicate.Login();

            return View("GetCapturedTypesStats", "", str);
        }

        //
        // POST: /MunzeeInMap/GetMunzeeRecentLogs
        [HttpPost]
        public ActionResult GetCapturedTypesStats(FormCollection fd)
        {
            string str = Communicate.GetCapturedTypesStats(fd);

            TypesStats data = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<TypesStats>(str);
            return View("DisplayResult", "", str);
        }

        //
        // GET: /MunzeeeInMap/GetPlayerByName
        [HttpGet]
        public async Task<ActionResult> GetDeployedTypesStats()
        {
            string str = await Communicate.Login();

            return View("GetDeployedTypesStats", "", str);
        }

        //
        // POST: /MunzeeInMap/GetMunzeeRecentLogs
        [HttpPost]
        public ActionResult GetDeployedTypesStats(FormCollection fd)
        {
            string str = Communicate.GetDeployedTypesStats(fd);

            TypesDeployStats data = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<TypesDeployStats>(str);
            return View("DisplayResult", "", str);
        }
        //
        // GET: /MunzeeeInMap/GetPlayerByName
        [HttpGet]
        public async Task<ActionResult> GetCaptureDaysStats()
        {
            string str = await Communicate.Login();

            return View("GetCaptureDaysStats", "", str);
        }

        //
        // POST: /MunzeeInMap/GetMunzeeRecentLogs
        [HttpPost]
        public ActionResult GetCaptureDaysStats(FormCollection fd)
        {
            string str = Communicate.GetCaptureDaysStats(fd);

            List<DayStats> days = ParseStreak(str);
            return View("DisplayResult", "", str);
        }

        //
        // GET: /MunzeeeInMap/GetPlayerByName
        [HttpGet]
        public async Task<ActionResult> GetDeployDaysStats()
        {
            string str = await Communicate.Login();

            return View("GetDeployDaysStats", "", str);
        }

        //
        // POST: /MunzeeInMap/GetMunzeeRecentLogs
        [HttpPost]
        public ActionResult GetDeployDaysStats(FormCollection fd)
        {
            string str = Communicate.GetDeployDaysStats(fd);

            List<DayStats> days = ParseStreak(str);
            return View("DisplayResult", "", str);
        }

        

        private static List<DayStats> ParseStreak(string str)
        {
            int indexOfBeginingContent = str.IndexOf("{", 5);
            str = str.Substring(indexOfBeginingContent);
            int indexOfEndContent = str.IndexOf("}");
            str = str.Substring(1, indexOfEndContent - 1);
            string[] records = str.Split(',');
            List<DayStats> days = new List<DayStats>();

            foreach (var day in records)
            {
                string[] items = day.Split(':');
                string date = items[0];
                string value = items[1];
                string[] rmd = date.Split('-');
                int year = int.Parse(rmd[0].Trim('"'));
                int month = int.Parse(rmd[1].Trim('"'));
                int oneday = int.Parse(rmd[2].Trim('"'));
                days.Add(new DayStats()
                {
                    Day = new DateTime(year, month, oneday),
                    Number = int.Parse(value.Trim('"'))
                });
            }
            return days;
        }


        //
        // GET: /MunzeeeInMap/GetPlayerByName
        [HttpGet]
        public async Task<ActionResult> GetClanId()
        {
            string str = await Communicate.Login();

            return View("GetClanId", "", str);
        }

        //
        // POST: /MunzeeInMap/GetMunzeeRecentLogs
        [HttpPost]
        public ActionResult GetClanId(FormCollection fd)
        {
            string str = Communicate.GetClanId(fd);

            return View("DisplayResult", "", str);
        }

        [HttpGet]
        public async Task<ActionResult> GetClanDetails()
        {
            string str = await Communicate.Login();

            return View("GetClanDetails", "", str);
        }

        [HttpPost]
        public ActionResult GetClanDetails(FormCollection fd)
        {
            string str = Communicate.GetClanDetails(fd);

            return View("DisplayResult", "", str);
        }

        //
        // GET: /MunzeeeInMap/GetPlayerByName
        [HttpGet]
        public async Task<ActionResult> GetClanStatistics()
        {
            string str = await Communicate.Login();

            return View("GetClanStatistics", "", str);
        }

//
        // POST: /MunzeeInMap/GetMunzeeRecentLogs
        [HttpPost]
        public ActionResult GetClanStatistics(FormCollection fd)
        {
            string str = Communicate.GetClanStatistics(fd);

            return View("DisplayResult", "", str);
        }

        //
        // GET: /MunzeeeInMap/GetPlayerByName
        [HttpGet]
        public async Task<ActionResult> GetGlobalStats()
        {
            string str = await Communicate.Login();

            return View("GetGlobalStats", "", str);
        }

        //
        // POST: /MunzeeInMap/GetMunzeeRecentLogs
        [HttpPost]
        public ActionResult GetGlobalStats(FormCollection fd)
        {
            string str = Communicate.GetGlobalStats(fd);

            GlobalLeader data = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<GlobalLeader>(str);
            return View("DisplayResult", "", str);
        }
        //
        // GET: /MunzeeeInMap/GetPlayerByName
        [HttpGet]
        public async Task<ActionResult> GetForRange()
        {
            string str = await Communicate.Login();

            return View("GetForRange", "", str);
        }

        //
        // POST: /MunzeeInMap/GetMunzeeRecentLogs
        [HttpPost]
        public ActionResult GetForRange(FormCollection fd)
        {
            string str = Communicate.GetForRange(fd);

            RangeLeader data = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<RangeLeader>(str);
            return View("DisplayResult", "", str);
        }


        public ActionResult ForceExpiration()
        {
            string cookieName = "bassnick_munzee_in_map";
            string cookieNameId = "bassnick_munzee_in_map_userId";
            if (Request.Cookies[cookieName] != null)
            {
                HttpCookie aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(aCookie);
            }
            if (Request.Cookies[cookieNameId] != null)
            {
                HttpCookie bCookie = new HttpCookie(cookieNameId);
                bCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(bCookie);
            }
            
            return Redirect("http://bassnick.cz/");
        }

        //
        // GET: /MunzeeeInMap/GetPlayerByName
        [HttpGet]
        public async Task<ActionResult> BoundingBox(string code)
        {
            //return Redirect("https://api.munzee.com/oauth?response_type=code&client_id=f0f0ca784cda6781a859826c71d0a06e&redirect_uri=http://bassnick.cz/MunzeeInMap");
            return View("BoundingBox", "", code);
        }

        //
        // POST: /MunzeeInMap/BoundingBox
        /*[HttpPost]
        public ActionResult BoundingBox(FormCollection fd)
        {
            string str = Communicate.BoundingBox(fd);

            BondingObjects data = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<BondingObjects>(str);
            string result = DownloadGPX(data);
            return View("DisplayResult", "", str);
        }
        */

        [HttpPost]
        public ActionResult BoundingBox(FormCollection fd)
        {
            string cookieName = "bassnick_munzee_in_map";
            string cookieNameId = "bassnick_munzee_in_map_userId";

            if (Request.Cookies[cookieName] == null)
            {
                FormCollection fcAuth = new FormCollection();
                string code = fd["code"];
                //fd.Remove("code");
                string client_id = "f0f0ca784cda6781a859826c71d0a06e";
                string client_secret = "c93854b448f6b4d976141a8c";
                string grant_type = "authorization_code";
                string redirect_uri = "http://bassnick.cz/MunzeeInMap";
                fcAuth.Add("client_id", client_id);
                fcAuth.Add("client_secret", client_secret);
                fcAuth.Add("grant_type", grant_type);
                fcAuth.Add("code", code);
                fcAuth.Add("redirect_uri", redirect_uri);

                string x = Communicate.Send(new Uri("https://api.munzee.com/oauth/login"), fcAuth);
                try
                {
                    AuthorizeObject authorizeObject =
                        new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<AuthorizeObject>(x);
                    if (authorizeObject.status_code != 200 || authorizeObject.status_text != "OK")
                        return null;

                    string accessToken = authorizeObject.data.token.access_token;
                    string userId = authorizeObject.data.user_id.ToString();

                    HttpCookie cookieAccessToken = new HttpCookie(cookieName);
                    cookieAccessToken.Value = accessToken;
                    cookieAccessToken.Expires = DateTime.Now.AddHours(6*24 + 22);
                    Response.Cookies.Add(cookieAccessToken); // NEW

                    HttpCookie cookieUserId = new HttpCookie(cookieNameId);
                    cookieUserId.Value = userId;
                    cookieUserId.Expires = DateTime.Now.AddHours(6*24 + 22);
                    HttpContext.Response.SetCookie(cookieUserId);
                    Response.Cookies.Add(cookieUserId); // NEW

                    FormCollection fcUser = new FormCollection();
                    fcUser.Add("access_token", accessToken);
                    fcUser.Add("user_id", userId);
                    string strUser = Communicate.GetPlayerById(fcUser);
                    PlayerInfo dataUser =
                        new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<PlayerInfo>(strUser);

                    bool withoutLogs = true;

                    fd.Add("access_token", authorizeObject.data.token.access_token);

                    string str = Communicate.BoundingBox(fd);

                    BoundingObjects data =
                        new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<BoundingObjects>(str);
                    string result = DownloadGPX(data, fd, dataUser.data.username, withoutLogs);
                    string fileName = "Munzee.gpx";
                    byte[] fileBytes = GetBytes(result);
                    if (fileBytes != null)
                    {
                        TempData["errorMessage"] = null;
                        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
                    }
                    else
                    {
                        TempData["errorMessage"] = "Zvolená oblast je příliš velká";
                        return View("BoundingBox");
                    } 
                }
                catch (Exception exc)
                {
                    TempData["errorMessage"] = string.Format("Null, {0}\r\n\r\n{1}\r\n-{2}-", exc.Message, exc.InnerException);
                    return View("BoundingBox");
                }
            }
            else
            {
                try
                {
                    string accessToken = Request.Cookies[cookieName].Value;
                    string userId = Request.Cookies[cookieNameId].Value;
                    FormCollection fcUser = new FormCollection();
                    fcUser.Add("access_token", accessToken);
                    fcUser.Add("user_id", userId);
                    string strUser = Communicate.GetPlayerById(fcUser);
                    PlayerInfo dataUser =
                        new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<PlayerInfo>(strUser);

                    bool withoutLogs = true;

                    fd.Add("access_token", accessToken);

                    string str = Communicate.BoundingBox(fd);

                    BoundingObjects data =
                        new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<BoundingObjects>(str);
                    string result = DownloadGPX(data, fd, dataUser.data.username, withoutLogs);
                    string fileName = "Munzee.gpx";
                    byte[] fileBytes = GetBytes(result);

                    if (fileBytes != null)
                    {
                        TempData["errorMessage"] = null;
                        return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
                    }
                    else
                    {
                        TempData["errorMessage"] = "Zvolená oblast je příliš velká";
                        return View("BoundingBox");
                    }
                }
            
            catch
                (Exception exc)
                {
                    TempData["errorMessage"] = string.Format("Not null, {0}\r\n\r\n{1}\r\n-{2}-", exc.Message, exc.InnerException);
                    return View("BoundingBox");
                }
            }
        }

        private string DownloadGPX(BoundingObjects data, FormCollection fd, string user, bool withoutLogs)
        {
            try
            {
                FormCollection userCol = new FormCollection();
                userCol.Add("access_token", fd["access_token"]);
                userCol.Add("username", user);
                string str = Communicate.GetPlayerByName(userCol);
                PlayerInfo player = new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<PlayerInfo>(str);
                int pid = player.data.user_id;
                   
                StringBuilder sb = new StringBuilder();
                string xmlHead = "<?xml version=\"1.0\" encoding=\"utf-8\" standalone=\"no\"?>";
                sb = sb.Append(xmlHead);
                sb =
                    sb.Append(
                        "<gpx xmlns=\"http://www.topografix.com/GPX/1/1\" creator=\"GeoGet 2.9.2.759\" version=\"1.1\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:gpxx=\"http://www.garmin.com/xmlschemas/GpxExtensions/v3\" xsi:schemaLocation=\"http://geoget.ararat.cz/GpxExtensions/v2 http://geoget.ararat.cz/GpxExtensions/v2/geoget.xsd http://www.groundspeak.com/cache/1/0 http://www.groundspeak.com/cache/1/0/cache.xsd http://www.topografix.com/GPX/1/1 http://www.topografix.com/GPX/1/1/gpx.xsd http://www.garmin.com/xmlschemas/GpxExtensions/v3 http://www8.garmin.com/xmlschemas/GpxExtensionsv3.xsd\">");
                sb =
                    sb.Append(
                        " <metadata>                                                                                                                        ");
                sb =
                    sb.Append(
                        "   <desc>Geoget data file</desc>                                                                                                   ");
                sb =
                    sb.Append(
                        "   <time>").Append(DateTime.Now.ToXMLString()).Append("</time>                                                                                            ");
                sb =
                    sb.Append(
                        " </metadata>                                                                                                                       ");
                sb =
                    sb.Append(
                        "                                                                                                                                   ");
                foreach (var item in data.data)
                {
                    foreach (var munzee in item.munzees)
                    {
                        MunzeeLogs logy = null;
                        if (!withoutLogs)
                        {
                            FormCollection logCol = new FormCollection();
                            logCol.Add("access_token", fd["access_token"]);
                            logCol.Add("munzee_id", munzee.munzee_id);

                            string resultLogs = Communicate.GetRecentLogsOfMunzeeById(logCol);
                            logy =
                                new System.Web.Script.Serialization.JavaScriptSerializer().Deserialize<MunzeeLogs>(
                                    resultLogs);
                        }
                           

                        string headWpt = string.Format(" <wpt lat=\"{0}\" lon=\"{1}\">", munzee.latitude,
                            munzee.longitude);
                        sb = sb.Append(headWpt);
                        string time = string.Format("  <time>{0}</time>", munzee.deployed_at);
                        sb = sb.Append(time);
                        string name = string.Format("  <name>MU{0}</name>", munzee.munzee_id);
                        sb = sb.Append(name);
                        string desc = string.Format("  <desc><![CDATA[{0}]]></desc>", munzee.friendly_name);
                        sb = sb.Append(desc);
//                    sb = sb.Append("  <link href=\"C:\\cosi.bmp\" />");
                        sb = sb.Append("  <sym>Munzee</sym>");
                        sb = sb.Append("  <type>Munzee|").Append(munzee.type_name).Append("</type>");
                        sb = sb.Append("  <extensions>");
                        sb =
                            sb.Append(
                                string.Format(
                                    "   <groundspeak:cache id=\"{0}\" available=\"{1}\" archived=\"{2}\" xmlns:groundspeak=\"http://www.groundspeak.com/cache/1/0\">"
                                    , munzee.munzee_id, (munzee.deployed == 1), (munzee.archived == 1)));
                        sb =
                            sb.Append(string.Format("    <groundspeak:name><![CDATA[{0}]]></groundspeak:name>",
                                munzee.friendly_name));
                        sb =
                            sb.Append(string.Format("    <groundspeak:placed_by><![CDATA[{0}]]></groundspeak:placed_by>",
                                munzee.creator_username));
                        sb = sb.Append("    <groundspeak:type>").Append(munzee.type_name).Append("</groundspeak:type>");
                        sb =
                            sb.Append(
                                "    <groundspeak:short_description html=\"True\"><![CDATA[]]></groundspeak:short_description>       ");
                        sb =
                            sb.Append(
                                "    <groundspeak:long_description html=\"True\"><![CDATA[]]></groundspeak:long_description>         ");
                        sb =
                            sb.Append(
                                "    <groundspeak:encoded_hints><![CDATA[]]></groundspeak:encoded_hints>                             ");
                        sb =
                            sb.Append(
                                "    <groundspeak:logs>                                                                              ");

                        if (munzee.has_user_captured_munzee == 1 && munzee.creator_username != user)
                        {
                            StringBuilder slog = new StringBuilder("<groundspeak:log");
                            slog = slog.Append(string.Format(" id=\"{0}\">", -int.Parse(munzee.munzee_id)));
                            slog = slog.Append("<groundspeak:type>");
                            slog = slog.Append("Found it");
                            slog = slog.Append("</groundspeak:type>");
                            slog =
                                slog.Append(string.Format("<groundspeak:finder id=\"{0}\">{1}</groundspeak:finder>",
                                    pid, user));
                            slog = slog.Append(string.Format("<groundspeak:text encoded=\"False\"></groundspeak:text >"));
                            slog = slog.Append("</groundspeak:log>");
                            sb = sb.Append(slog);
                        }
                        if (!munzee.last_captured_at.IsNullOrWhiteSpace())
                        {
                            sb = sb.Append("<groundspeak:log");
                            sb = sb.Append(string.Format(" id=\"{0}\">", Int32.MinValue));
                            sb =
                                sb.Append(string.Format("<groundspeak:date>{0}</groundspeak:date>",
                                    munzee.last_captured_at));
                            sb = sb.Append("<groundspeak:type>");
                            sb = sb.Append("Found it");
                            sb = sb.Append("</groundspeak:type>");
                            sb = sb.Append("<groundspeak:finder id=\"0\">Last Capture</groundspeak:finder>");
                            sb = sb.Append(string.Format("<groundspeak:text encoded=\"False\"></groundspeak:text >"));
                            sb = sb.Append("</groundspeak:log>");
                        }
                        if (!withoutLogs)
                        {
                            foreach (Log log in logy.data)
                            {
                                StringBuilder slog = new StringBuilder("<groundspeak:log");
                                slog = slog.Append(string.Format(" id=\"{0}\">", log.entry_id));
                                slog =
                                    slog.Append(string.Format("<groundspeak:date>{0}</groundspeak:date>", log.entry_at));
                                slog = slog.Append("<groundspeak:type>");
                                if (log.type_name == "General Comment")
                                    slog = slog.Append("Found it");
                                else
                                    slog = slog.Append(log.type_name);
                                slog = slog.Append("</groundspeak:type>");
                                slog =
                                    slog.Append(string.Format("<groundspeak:finder id=\"{0}\">{1}</groundspeak:finder>",
                                        log.user_id, log.username));
                                slog =
                                    slog.Append(
                                        string.Format("<groundspeak:text encoded=\"False\">{0}</groundspeak:text >",
                                            log.notes));
                                slog = slog.Append("</groundspeak:log>");
                                sb = sb.Append(slog);
                            }
                        }

                        /*
         
        <groundspeak:log id="441785907">
          <groundspeak:date>2014-09-01T19:00:00Z</groundspeak:date>
          <groundspeak:type>Found it</groundspeak:type>
          <groundspeak:finder id="1504788">Kendar05</groundspeak:finder>
          <groundspeak:text encoded="False">Pracuju v areĂˇlu Tesly, tak uĹľ bych tuhle keĹˇku mÄ›la mĂ­t odlovenou dĂˇvno, ale kdyĹľ ono je k nĂ­ z budovy M8 tak daleko... Dnes jsem ale mÄ›la pochĹŻzku na C12, tak jsem po cestÄ› hrĂˇbla do porostu a keĹˇ byla moje.
DĂ­ky za pÄ›knÄ› provedenou keĹˇku s historkou navrch.</groundspeak:text>
        </groundspeak:log>
                        */
                        sb =
                            sb.Append(
                                "    </groundspeak:logs>                                                                             ");
                        sb =
                            sb.Append(
                                "   </groundspeak:cache>                                                                             ");
                        sb =
                            sb.Append(
                                "   <gpxg:GeogetExtension xmlns:gpxg=\"http://geoget.ararat.cz/GpxExtensions/v2\">                   ");
                        sb =
                            sb.Append(string.Format("     <gpxg:Comment><![CDATA[{0} created by {1}",
                                munzee.type_name,
                                munzee.creator_username));
                        sb = sb.AppendLine();
                        sb = sb.Append(string.Format("Captures: {0}", munzee.number_of_captures));
                        sb = sb.AppendLine();
                        sb = sb.Append(string.Format("Last Capture: {0}", munzee.last_captured_at));
                        sb = sb.AppendLine();
                        sb = sb.Append(string.Format("Last Update: {0}", munzee.last_updated_at));
                        sb = sb.AppendLine();
                        sb = sb.Append(string.Format("Virtual? {0}", (munzee.is_virtual == 1) ? "Yes" : "No"));
                        sb = sb.AppendLine();
                        sb = sb.Append(string.Format("Maintenance mode? {0}", (munzee.maintenance == 1) ? "Yes" : "No"));
                        sb = sb.AppendLine();
                        sb = sb.Append(string.Format("Proximity Radius ft = {0}", munzee.proximity_radius_ft));
                        sb = sb.AppendLine();
                        sb = sb.Append(string.Format("Code = {0}", munzee.code));
                        sb = sb.AppendLine();
                        sb = sb.Append(string.Format("{0}]]></gpxg:Comment>", munzee.notes));
                        sb = sb.AppendLine().AppendLine().AppendLine();

                        
/*
                    sb = sb.Append("     <gpxg:Tags>                                                                                    ");
                    sb = sb.Append("       <gpxg:Tag Category=\"Elevation\"><![CDATA[223]]></gpxg:Tag>                                  ");
                    sb = sb.Append("       <gpxg:Tag Category=\"import\"><![CDATA[Munzee_all.gpx]]></gpxg:Tag>                          ");
                    sb = sb.Append("       <gpxg:Tag Category=\"PocketQuery\"><![CDATA[Munzee GPX file from www.munzee.com]]></gpxg:Tag>");
                    sb = sb.Append("       <gpxg:Tag Category=\"timezone\"><![CDATA[America/Detroit]]></gpxg:Tag>                       ");
                    sb = sb.Append("     </gpxg:Tags>                                                                                   ");
*/
                        sb = sb.Append("   </gpxg:GeogetExtension>");
                        sb = sb.Append("   <gpxx:WaypointExtension>");
                        sb = sb.Append("     <gpxx:DisplayMode>SymbolOnly</gpxx:DisplayMode>");
                        sb = sb.Append("   </gpxx:WaypointExtension>");
                        sb = sb.Append("  </extensions>");
                        sb = sb.Append(" </wpt>");
                    }
                }
                sb = sb.Append("</gpx>");

                return sb.ToString();
            }
            catch (Exception exc)
            {
                return null;
            }

        }

        static byte[] GetBytes(string str)
        {
            try
            {
                if (str == null || str.Trim().Length == 0)
                    return null;
                byte[] toBytes = new byte[str.Length * sizeof(char)];
                toBytes = Encoding.UTF8.GetBytes(str);
                return toBytes;
            }
            catch (Exception)
            {

                return null;
            }
            
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }
    }
}
