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
        #region 首頁
        public ActionResult Index()
        {
            return View();
        }
        #endregion

        #region 課程編輯
        public ActionResult Course()
        {
            return View();
        }

        /// <summary>
        /// 課程表格
        /// </summary>
        /// <returns></returns>
        public ActionResult CourseTable()
        {
            using (var entity = new CourseSelectionSystemEntities())
            {
                var result = entity.CourseMain.ToList()
                    .Select(x => new CourseModel
                    {
                        Serial = x.Serial.ToString(),
                        Number = x.Number,
                        Name = x.Name,
                        Credits = x.Credits.ToString(),
                        Location = x.Location,
                        LecturerName = x.LecturerName,
                    }).ToList();
                return PartialView("_CourseTable", result);
            }
        }

        /// <summary>
        /// 課程修改
        /// </summary>
        /// <param name="rqModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CourseModify(CourseModel rqModel)
        {
            var code = "S";
            var message = "資料更新成功";
            try
            {
                using (var entity = new CourseSelectionSystemEntities())
                {
                    if (string.IsNullOrEmpty(rqModel.Serial))
                    {
                        var data = new CourseMain()
                        {
                            Number = rqModel.Number,
                            Name = rqModel.Name,
                            Credits = int.TryParse(rqModel.Credits, out int credits) ? credits : 0,
                            Location = rqModel.Location,
                            LecturerName = rqModel.LecturerName
                        };
                        entity.CourseMain.Add(data);
                        entity.SaveChanges();
                    }
                    else
                    {
                        var sn = Convert.ToInt64(rqModel.Serial);
                        var raw = entity.CourseMain.Where(x => x.Serial == sn).FirstOrDefault();
                        if (raw != null)
                        {
                            raw.Number = rqModel.Number;
                            raw.Name = rqModel.Name;
                            raw.Credits = int.TryParse(rqModel.Credits, out int credits) ? credits : 0;
                            raw.Location = rqModel.Location;
                            raw.LecturerName = rqModel.LecturerName;
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
        /// 課程資料刪除
        /// </summary>
        /// <param name="serial"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CourseDelete(string serial)
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
                        var raw = entity.CourseMain.Where(x => x.Serial == sn).FirstOrDefault();
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

        #endregion

        #region 學生編輯
        public ActionResult Student()
        {
            return View();
        }

        /// <summary>
        /// 學生表格
        /// </summary>
        /// <returns></returns>
        public ActionResult StudentTable()
        {
            using (var entity = new CourseSelectionSystemEntities())
            {
                var result = entity.StudentMain.ToList()
                    .Select(x => new StudentModel
                    {
                        Serial = x.Serial.ToString(),
                        Number = x.Number,
                        Name = x.Name,
                        Birthday = x.Birthday.ToString("yyyy-MM-dd"),
                        Email = x.Email,
                    }).ToList();
                return PartialView("_StudentTable", result);
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
        #endregion

        #region 選課
        public ActionResult Selection()
        {
            using (var entity = new CourseSelectionSystemEntities())
            {
                ViewBag.Students = entity.StudentMain.ToList();
                ViewBag.Courses = entity.CourseMain.ToList();
                return View();
            }
        }

        /// <summary>
        /// 課程表格
        /// </summary>
        /// <returns></returns>
        public ActionResult SelectionTable()
        {
            using (var entity = new CourseSelectionSystemEntities())
            {
                var result = entity.StudentCourse.ToList().GroupBy(x => x.StudentNumber)
                    .Select(x => new SelectionModel
                    {
                        StudentNumber = x.Key,
                        Course = string.Join("、", x.Select(y => y.CourseMain.Name)),
                        CheckedCourse = x.Select(y => y.CourseMain.Number).ToList()
                    }).ToList();
                return PartialView("_SelectionTable", result);
            }
        }

        /// <summary>
        /// 課程修改
        /// </summary>
        /// <param name="rqModel"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SelectionModify(SelectionModel rqModel)
        {
            var code = "S";
            var message = "資料更新成功";
            try
            {
                using (var entity = new CourseSelectionSystemEntities())
                {
                    if (!string.IsNullOrEmpty(rqModel.StudentNumber))
                    {
                        var raw = entity.StudentCourse.Where(x => x.StudentNumber == rqModel.StudentNumber).ToList();
                        if (raw.Any())
                        {
                            foreach (var each in raw)
                            {
                                entity.Entry(each).State = EntityState.Deleted;
                                entity.SaveChanges();
                            }
                        }
                    }
                    if (rqModel.CheckedCourse.Any())
                    {
                        foreach (var each in rqModel.CheckedCourse)
                        {
                            var data = new StudentCourse()
                            {
                                StudentNumber = rqModel.StudentNumber,
                                CourseNumber = each
                            };
                            entity.StudentCourse.Add(data);
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

        /// <summary>
        /// 課程資料刪除
        /// </summary>
        /// <param name="serial"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SelectionDelete(string studentnumber)
        {
            var code = "S";
            var message = "資料更新成功";
            try
            {
                using (var entity = new CourseSelectionSystemEntities())
                {
                    if (!string.IsNullOrEmpty(studentnumber))
                    {
                        var raw = entity.StudentCourse.Where(x => x.StudentNumber == studentnumber).ToList();
                        if (raw.Any())
                        {
                            foreach (var each in raw)
                            {
                                entity.Entry(each).State = EntityState.Deleted;
                                entity.SaveChanges();
                            }
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

        #endregion
    }
}