using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace LTWEB2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }

        protected void Session_Start(object sender, EventArgs e)
        {
            Session["IsLogin"] = 0;
            Session["CurUser"] = null;
            //Session["Cart"] = new Helpers.Cart();
        }
    }
}
