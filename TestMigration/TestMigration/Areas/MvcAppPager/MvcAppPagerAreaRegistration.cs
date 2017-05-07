using System.Web.Mvc;

namespace TestMigration.Areas.MvcAppPager
{
    public class MvcAppPagerAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MvcAppPager";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MvcAppPager_default",
                "MvcAppPager/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}