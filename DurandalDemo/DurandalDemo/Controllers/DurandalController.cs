using System.Web.Mvc;

namespace DurandalDemo.Controllers {
  public class HomeController : Controller {
    public ActionResult Index() {
      return View();
    }
  }
}