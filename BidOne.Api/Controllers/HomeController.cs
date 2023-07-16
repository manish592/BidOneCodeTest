using Microsoft.AspNetCore.Mvc;
using System.Data;
using static BidOne.Api.Helpers.Common;

namespace BidOne.Api.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult FormSubmits(string Firstname, string Lastname)
        {
            try
            {
                var response = new USerSubmission();
                response.Firstname = Firstname;
                response.Lastname = Lastname;
                response.msg = "Success";
                response.status = "1";
                return Ok(response);
            }
            catch (Exception ex)
            {

            }
            return BadRequest();
        }

    }
}
