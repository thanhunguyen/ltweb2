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
        public ActionResult BySP(int ? id, int curPage=1)
        {
            
                if (id.HasValue == false)
                {
                    return RedirectToAction("Index", "Home");
                }
            using (LTWEB2Entities ctx = new LTWEB2Entities())
            {
                // List<SanPham> list = ctx.SanPham
                //   .Where(p => p.NhaSanXuatID == id).ToList();

                var query = ctx.SanPham.Where(p => p.NhaSanXuatID == id);
                //tang luot view

                int n = query.Count();

                int nPages = n / 4;
                if (n % 4 > 0) nPages++;
                ViewBag.Pages = nPages;
                ViewBag.NextPage = curPage + 1;
                ViewBag.PrevPage = curPage - 1;


                int nSkip = (curPage - 1) * 4;
                List<SanPham> list = query
                    .OrderBy(p=>p.SanPhamID)
                    .Skip(nSkip).Take(4).ToList();

                return View(list);
            }
           
        }

        public ActionResult Detail(int ? id)
        {
            if (id.HasValue == false)
            {
                return RedirectToAction("Index", "Home");
            }
            using (LTWEB2Entities ctx=new LTWEB2Entities())
            {
                var model = ctx.SanPham
                    .Where(p => p.SanPhamID == id)
                    .FirstOrDefault();
                return View(model);
            }
        }
    }


}
