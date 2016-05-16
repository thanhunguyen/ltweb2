using LTWEB2.Helpers;
using LTWEB2.Models;
using System;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;


namespace LTWEB2.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung // Dang Nhap
        public ActionResult DangNhap()
        {
            return View();
        }

        // GET: NguoiDung // Dang ki
        public ActionResult DangKi()
        {
            return View();
        }

        // GET: NguoiDung // Dang ki
        [HttpPost]
        public ActionResult DangKi(RegisterModel model)
        {
            using (LTWEB2Entities ctx = new LTWEB2Entities())
            {
                int n = ctx.NguoiDung
                    .Where(iu => iu.TenDangNhap == model.UID)
                    .Count();
                if(n>0)
                {
                    ViewBag.Error = model.UID + " đã tồn tại trong hệ thống.";
                    return View(model);
                }
            }
                NguoiDung u = new NguoiDung
                {
                    TenDangNhap = model.UID,
                    MatKhau = StringUtils.Md5(model.PWD),
                    TenDayDu = model.FullName,
                    Email = model.Email,
                    QuyenHan = 0,
                };

            using (LTWEB2Entities ctx = new LTWEB2Entities())
            {
                ctx.NguoiDung.Add(u);
                try
                {
                    ctx.SaveChanges();
                }
               catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }

                return View();
        }
    }
}