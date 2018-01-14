using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using Domain;
using Modle;
using System.Text;

namespace WebApplication1.Controllers
{
    public class DemoController : Controller
    {
        ViewResultObj vr = new ViewResultObj();
        // GET: Demo
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public JsonResult GetStuData(List<FromParm> fromParm,int page = 1,int pageSize = 5)
        {

            try
            {
                StringBuilder DBWhere = new StringBuilder();
                if (fromParm!=null)
                {
                    foreach (FromParm item in fromParm)
                    {
                        if (item.value!=null||item.value!="")
                        {
                            DBWhere.AppendFormat(" and {0}='{1}'",item.name,item.value);
                        }
                    }
                }
                string whereStr = DBWhere.ToString();// 后续SQL查询条件
                TestBll bll = new TestBll();
                List<Student> stuList = bll.StuList;
                int count = stuList.Count;
                stuList = stuList.OrderByDescending(s => s.ID).Skip((page - 1) * pageSize).Take(pageSize).ToList();
                vr.BS = 1;
                vr.Msg = "成功";
                vr.count = count;
                vr.rows = stuList;
            }
            catch (Exception ex)
            {

                vr.BS = -99;
                vr.Msg = "异常" + ex.Message;
            }
            return Json(vr, JsonRequestBehavior.AllowGet);
        }


        #region 测试页
        public ActionResult TextIndex()
        {
            return View();

        }
        #endregion
    }
}