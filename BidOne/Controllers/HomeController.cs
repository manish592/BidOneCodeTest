using BidOne.Models;
using BidOne.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Bidone.Helpers;
using System.Diagnostics;
using System.Net;
using System.Text;

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
            //APIURL = configuration.GetSection("API").GetSection("APIURL").Value;
        }

        [HttpPost]
        public async Task<IActionResult> Signup(RegistertViewModel registertViewModel)
        {
            if (ModelState.IsValid)
            {
                HttpClient client = new HttpClient();
                HttpResponseMessage response = client.GetAsync("https://localhost:7047/" + string.Format("Home/FormSubmits?Firstname={0}&Lastname={1}", registertViewModel.Firstname, registertViewModel.Lastname)).Result;
                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();                  
                    _logger.LogInformation($"Succesfull Getting Json {responseBody}");
                    var fileName = "test.txt";
                    var mimeType = "text/plain";
                    var fileBytes = Encoding.ASCII.GetBytes(responseBody);                    
                    return new FileContentResult(fileBytes, mimeType)
                    {
                        FileDownloadName = fileName
                    };
                }
            }
			ModelState.Remove("Firstname");
			ModelState.Remove("Lastname");
			ModelState.AddModelError(EnumAlert.Message.ToString(), "File has been Downloded successfully.");
			return View(registertViewModel);
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