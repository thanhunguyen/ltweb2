using LTWEB2.Helpers;
using System.Web.Mvc;

namespace LTWEB2.Filters
{
    public class CheckLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if(CurrentContext.IsLogged() == false)
            {
                string controller = filterContext.RouteData.Values["controller"].ToString();
                string action = filterContext.RouteData.Values["action"].ToString();

                filterContext.Result = new RedirectResult(string.Format(
                    "~/NguoiDung/DangNhap?retUrl=/{0}/{1}",
                    controller,
                    action
                    )
                    );
                return;


            }
            base.OnActionExecuting(filterContext);
        }
    }

    public class CheckLogoutAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (CurrentContext.IsLogged() == true)
            {
                string controller = filterContext.RouteData.Values["controller"].ToString();
                string action = filterContext.RouteData.Values["action"].ToString();

                filterContext.Result = new RedirectResult(string.Format(
                    "~/Home/Index?retUrl=/{0}/{1}",
                    controller,
                    action
                    )
                    );
                return;


            }
            base.OnActionExecuting(filterContext);
        }
    }
}