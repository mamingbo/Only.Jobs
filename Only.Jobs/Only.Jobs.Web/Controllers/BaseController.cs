using Newtonsoft.Json;
using Only.Jobs.Core.Business.Info;
using Only.Jobs.Core.Common;
using System;
using System.Collections.Concurrent;
using System.Web.Mvc;

namespace Only.Jobs.Web.Controllers
{
    public class BaseController : Controller
    {
        #region JsonResult

        public new JsonResult Json(object data)
        {
            return new NewtonJsonResult(data, new JsonSerializerSettings() { DateFormatString = "yyyy-MM-dd HH:mm:ss" });
        }

        public new JsonResult Json(object data, JsonRequestBehavior behavior)
        {
            return new NewtonJsonResult(data, behavior, new JsonSerializerSettings() { DateFormatString = "yyyy-MM-dd HH:mm:ss" });
        }

        public JsonResult Json(object data, JsonRequestBehavior behavior, string DateFormatString)
        {
            return new NewtonJsonResult(data, behavior, new JsonSerializerSettings() { DateFormatString = DateFormatString });
        }

        public new JsonResult Json(object data, string DateFormatString)
        {
            return new NewtonJsonResult(data, new JsonSerializerSettings() { DateFormatString = DateFormatString });
        }

        #endregion


        /// <summary>
        /// 获取页面参数
        /// </summary>
        /// <returns></returns>
        public PageParameter GetPageParameter()
        {
            PageParameter parameter = new PageParameter();
            parameter.rows = WebHelper.GetRequestInt("rows", 1);
            parameter.currentPageIndex = WebHelper.GetRequestInt("page", 1);
            string Param = WebHelper.GetRequestString("Param");
            if (!string.IsNullOrEmpty(Param))
            {
                try
                {
                    if (Param.Contains(",}"))
                    {
                        Param = Param.Replace(",}", "}");
                    }
                    System.Web.Script.Serialization.JavaScriptSerializer sr = new System.Web.Script.Serialization.JavaScriptSerializer();
                    parameter.SetDictionary(sr.Deserialize(Param, typeof(ConcurrentDictionary<string, string>)) as ConcurrentDictionary<string, string>);
                }
                catch (Exception)
                { }
            }

            foreach (string key in System.Web.HttpContext.Current.Request.QueryString.AllKeys)
            {
                if (!string.IsNullOrWhiteSpace(key) && !key.Equals("rows") && !key.Equals("page") && !key.Equals("Param"))
                {
                    parameter.AddParameter(key, Request.QueryString[key]);
                }
            }
            return parameter;
        }
    }
}