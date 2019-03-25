using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DAL.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entity;
using store.Models;

namespace store.Controllers
{
    public class HomeController : BaseController
    {
        public JsonResult List()
        {
            T_AddrDAO dao = new T_AddrDAO();
            List<T_Addr> list = dao.GetAll().Include(e => e.userEntity).ToList();

            ViewBag.list = list;

            this.HttpContext.Session.SetString("username", "1010");
            this.HttpContext.Session.SetString("password", "10101");

            return Json(list);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public ActionResult Login()
        {
            ViewData["title"] = "登陆后台系统";
            ViewBag.username = HttpContext.Session.GetString("account");
            ViewBag.password = HttpContext.Session.GetString("password");
            return View();
        }

        public JsonResult DoLogin(String account, String password)
        {
            T_UserDAO dao = new T_UserDAO();
            T_User user = dao.getByAccount(account);
            if (user != null && Tool.MD5Encrypt(password, 32).Equals(user.password))
            {
                this.HttpContext.Session.SetString("username", user.name);
                return Success("登陆成功", "message");
            }
            
            return Fail("用户名密码不匹配", "message");
        }

        public ActionResult Logout() {
            HttpContext.Session.Remove("username");
            return View("Login");
        }
    }
}
