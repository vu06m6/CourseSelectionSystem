using CourseSelectionSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CourseSelectionSystem.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Course()
        {
            return View();
        }

        public ActionResult Student()
        {
            return View();
        }

        public ActionResult StudentTable()
        {
            using (var entity = new CourseSelectionSystemEntities())
            {
                return PartialView("_StudentTable", entity.StudentMain.ToList().Select(x => new StudentModel(x)));
            }
        }

        /// <summary>
        /// 學生資料修改
        /// </summary>
        /// <param name="rqModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult StudentModify(StudentModel rqModel)
        {
            var code = "S";
            var message = "資料更新成功";
            try
            {
                using (var entity = new CourseSelectionSystemEntities())
                {
                    if (string.IsNullOrEmpty(rqModel.Serial))
                    {
                        var data = new StudentMain()
                        {
                            Number = rqModel.Number,
                            Name = rqModel.Name,
                            Birthday = DateTime.TryParse(rqModel.Birthday, out DateTime bd) ? bd : default,
                            Email = rqModel.Email
                        };
                        entity.StudentMain.Add(data);
                        entity.SaveChanges();
                    }
                    else
                    {
                        var sn = Convert.ToInt64(rqModel.Serial);
                        var raw = entity.StudentMain.Where(x => x.Serial == sn).FirstOrDefault();
                        if (raw != null)
                        {
                            raw.Number = rqModel.Number;
                            raw.Name = rqModel.Name;
                            raw.Birthday = DateTime.TryParse(rqModel.Birthday, out DateTime bd) ? bd : default;
                            raw.Email = rqModel.Email;
                            entity.Entry(raw).State = EntityState.Modified;
                            entity.SaveChanges();
                        }
                        else
                        {
                            code = "F";
                            message = "資料更新失敗";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                code = "F";
                message = "發生例外狀況 " + ex.Message;
            }
            return Json(new { code, message });
        }

        /// <summary>
        /// 學生資料刪除
        /// </summary>
        /// <param name="serial"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult StudentDelete(string serial)
        {
            var code = "S";
            var message = "資料更新成功";
            try
            {
                using (var entity = new CourseSelectionSystemEntities())
                {
                    if (!string.IsNullOrEmpty(serial))
                    {
                        var sn = Convert.ToInt64(serial);
                        var raw = entity.StudentMain.Where(x => x.Serial == sn).FirstOrDefault();
                        if (raw != null)
                        {
                            entity.Entry(raw).State = EntityState.Deleted;
                            entity.SaveChanges();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                code = "F";
                message = "發生例外狀況 " + ex.Message;
            }
            return Json(new { code, message });
        }

        public ActionResult Selection()
        {
            return View();
        }
    }
}