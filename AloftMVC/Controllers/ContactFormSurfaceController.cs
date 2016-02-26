using AloftMVC.DAL;
using AloftMVC.Models;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace AloftMVC.Controllers
{
    public class ContactFormSurfaceController : SurfaceController
    {

        private AloftMvcContext db = new AloftMvcContext();

        // GET: ContactFormSurface
        public ActionResult Index()
        {
            return PartialView("ContactForm", new ContactUs() );
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostHandler([Bind(Include = "Id,Name,Email,Mesasge")] ContactUs model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }
            else
            {
                db.ContactUs.Add(model);
                db.SaveChanges();
            }
            
            TempData["success"] = true;

            return RedirectToCurrentUmbracoPage();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}