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

        public JsonResult GetAddrListByUserId(int id)
        {
            T_AddrDAO dao = new T_AddrDAO();
            List<T_Addr> list = dao.GetByUserId(id);
            return Json(list);
        }
     
        public JsonResult GetAddrById(int id)
        {
            T_AddrDAO dao = new T_AddrDAO();
            T_Addr addr = dao.GetById(id);
            return Json(addr);
        }

        public JsonResult SaveOrUpdateAddr(int id, int userId, String name, String mobile, String addr, int defaultAddr)
        {
            T_AddrDAO dao = new T_AddrDAO();
            T_Addr addrInfo = new T_Addr();
            addrInfo.id = id;
            addrInfo.userId = userId;
            addrInfo.name = name;
            addrInfo.mobile = mobile;
            addrInfo.addr = addr;
            addrInfo.defaultAddr = defaultAddr;

            if (addrInfo.defaultAddr == 1)
            {
                dao.SetDefaultAddrIsFalseByUserId(addrInfo.userId);
            }


            if (dao.GetById(addrInfo.id) == null)
            {
                dao.Add(addrInfo);
            }
            else
            {
                dao.Update(addrInfo);
            }

            return Json("更新完毕");
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
            if(openid == "-1")
            {
                return Json("获取openid失败！");
            }

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
                //请上微信小程序申请自身id与秘钥
                String appid = "";
                String secret = "";
                var l = "https://api.weixin.qq.com/sns/jscode2session?appid=" + appid + "&secret=" + secret + "&js_code=" + code + "&grant_type=authorization_code";

                var url = new Uri(l);
                // response
                var response = httpClient.GetAsync(url).Result;
                String data = response.Content.ReadAsStringAsync().Result;

                String[] datas = data.Split("\"");


                if (datas.Length > 7)
                    return datas[7];
                else
                    return "-1";               
            }
        }

        public JsonResult DelAddrById(int id)
        {
            T_AddrDAO dao = new T_AddrDAO();
            dao.DelById(id);
            return Json("删除成功");
        }


    }
}
