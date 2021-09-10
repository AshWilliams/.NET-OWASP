using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NETCore3Angular.Controllers
{
    public class GatewayController : Controller
    {
        UrlEncoder _urlEncoder;
        public GatewayController(UrlEncoder urlEncoder)
        {
            _urlEncoder = urlEncoder;
        }
        // GET: GatewayController
        public ActionResult Index()
        {
            return View();
        }

        // GET: GatewayController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            string apiResponse = string.Empty;
            JObject swapipeople;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://swapi.dev/api/people/" + id.ToString()))
                {
                    apiResponse = await response.Content.ReadAsStringAsync();
                    swapipeople = JObject.Parse(apiResponse);
                }
            }
            return Json(swapipeople);
        }

        // GET: GatewayController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: GatewayController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GatewayController/Edit/5
        public ActionResult Edit(string test)
        {
            //http://localhost:49590/gateway/edit?test="<script>alert(1)</script>"
            var sanitized = _urlEncoder.Encode(test);
            return Content(sanitized);
        }

        // POST: GatewayController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: GatewayController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: GatewayController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
