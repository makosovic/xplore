using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using GooglePlacesApi;
using Newtonsoft.Json;
using Xplore.Web.Attributes;

namespace Xplore.Web.Controllers
{
    public class ListingsController : Controller
    {
        // GET: Listings
        public ActionResult Index()
        {
            ViewBag.Title = "Xplore Google Places";
            return View();
        }

        [AjaxOnly]
        [HttpGet]
        public object Search(string latitude, string longitude, string type)
        {
            string apiKey = WebConfigurationManager.AppSettings["GoogleApiKey"]; 

            NearbySearchRequest request = new NearbySearchRequest(apiKey, latitude, longitude, "1000", type);

            try
            {
                NearbySearchResponse result = request.Execute();

                return JsonConvert.SerializeObject(result.Results.Select(
                    x => new object[]
                    {
                        x.Icon,
                        x.Name, 
                        x.Opening_hours != null ? x.Opening_hours.Open_now ? "YES" : "NO" : "",
                        x.Types.Select(y => y.Replace("_", " ")).Aggregate((a, b) => a + ", " + b),
                        x.Vicinity
                    })
                );
            }
            catch (ApplicationException ex)
            {
                return string.Empty;
            }
        }
    }
}