using System.Web.Mvc;
using Umbraco.Web.Mvc;
using AloftMVC.Models;
using Umbraco.Web.Models;
using Umbraco.Web.Security;

namespace AloftMVC.Controllers
{
    public class MemberProfileSurfaceController : SurfaceController
    {
        
        public ActionResult Index()
        {
            MemberProfileVM model = new MemberProfileVM();
            
            ProfileModel UmbMemProf = Members.GetCurrentMemberProfileModel();
            //TODO - set up Auto Mapper
            model.Name = UmbMemProf.Name;
            model.Email = UmbMemProf.Email;
            model.AvatarCropperImage = "";

            foreach ( var prop in UmbMemProf.MemberProperties)
            {
                if(prop.Alias == "avatarImageCropper")
                {
                    model.AvatarCropperImage = prop.Value;
                }
            }

            return PartialView("MemberProfileForm", model);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostHandler([Bind(Include = "Email, Name")] MemberProfileVM model)
        {
            if (!ModelState.IsValid)
            {
                return CurrentUmbracoPage();
            }
            else
            {
                MembershipHelper MembershipHelper = new MembershipHelper(Umbraco.UmbracoContext);
                ProfileModel UmbMemProf = Members.GetCurrentMemberProfileModel();

                //TODO - set up Auto Mapper
                UmbMemProf.Email = model.Email;
                UmbMemProf.Name = model.Name;
                //TODO - incorporate updated imageCropper form data
                //UmbMemProf = model.AvatarCropperImage;

                MembershipHelper.UpdateMemberProfile(UmbMemProf);

                TempData["success"] = true;

                return RedirectToCurrentUmbracoPage();
            }
        }
    }
}