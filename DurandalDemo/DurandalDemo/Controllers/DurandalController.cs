using DurandalDemo.DAL;
using DurandalDemo.Migrations;
using System;
using System.Data.Entity;
using System.Web.Mvc;

namespace DurandalDemo.Controllers {
  public class HomeController : Controller {
    public ActionResult Index() {
      return View();
    }
    public ActionResult Upgrade() {
        try {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProspectContext, Configuration>());
            using(var db = new ProspectContext()) {
                db.Database.Initialize(true);
                return Json(1, JsonRequestBehavior.AllowGet);
            }
        } catch(Exception ex) {
            return Json(ex.Message, JsonRequestBehavior.AllowGet);
        }
    }

  }
}