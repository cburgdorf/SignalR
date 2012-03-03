using System;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using Mvc3SignalR.Models;
using SignalR;
using SignalR.Infrastructure;

namespace Mvc3SignalR.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}
