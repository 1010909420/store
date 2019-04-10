using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.DAO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entity;
using store.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace store.Controllers
{
    [LoginFilter]
    public class CommentController : BaseController
    {

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            T_CommentDAO entityDao = new T_CommentDAO();

            int page = 1;//第几页
            if (!String.IsNullOrEmpty(Request.Query["p"]))
            {
                page = Convert.ToInt32(Request.Query["p"]);
            }

            String search_criteria = "";//全文模糊查询条件
            if (!String.IsNullOrEmpty(Request.Query["s"]))
            {
                search_criteria = Request.Query["s"];
            }

            String col = null;//排序列
            Expression<Func<T_Comment, dynamic>> orderBy = null;
            try
            {
                if (!String.IsNullOrEmpty(Request.Query["o"]))
                {
                    col = Request.Query["o"];
                    orderBy = entityDao.GetOrderByFromColName(col);
                }
                else
                {
                    //如果页面没有排序规则，则按id排序

                    orderBy = entityDao.GetOrderByFromColName("id");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            bool isDecending = true;//默认按降序排序
            if (!String.IsNullOrEmpty(Request.Query["de"]))
            {
                try
                {
                    isDecending = Convert.ToBoolean(Request.Query["de"]);
                }
                catch (Exception ex) { }
            }

            int total = 0;

            List<T_Comment> list =
                //从url输入的待查询文本，支持多关键字模糊查询  
                entityDao.Search(ref total, search_criteria,
                null, //where里面支持另一些lambda条件表达式，跟前面的文本形成and关系
                orderBy, isDecending, //排序
                page, this.pageSize).Include(e => e.userEntity).Include(e => e.goodsEntity) //分页
                .ToList();

            ViewBag.total = total;
            ViewBag.list = list;
            ViewBag.pageSize = this.pageSize;
            ViewData["Title"] = "评论列表";
            ViewData["username"] = HttpContext.Session.GetString("username");


            return View();
        }
    }
}
