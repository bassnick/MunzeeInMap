using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MunzeeInMap.Controllers
{
    public class AuthorizeController : Controller
    {
        //
        // GET: /Authorize/

        public ActionResult Index()
        {
            string cookieName = "bassnick_munzee_in_map";
            string cookieNameId = "bassnick_munzee_in_map_userId";
            if (Request.Cookies[cookieName] == null || Request.Cookies[cookieNameId] == null)
            {
                return
                    Redirect(
                        "https://api.munzee.com/oauth?response_type=code&client_id=f0f0ca784cda6781a859826c71d0a06e&redirect_uri=http://bassnick.cz/MunzeeInMap&scope=read");
            }
            else
            {
               return RedirectToAction("BoundingBox", "MunzeeInMap");
            }
            
        }

        public ActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index2(FormCollection fd)
        {
            string code = fd["code"];
            fd.Remove("code");
            //curl -X POST --data "client_id=f0f0ca784cda6781a859826c71d0a06e&client_secret=c93854b448f6b4d976141a8c&grant_type=authorization_code&code=Ok0zCydB6QhSGjzr5OVu0blbz99p84oa1kVoMfWc&redirect_uri=http://bassnick.cz/MunzeeInMap" https://api.munzee.com/oauth/login
            string client_id = "f0f0ca784cda6781a859826c71d0a06e";
            string client_secret = "c93854b448f6b4d976141a8c";
            string grant_type = "authorization_code";
            string redirect_uri = "http://bassnick.cz/MunzeeInMap";
            fd.Add("client_id", client_id);
            fd.Add("client_secret", client_secret);
            fd.Add("grant_type", grant_type);
            fd.Add("code", code);
            fd.Add("redirect_uri", redirect_uri);
            
            //fd.Remove("code");

            //fd["data"] = "{client_id:f0f0ca784cda6781a859826c71d0a06e,client_secret:c93854b448f6b4d976141a8c,grant_type:authorization_code,code:"+fd["code"]+",redirect_uri:http://bassnick.cz/MunzeeInMap/Print}";
            //fd.Add("data", string.Format("{5}client_id{5}{6}{5}{0}{5}{7}{5}client_secret{5}{6}{5}{1}{5}{7}{5}grant_type{5}{6}{5}{2}{5}{7}{5}code{5}{6}{5}{3}{5}{7}{5}redirect_uri{5}{6}{5}{4}{5}",
            //    client_id, client_secret, grant_type, code, redirect_uri, "", "=", "&"));
            string x = Communicate.Send(new Uri("https://api.munzee.com/oauth/login"), fd);
            
            //string u = String.Format("https://api.munzee.com/oauth/login?client_id=f0f0ca784cda6781a859826c71d0a06e&client_secret=c93854b448f6b4d976141a8c&grant_type=authorization_code&code={0}&redirect_uri=http://bassnick.cz/MunzeeInMap", code);
            //string x = Communicate.Send(new Uri(u), new FormCollection());

            string y = x;
            return View();
        }
    }
}
