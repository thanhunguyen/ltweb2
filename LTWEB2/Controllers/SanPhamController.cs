using LTWEB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTWEB2.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham/BySP
        public ActionResult BySP(int ? id)
        {
            
                if (id.HasValue == false)
                {
                    return RedirectToAction("Index", "Home");
                }
            using (LTWEB2Entities ctx = new LTWEB2Entities())
            {
                List<SanPham> list = ctx.SanPham
                    .Where(p => p.NhaSanXuatID == id).ToList();
                return View(list);
            }
            
        }
    }
}