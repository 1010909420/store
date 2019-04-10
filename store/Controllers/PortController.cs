using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
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
    public class PortController : BaseController
    {
        public JsonResult StoreList()
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

        public JsonResult GetAddrListByUserId(String id)
        {
            T_AddrDAO dao = new T_AddrDAO();
            List<T_Addr> list = dao.GetByUserId(id);
            return Json(list);
        }
     


        public JsonResult GetGoodsById(int goodsId)
        {
            T_GoodsDAO goodsDao = new T_GoodsDAO();
            T_Goods goods = goodsDao.GetById(goodsId);
            if (goods == null)
                goods = new T_Goods();

            return Json(goods);
        }

        public JsonResult SaveOrUpdateUserInfo(String code, String nickName, String gender)
        {
            String openid = GetOpenid(code);
            T_UserDAO dao = new T_UserDAO();
            T_User user = dao.getByOpenid(openid);

            if (user == null)
            {
                user = new T_User();
                user.name = nickName;
                user.sex = int.Parse(gender);
                user.openid = openid;
                dao.Add(user);
                user = dao.getByOpenid(openid);
            } else
            {
                user.name = nickName;
                user.sex = int.Parse(gender);
                dao.Update(user);
            }

            return Json(user.id);
        }

        private String GetOpenid(String code)
        {
            using (var httpClient = new HttpClient())
            {
                //get
                String appid = "wxc7b914b79b9ad3fe";
                String secret = "ec6127816095041c8c233bb55fe00ebd";
                var l = "https://api.weixin.qq.com/sns/jscode2session?appid=" + appid + "&secret=" + secret + "&js_code=" + code + "&grant_type=authorization_code";

                var url = new Uri(l);
                // response
                var response = httpClient.GetAsync(url).Result;
                String data = response.Content.ReadAsStringAsync().Result;

                String[] datas = data.Split("\"");


                if (datas.Length > 7)
                    return datas[7];
                else
                    return "0";               
            }
        }


    }
}
