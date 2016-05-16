using LTWEB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWEB2.Controllers
{
    public class NhaSanXuatController : Controller
    {
        // GET: NhaSanXuat/ListNHX
        public ActionResult ListNSX()
        {
            using (LTWEB2Entities ctx = new LTWEB2Entities())
            {
                var list = ctx.NhaSanXuat.ToList();
                return PartialView(list);
            }
            
        }
    }
}