using Microsoft.AspNetCore.Mvc;

namespace Report.Controllers.Dash.Details
{
    [Route("Dash/Details/[controller]")]
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
