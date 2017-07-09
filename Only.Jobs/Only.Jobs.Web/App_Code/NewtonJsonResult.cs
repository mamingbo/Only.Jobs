using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Mvc;


namespace Only.Jobs.Web
{
    public class NewtonJsonResult : JsonResult
    {
        public JsonSerializerSettings JsonSerializerSettings { get; set; }
        public NewtonJsonResult()
        {
            this.JsonRequestBehavior = JsonRequestBehavior.DenyGet;
        }
        public NewtonJsonResult(object obj)
        {
            this.JsonRequestBehavior = JsonRequestBehavior.DenyGet;
            this.Data = obj;
        }
        public NewtonJsonResult(object obj, JsonSerializerSettings jsonSerializerSettings)
        {
            this.JsonRequestBehavior = JsonRequestBehavior.DenyGet;
            this.Data = obj;
            this.JsonSerializerSettings = jsonSerializerSettings;
        }

        public NewtonJsonResult(object obj, JsonRequestBehavior behavior, JsonSerializerSettings jsonSerializerSettings)
        {
            this.JsonRequestBehavior = behavior;
            this.Data = obj;
            this.JsonSerializerSettings = jsonSerializerSettings;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            if ((this.JsonRequestBehavior == JsonRequestBehavior.DenyGet) && (string.Equals(context.HttpContext.Request.HttpMethod, "GET", StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("该方法当前不允许使用Get");
            }
            HttpResponseBase response = context.HttpContext.Response;
            if (!string.IsNullOrEmpty(this.ContentType))
            {
                response.ContentType = this.ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }
            if (this.ContentEncoding != null)
            {
                response.ContentEncoding = this.ContentEncoding;
            }
            if (this.Data != null)
            {
                string strJson = JsonConvert.SerializeObject(this.Data, JsonSerializerSettings);
                response.Write(strJson);
                response.End();
            }
        }
    }
}