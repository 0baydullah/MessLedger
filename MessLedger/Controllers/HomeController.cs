using System.Diagnostics;
using log4net;
using Microsoft.AspNetCore.Mvc;
using ML.Web.ViewModels;

namespace MessLedger.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILog _log = LogManager.GetLogger(typeof(HomeController));

        public IActionResult Index()
        {
          //  throw new DivideByZeroException();
            _log.Info("Welcome to Mess Ledger");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorVM { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
