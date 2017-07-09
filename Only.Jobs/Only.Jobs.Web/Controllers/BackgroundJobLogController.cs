using Only.Jobs.Core.Business.Manager;
using Only.Jobs.Core.Common;
using Only.Jobs.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Only.Jobs.Web.Controllers
{
    public class BackgroundJobLogController : BaseController
    {
        //
        // GET: /BackgroundJobLog/

        [HttpGet]
        public ActionResult List()
        {
            BackgroundJobService _BackgroundJobService = new BackgroundJobService();
            var data = _BackgroundJobService.GetBackgroundJobLogInfoPagerList(this.GetPageParameter());
            var result = new ResponseResult() { success = true, message = "数据获取成功", data = data };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Info()
        {
            return View();
        }

        [HttpGet]
        public ActionResult InfoData(System.Guid BackgroundJobLogId)
        {
            var result = new ResponseResult();
            BackgroundJobService _BackgroundJobService = new BackgroundJobService();
            result.data = _BackgroundJobService.GetBackgroundJobLogInfo(BackgroundJobLogId);
            result.success = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Delete(string idList)
        {
            var result = new ResponseResult();
            BackgroundJobService _BackgroundJobService = new BackgroundJobService();
            result.success = _BackgroundJobService.DeleteBackgroundJobLog(Utils.StringToGuidList(idList));
            result.message = result.success == true ? "操作成功" : "操作失败";
            return Json(result);
        }
    }
}
