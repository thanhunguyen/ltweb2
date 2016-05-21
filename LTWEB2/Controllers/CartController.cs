using LTWEB2.Helpers;
using System.Web.Mvc;

namespace LTWEB2.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        // Post : add to cart
        [HttpPost]
        public ActionResult Add(CartItem item)
        {
            CurrentContext.Cart().Add(item);
            return RedirectToAction("Detail","SanPham", new
            {
                id = item.ProID
            });
        }
    }
}