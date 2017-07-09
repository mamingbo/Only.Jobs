using Only.Jobs.Core.Business.Info;
using Only.Jobs.Core.Common;
using Only.Jobs.Core.Services;
using System.Web.Mvc;

namespace Only.Jobs.Web.Controllers
{
    public class BackgroundJobController : BaseController
    {
        //
        // GET: /BackgroundJob/

        [HttpGet]
        public ActionResult List()
        {
            BackgroundJobService _BackgroundJobService = new BackgroundJobService();
            var data = _BackgroundJobService.GeBackgroundJobInfoPagerList(this.GetPageParameter());
            var result = new ResponseResult() { success = true, message = "数据获取成功", data = data };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddPost(BackgroundJobInfo Info)
        {
            var result = new ResponseResult();
            BackgroundJobService _BackgroundJobService = new BackgroundJobService();
            Info.BackgroundJobId = System.Guid.NewGuid();
            result.success = _BackgroundJobService.InsertBackgroundJob(Info);
            return Json(result);
        }

        public ActionResult Info()
        {
            return View();
        }

        [HttpGet]
        public ActionResult InfoData(System.Guid BackgroundJobId)
        {
            var result = new ResponseResult();
            BackgroundJobService _BackgroundJobService = new BackgroundJobService();
            result.data = _BackgroundJobService.GetBackgroundJobInfo(BackgroundJobId);
            result.success = true;
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult UpdatePost(BackgroundJobInfo Info)
        {
            var result = new ResponseResult();
            BackgroundJobService _BackgroundJobService = new BackgroundJobService();
            result.success = _BackgroundJobService.UpdateBackgroundJob(Info);
            return Json(result);
        }

        [HttpPost]
        public ActionResult Delete(string idList)
        {
            var result = new ResponseResult();
            BackgroundJobService _BackgroundJobService = new BackgroundJobService();
            string rtMsg = string.Empty;
            result.success = _BackgroundJobService.DeleteBackgroundJob(Utils.StringToGuidList(idList), out rtMsg);
            result.message = rtMsg;
            return Json(result);
        }

        [HttpPost]
        public ActionResult UpdateState(System.Guid BackgroundJobId, int State)
        {
            var result = new ResponseResult();
            BackgroundJobService _BackgroundJobService = new BackgroundJobService();
            result.success = _BackgroundJobService.UpdateBackgroundJobState(BackgroundJobId, State);
            result.message = result.success == true ? "操作成功" : "操作失败";
            return Json(result);
        }

    }
}
