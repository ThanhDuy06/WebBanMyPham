using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBanMyPham.Areas.admin.Models;
using WebBanMyPham.Commons;
using WebBanMyPham.Dao;

namespace WebBanMyPham.Areas.admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: admin/Login
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new User_Dao();
                var result = dao.Login(model.Email, Encryptor.GetMD5(model.Password));
                if (result == 1)
                {
                    var user = dao.getItem(model.Email);
                    var session = new UserLogin();
                    session.Email = user.Email;
                    session.UserID = user.ID;
                    session.UserName = user.UserName;
                    session.FuName = user.FullName;
                    Session.Add(Code_Func.USER_SESSION, session);
                    return RedirectToAction("Index", "products");
                }
                else if(result==0)
                {
                    ModelState.AddModelError("","Tài khoản chưa kích hoạt");
                }
                else if(result == -1)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng");
                }
                else if(result == -2)
                {
                    ModelState.AddModelError("", "Email không tồn tại");
                }
            }
            return View("Index");
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}