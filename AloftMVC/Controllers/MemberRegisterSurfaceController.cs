using AloftMVC.DAL;
using AloftMVC.Models;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Umbraco.Web.Models;
using Umbraco.Web.Mvc;
using Umbraco.Web.Security;

namespace AloftMVC.Controllers
{
    public class MemberRegisterSurfaceController : SurfaceController
    {
        
        // TODO - clean up if not used, also the Dispose method below
        //private AloftMvcContext db = new AloftMvcContext();

        // GET: RegisterMemberSurface
        public ActionResult Index()
        {
            
            var umbGroups = from item in Services.MemberGroupService.GetAll()
                                    select new SelectListItem
                                    {
                                       Text = item.Name,
                                       Value = item.Name
                                   };

            MemberRegisterVM ViewModel = new MemberRegisterVM();
            ViewModel.MemberGroups = umbGroups;
            
            return PartialView("MemberRegisterForm", ViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostHandler([Bind(Include = "Email, Name, Password, Username, MemberGroup, RedirectUrl")] MemberRegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }
            else
            {
                MembershipHelper MembershipHelper = new MembershipHelper(Umbraco.UmbracoContext);
                RegisterModel RegModel = MembershipHelper.CreateRegistrationModel();
                MembershipCreateStatus membershipStatus;
                //TODO - set up Auto Mapper
                RegModel.Email = model.Email;
                RegModel.Name = model.Name;
                RegModel.Password = model.Password;
                RegModel.RedirectUrl = "/login/profile";
                RegModel.Username = model.Username;
                RegModel.UsernameIsEmail = false;

                MembershipHelper.RegisterMember(RegModel, out membershipStatus, true );

                return Redirect(RegModel.RedirectUrl);
            }
        }

        /*
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        */

    }
}