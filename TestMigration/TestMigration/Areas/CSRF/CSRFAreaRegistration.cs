using System.Web.Mvc;

namespace TestMigration.Areas.CSRF
{
    public class CSRFAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "CSRF";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "CSRF_default",
                "CSRF/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}