using BidOne.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace BidOne.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration configuration;
        private readonly ILogger<HomeController> _logger;
        string APIURL = string.Empty;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            APIURL = configuration.GetSection("API").GetSection("APIURL").Value;
        }

        [HttpPost]
        public async Task<IActionResult> Signup(ApplicationUserModel applicationmodel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUserModel Getapplicationmodel = new ApplicationUserModel();
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync(APIURL + string.Format("Api/Home/FormSubmit?Firstname={0}&Lastname={1}", applicationmodel.Firstname, applicationmodel.Lastname)).Result;
                if (response.IsSuccessStatusCode)
                {
                    Getapplicationmodel = JsonConvert.DeserializeObject<ApplicationUserModel>(response.Content.ReadAsStringAsync().Result);
                    _logger.LogInformation($"Succesfull Login UserName {Getapplicationmodel.Firstname}");
                    //if (receivedReservation.status.ToString() == "1")
                    //{
                    //    ViewBag.UserName_vch = receivedReservation.UserName_vch;
                    //    HttpContext.Session.SetString(SessionKeyName, receivedReservation.UserName_vch);
                    //    return RedirectToAction("index", "Home");
                    //}
                    //else
                    //{
                    //    ModelState.AddModelError(EnumAlert.Info.ToString(), "Wrong Username or Password");
                    //    return View(viewModel);
                    //}
                }
            }
            return View(applicationmodel);
        }







        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}