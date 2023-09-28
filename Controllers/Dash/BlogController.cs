using Microsoft.AspNetCore.Mvc;

namespace Report.Controllers.Dash
{
    [Route("Dash/[controller]")]
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
