using System.Web;
namespace Only.Jobs.Core.Common
{
    /// <summary>
    /// Web帮助类
    /// </summary>
    public class WebHelper
    {
        /// <summary>
        /// 是否是get请求
        /// </summary>
        /// <returns></returns>
        public static bool IsGet()
        {
            return HttpContext.Current.Request.HttpMethod == "GET";
        }

        /// <summary>
        /// 是否是post请求
        /// </summary>
        /// <returns></returns>
        public static bool IsPost()
        {
            return HttpContext.Current.Request.HttpMethod == "POST";
        }

        /// <summary>
        /// 是否是Ajax请求
        /// </summary>
        /// <returns></returns>
        public static bool IsAjax()
        {
            if (HttpContext.Current != null && HttpContext.Current.Request != null)
            {
                return HttpContext.Current.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
            }
            return false;
        }

        /// <summary>
        /// 获得查询字符串中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string GetQueryString(string key, string defaultValue)
        {
            string value = HttpContext.Current.Request.QueryString[key];
            if (!string.IsNullOrWhiteSpace(value))
                return value;
            else
                return defaultValue;
        }

        /// <summary>
        /// 获得查询字符串中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetQueryString(string key)
        {
            return GetQueryString(key, "");
        }

        /// <summary>
        /// 获得查询字符串中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int GetQueryInt(string key, int defaultValue)
        {
            string val = HttpContext.Current.Request.QueryString[key];
            if (!string.IsNullOrWhiteSpace(val))
            {
                int result;
                if (int.TryParse(val, out result))
                    return result;
            }
            return defaultValue;

        }

        /// <summary>
        /// 获得查询字符串中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static int GetQueryInt(string key)
        {
            return GetQueryInt(key, 0);
        }

        /// <summary>
        /// 获得表单中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string GetFormString(string key, string defaultValue)
        {
            string value = HttpContext.Current.Request.Form[key];
            if (!string.IsNullOrWhiteSpace(value))
                return value;
            else
                return defaultValue;
        }

        /// <summary>
        /// 获得表单中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetFormString(string key)
        {
            return GetFormString(key, "");
        }

        /// <summary>
        /// 获得表单中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int GetFormInt(string key, int defaultValue)
        {
            string val = HttpContext.Current.Request.Form[key];
            if (!string.IsNullOrWhiteSpace(val))
            {
                int result;
                if (int.TryParse(val, out result))
                    return result;
            }
            return defaultValue;

        }

        /// <summary>
        /// 获得表单中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static int GetFormInt(string key)
        {
            return GetFormInt(key, 0);
        }

        /// <summary>
        /// 获得请求中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string GetRequestString(string key, string defaultValue)
        {
            if (HttpContext.Current.Request.Form[key] != null)
                return GetFormString(key, defaultValue);
            else
                return GetQueryString(key, defaultValue);
        }

        /// <summary>
        /// 获得请求中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static string GetRequestString(string key)
        {
            if (HttpContext.Current.Request.Form[key] != null)
                return GetFormString(key);
            else
                return GetQueryString(key);
        }

        /// <summary>
        /// 获得请求中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int GetRequestInt(string key, int defaultValue)
        {
            if (HttpContext.Current.Request.Form[key] != null)
                return GetFormInt(key, defaultValue);
            else
                return GetQueryInt(key, defaultValue);
        }

        /// <summary>
        /// 获得请求中的值
        /// </summary>
        /// <param name="key">键</param>
        /// <returns></returns>
        public static int GetRequestInt(string key)
        {
            if (HttpContext.Current.Request.Form[key] != null)
                return GetFormInt(key);
            else
                return GetQueryInt(key);
        }
    }
}
