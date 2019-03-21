using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace store.Models
{
    public class BaseController : Controller
    {
        ////用于判断是否在子类Controller使用统一过滤器的开关，可以在子类Controller的构造函数里面开关
        //protected bool isAllowCrossDomain = false;
        //protected bool isCheckLogin = true;
        //protected bool isCatchException = true;

        protected int pageSize = 10;


        /// <summary>
        /// 统一的错误处理方法
        /// </summary>
        /// <param name="ex"></param>
        protected JsonResult Error(Exception ex)
        {
            String msg = //"错误来源：" + ex.Source + "<br/>" + 
                 "错误信息："
                + ex.Message.Replace("\r", "").Replace("\n", "").Replace("\"", "`")
                //+ "<br/>错误跟踪："
                //+ ex.StackTrace.Replace("\r", "").Replace("\n", "")
                ;

            JsonModel json = new JsonModel(false, msg, null);

            return Json(json);
        }

        protected ViewResult Error(String msg)
        {
            ViewBag.info = msg;
            return View("error");
        }


        protected JsonResult Success(String msg, DataTable dt, String code = null)
        {
            if (dt == null)
                return Json(new JsonModel(true, msg, null, code));

            List<Dictionary<String, Object>> list = new List<Dictionary<string, Object>>();

            foreach (DataRow dr in dt.Rows)
            {
                Dictionary<String, Object> dict = new Dictionary<string, Object>();

                foreach (DataColumn dc in dt.Columns)
                    dict[dc.ColumnName] = dr[dc.ColumnName];

                list.Add(dict);
            }

            JsonModel json = new JsonModel(true, msg, list, code);

            return Json(json);
        }

        protected JsonResult Success(String msg, Object data, String code = null)
        {
            JsonModel json = new JsonModel(true, msg, data, code);

            return Json(json);
        }

        protected JsonResult Fail(String msg, String code = null)
        {
            JsonModel json = new JsonModel(false, msg, null, code);

            return Json(json);
        }


        ///// <summary>
        ///// 获取请求端IP地址
        ///// </summary>
        //protected string GetClientIP()
        //{
        //    string ipAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString(); 

        //    if (!string.IsNullOrEmpty(ipAddress))
        //    {
        //        string[] addresses = ipAddress.Split(',');
        //        if (addresses.Length != 0)
        //        {
        //            return addresses[0];
        //        }
        //    }

        //    String ip = context.Request.ServerVariables["REMOTE_ADDR"];

        //    if (ip == "::1")
        //        ip = "127.0.0.1";

        //    return ip;
        //}


        ///// <summary>
        ///// 利用外部服务接口根据IP获取地址名称
        ///// </summary>
        //protected String getAddressByIP(String ip)
        //{
        //    String url = String.Format(Config.ip_api, ip);

        //    String addr = "";

        //    try
        //    {
        //        addr = Config.HttpGet(url);
        //        addr = Util.UnicodeDecode(addr);
        //        String temp = "";

        //        //只要ip解析里面的汉字
        //        Regex reg = new Regex("[\u4e00-\u9fa5]+");
        //        foreach (Match v in reg.Matches(addr))
        //            temp += v + "-";
        //        return temp;
        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.Message;
        //    }
        //}


    }
}
