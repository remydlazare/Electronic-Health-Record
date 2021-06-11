using Rehabilitation.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Rehabilitation.Controllers
{
    public class AuthorizeController : Controller
    {
        private RehabilitationEntities db = new RehabilitationEntities();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //public ActionResult Sign_In()
        //{
        //    var LoginModel = new Account();

        //    return View(LoginModel);
        //}
        public new RedirectToRouteResult RedirectToAction(string action, string controller)
        {
            return base.RedirectToAction(action, controller);
        }

        [HttpPost]
        public ActionResult Sign_In(Account model)
        {
            Account account = db.Accounts.Find(model.Username);
            if (account == null)
                ViewBag.Text = "Không tìm thấy tài khoản.";
            else if (EncMD5(model.Password) == account.Password)
            {
                ViewBag.Text = "Đăng nhập thành công.";
                Session["username"] = account.Username;
                Session["role"] = account.Role;
                return RedirectToAction("Index", "Home");
            }
            else
                ViewBag.Text = "Mật khẩu không chính xác.";
            return View("Index");
        }

        public ActionResult Sign_Out()
        {
            //Session.Remove("Username");
            //Session.Remove("Role");
            Session["Username"] = null;
            Session["Role"] = null;
            return RedirectToAction("Index");
        }

        public ActionResult ChangePassword()
        {
            Account account = db.Accounts.Find(Session["Username"].ToString());
            return View(account);
        }

        [HttpPost]
        public ActionResult ChangePassword(Account account)
        {
            Account old = db.Accounts.Find(Session["Username"].ToString());
            db.Entry(old).State = EntityState.Detached;
            if (EncMD5(account.Password) == old.Password)
            {
                account.LastModified = DateTime.Now;
                account.Password = EncMD5(account.NewPassword);
                db.Entry(account).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(account);
        }

        private string EncMD5(string password)
        {
            password = (password == null) ? "" : password;
            System.Security.Cryptography.MD5 md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            Byte[] originalBytes = encoder.GetBytes(password);
            Byte[] encodedBytes = md5.ComputeHash(originalBytes);
            password = BitConverter.ToString(encodedBytes).Replace("-", "");
            var result = password.ToLower();
            return result;
        }
    }
}