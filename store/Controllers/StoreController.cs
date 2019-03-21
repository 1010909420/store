using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using DAL.DAO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Entity;
using store.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace store.Controllers
{
    public class StoreController : BaseController
    {

        private readonly IHostingEnvironment _hostingEnvironment;

        public StoreController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        //public ActionResult List()
        //{
        //    T_GoodsDAO dao = new T_GoodsDAO();

        //    ViewBag.list = dao.GetAll().ToList();

        //    return View();
        //}

        [LoginFilter]
        public ActionResult List()
        {
            T_GoodsDAO entityDao = new T_GoodsDAO();

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
            Expression<Func<T_Goods, dynamic>> orderBy = null;
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

            List<T_Goods> list =
                //从url输入的待查询文本，支持多关键字模糊查询  
                entityDao.Search(ref total, search_criteria,
                null, //where里面支持另一些lambda条件表达式，跟前面的文本形成and关系
                orderBy, isDecending, //排序
                page, this.pageSize) //分页
                .ToList();

            ViewBag.total = total;
            ViewBag.list = list;
            ViewBag.pageSize = this.pageSize;
            ViewData["Title"] = "商品列表";
            ViewData["username"] = HttpContext.Session.GetString("username");

            return View();
        }


        [LoginFilter]
        public ActionResult Show(int goodsId)
        {
            T_CommentDAO dao = new T_CommentDAO();
            T_GoodsDAO goodsDao = new T_GoodsDAO();

            List<T_Comment> list = dao.getByGoodsId(goodsId).ToList();
            T_Goods goods = goodsDao.GetById(goodsId);

            ViewBag.commentList = list;
            ViewBag.goods = goods;
            ViewData["Title"] = "查看商品";
            ViewData["username"] = HttpContext.Session.GetString("username");

            return View();

        }


        [LoginFilter]
        public ActionResult Edit()
        {
            ViewData["Title"] = "增加/修改商品";
            ViewData["username"] = HttpContext.Session.GetString("username");
            return View();
        }

        public JsonResult GetGoodsById(int goodsId)
        {
            T_GoodsDAO goodsDao = new T_GoodsDAO();
            T_Goods goods = goodsDao.GetById(goodsId);
            if (goods == null)
                goods = new T_Goods();

            return Json(goods);
        }

        public JsonResult EditGoods(T_Goods goods)
        {
            T_GoodsDAO dao = new T_GoodsDAO();
            if (dao.GetById(goods.id) == null)
                dao.Add(goods);
            else
                dao.Update(goods);

            return Json("success");
        }

        public JsonResult DelGoods(int goodsId)
        {
            T_GoodsDAO dao = new T_GoodsDAO();
            dao.DelById(goodsId);
            return Json("success");
        }


        //保存上传文件
        public async Task<IActionResult> FileSave()
        {

            var file = Request.Form.Files[0];

            string webRootPath = _hostingEnvironment.WebRootPath;

            string contentRootPath = _hostingEnvironment.ContentRootPath;


            if (file.Length > 0)

            {


                string[] arr = file.FileName.Split('.');
                string ext = arr[arr.Length - 1];//获取原扩展名

                long fileSize = file.Length; //获得文件大小，以字节为单位

                string newFileName = System.Guid.NewGuid().ToString() + "." + ext; //随机生成新的文件名

                var filePath = webRootPath + "/upload/" + newFileName;

                using (var stream = new FileStream(filePath, FileMode.Create))

                {

                    await file.CopyToAsync(stream);

                }



                return Ok("/upload/" + newFileName);

            }

            return Ok("error");

        }

        public JsonResult test(String s)
        {
            T_GoodsDAO goodsDao = new T_GoodsDAO();
            T_UserDAO userDao = new T_UserDAO();
            T_CommentDAO commentDao = new T_CommentDAO();
            String test = goodsDao.test(s) + "|" + userDao.test(s) + "|" + commentDao.test(s);
            return Json(test);
        }


        public JsonResult JsonList()
        {
            T_GoodsDAO entityDao = new T_GoodsDAO();

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
            Expression<Func<T_Goods, dynamic>> orderBy = null;
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

            List<T_Goods> list =
                //从url输入的待查询文本，支持多关键字模糊查询  
                entityDao.Search(ref total, search_criteria,
                null, //where里面支持另一些lambda条件表达式，跟前面的文本形成and关系
                orderBy, isDecending, //排序
                page, this.pageSize) //分页
                .ToList();

            //ViewBag.total = total;
            //ViewBag.list = list;
            //ViewBag.pageSize = this.pageSize;
            //ViewData["Title"] = "商品列表";


            return Json(list);
        }


    }
}
