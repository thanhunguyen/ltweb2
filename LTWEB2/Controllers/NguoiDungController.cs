using BotDetect.Web.Mvc;
using LTWEB2.Filters;
using LTWEB2.Helpers;
using LTWEB2.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web.Mvc;

using System.Web;

namespace LTWEB2.Controllers
{
    public class NguoiDungController : Controller
    {


        // GET: NguoiDung // Dang Nhap
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(LoginModel model)
        {
            string passw = StringUtils.Md5(model.PWD);
            using (LTWEB2Entities ctx = new LTWEB2Entities())
            {
                NguoiDung us = ctx.NguoiDung
                    .Where(u => u.TenDangNhap == model.UID && u.MatKhau == passw)
                    .FirstOrDefault();
                if (us == null)
                {
                    ViewBag.Error = "Sai tên đăng nhập hoặc mật khẩu";
                    return View(model);
                }
                else // login thanh cong
                {
                    Session["IsLogin"] = 1;
                    Session["CurUser"] = us;
                    if (model.Remember == true)
                    {
                        Response.Cookies["tendangnhap"].Value = us.TenDangNhap;
                        Response.Cookies["tendangnhap"].Expires = DateTime.Now.AddMonths(12);
                    }
                    return RedirectToAction("Index", "Home");
                }
            }

        }


        public ActionResult DangXuat()
        {
            CurrentContext.Destroy();
            return RedirectToAction("Index", "Home");
        }

        // GET: NguoiDung // Dang ki
        [CheckLogout]
        public ActionResult DangKi()
        {
            return View();
        }

        // GET: NguoiDung // Dang ki
        [HttpPost]
        
        [AllowAnonymous]
        [CaptchaValidation("CaptchaCode", "ExampleCaptcha", "Incorrect CAPTCHA code!")]
        public ActionResult DangKi(RegisterModel model)
        {
            
            if (!ModelState.IsValid)
            {
                // TODO: Captcha validation failed, show error message
                ViewBag.Error = 2;
                return View(model);
            }
            else
            {
                // TODO: Captcha validation passed, proceed with protected action  
                using (LTWEB2Entities ctx = new LTWEB2Entities())
                {
                    int n = ctx.NguoiDung
                        .Where(iu => iu.TenDangNhap == model.UID)
                        .Count();

                    if (n > 0)
                    {
                        ViewBag.Error = 0;
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
                    SoDienThoai = model.SDT,
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
            }
            ViewBag.Error = 1;
            return View();
        }


        //get thong tin dang nhap
        [CheckLogin]
        public ActionResult Profile()
        {

            return View();
        }
        [CheckLogin]
        public ActionResult Edit()
        {
            return View();
        }
        [CheckLogin]
        [HttpPost]
        public ActionResult Edit(RegisterModel model)
        {
            string passw = StringUtils.Md5(model.PWD);
            NguoiDung us = new NguoiDung();
            using (LTWEB2Entities ctx = new LTWEB2Entities())
            {
                us = ctx.NguoiDung
                    .Where(u => u.TenDangNhap == model.UID && u.MatKhau == passw)
                    .FirstOrDefault();
                if (us == null)
                {
                    ViewBag.Error = 13;
                    return View(model);
                }
            }
            if (us != null)//  thanh cong
            {

                if (us.TenDayDu != model.FullName)
                {
                    us.TenDayDu = model.FullName;
                    ViewBag.FullName = 1;
                }
                else
                {
                    ViewBag.FullName = 0;
                }

                if (us.Email != model.Email)
                {
                    us.Email = model.Email;
                    ViewBag.Email = 1;
                }
                else
                {
                    ViewBag.Email = 0;
                }

                if (us.SoDienThoai != model.SDT)
                {
                    us.SoDienThoai = model.SDT;
                    ViewBag.SoDienThoai = 1;
                }
                else
                {
                    ViewBag.SoDienThoai = 0;
                }

                if (us.TenDayDu == model.FullName && us.SoDienThoai == model.SDT && us.Email == model.Email)
                {
                    ViewBag.Error = 0;
                    return View(model);
                }
                else
                {
                    //3. Mark entity as modified


                    try
                    {
                        using (var dbCtx = new LTWEB2Entities())
                        {

                            dbCtx.Entry(us).State = EntityState.Modified;

                            //4. call SaveChanges
                            dbCtx.SaveChanges();
                        }

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
                    ViewBag.Error = 1;
                    return View(us);
                }

            }
            return View(model);
        }


        [CheckLogin]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [CheckLogin]
        [HttpPost]
        public ActionResult ChangePassword(ChangePassword model)
        {
            string passw = StringUtils.Md5(model.PWD);
            string passwnew = StringUtils.Md5(model.NEWPWD);
            NguoiDung us = new NguoiDung();
            using (LTWEB2Entities ctx = new LTWEB2Entities())
            {
                us = ctx.NguoiDung
                    .Where(u => u.TenDangNhap == model.UID && u.MatKhau == passw)
                    .FirstOrDefault();
                if (us == null)
                {
                    ViewBag.Error = 0;
                    return View();
                }
            }
            if (us != null)//  thanh cong
            {

                if (us.MatKhau != passwnew)
                {
                    us.MatKhau = passwnew;

                    try
                    {
                        using (var dbCtx = new LTWEB2Entities())
                        {

                            dbCtx.Entry(us).State = EntityState.Modified;

                            //4. call SaveChanges
                            dbCtx.SaveChanges();
                        }

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
                    ViewBag.Error = 1;
                    return View();
                }
                else
                {
                    ViewBag.Error = 2;
                    return View();
                }
                
            }



            return View();
        }

        private void SetANewRequestVerificationTokenManuallyInCookieAndOnTheForm()
        {
            if (Response == null)
                return;

            string cookieToken, formToken;
            System.Web.Helpers.AntiForgery.GetTokens(null, out cookieToken, out formToken);
            SetCookie("__RequestVerificationToken", cookieToken);
            ViewBag.FormToken = formToken;
        }

        private void SetCookie(string name, string value)
        {
            if (Response.Cookies.AllKeys.Contains(name))
                Response.Cookies[name].Value = value;
            else
                Response.Cookies.Add(new System.Web.HttpCookie(name, value));
        }

    }
}
