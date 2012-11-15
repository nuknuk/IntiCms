using System.Web.Mvc;

namespace IntiCms.Web.Areas.IntiCms
{
    public class IntiCmsAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "IntiCms";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "IntiCms_default",
                "IntiCms/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
