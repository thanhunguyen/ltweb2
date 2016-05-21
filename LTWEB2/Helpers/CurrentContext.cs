using LTWEB2.Models;
using System.Linq;
using System.Web;

namespace LTWEB2.Helpers
{
    public static class CurrentContext
    {
        public static bool IsLogged()
        {
            if ((int)HttpContext.Current.Session["IsLogin"] == 1)
                return true;
            if (HttpContext.Current.Request.Cookies["tendangnhap"] != null)
            {
                string username = HttpContext.Current.Request.Cookies["tendangnhap"].Value;
                using (LTWEB2Entities ctx = new LTWEB2Entities())
                {
                    NguoiDung us = ctx.NguoiDung
                        .Where(u => u.TenDangNhap == username)
                        .FirstOrDefault();
                    if (us != null)
                    {
                        HttpContext.Current.Session["CurUser"] = us;
                        HttpContext.Current.Session["IsLogin"] = 1;
                        return true;
                    }
                    
                }
            }
            return false;
        }



        public static NguoiDung CurUser()
        {
            return (NguoiDung)HttpContext.Current.Session["CurUser"];
        }
         
        public static Cart Cart()
        {
            if (HttpContext.Current.Session["Cart"] == null)
                HttpContext.Current.Session["Cart"] = new Cart();

            return (Cart)HttpContext.Current.Session["Cart"];
        }

        public static void Destroy()
        {
            Cart().Items.Clear();
            HttpContext.Current.Session["CurUser"] = null;
            HttpContext.Current.Session["IsLogin"] = 0;

            HttpContext.Current.Response.Cookies["tendangnhap"].Expires = System.DateTime.Now.AddDays(-1);

        }
    }
}
