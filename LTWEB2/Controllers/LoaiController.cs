using LTWEB2.Models;
using System.Linq;
using System.Web.Mvc;

namespace LTWEB2.Controllers
{
    public class LoaiController : Controller
    {
        // GET: Loai/ListPartial
        public ActionResult ListPartial()
        {
            using (LTWEB2Entities ctx=new LTWEB2Entities())
            {
                var list = ctx.Loai.ToList();
                return PartialView(list);
            }

        }
    }
}