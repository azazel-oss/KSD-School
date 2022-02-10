using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSD_School_Ritesh.Models;
using KSD_School_Ritesh.DAL;
using System.Dynamic;

namespace KSD_School_Ritesh.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        StudentDAL studentObj = new StudentDAL();
        ClassDAL classObj = new ClassDAL();
        FeesDAL feesObj = new FeesDAL();
        StaffDAL staffObj = new StaffDAL();
        SubjectsDAL subjectObj = new SubjectsDAL();
        SessionDAL sessionObj = new SessionDAL();

        public ActionResult Student()
        {
            return View();
        }

        public ActionResult StudentDetails(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.student = studentObj.GetStudentById(Id);
            FeesDAL objFees = new FeesDAL();
            ViewData["FeeList"] = objFees.GetFeesFromStudentId(Id);
            mymodel.SessionList = sessionObj.ListAllSession();
            return View(mymodel);
        }
        public JsonResult List()
        {
            return Json(studentObj.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Student emp)
        {
            return Json(studentObj.Add(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Student = studentObj.ListAll().Find(x => x.Student_id.Equals(ID));
            return Json(Student, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Student emp)
        {
            return Json(studentObj.Update(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(studentObj.Delete(ID), JsonRequestBehavior.AllowGet);
        }

        public JsonResult ListSession()
        {
            return Json(sessionObj.ListAllSession(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddSession(Session session)
        {
            return Json(sessionObj.AddSession(session), JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public ActionResult Staff()
        {

            return View();
        }
        public JsonResult StaffList()
        {
            return Json(staffObj.StaffListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult StaffAdd(Staff staff)
        {
            return Json(staffObj.StaffAdd(staff), JsonRequestBehavior.AllowGet);
        }
        public JsonResult StaffGetbyID(int ID)
        {
            var _staff = staffObj.StaffListAll().Find(x => x.Staff_id.Equals(ID));
            return Json(_staff, JsonRequestBehavior.AllowGet);
        }
        public JsonResult StaffUpdate(Staff staff)
        {
            return Json(staffObj.StaffUpdate(staff), JsonRequestBehavior.AllowGet);
        }
        public JsonResult StaffDelete(int ID)
        {
            return Json(staffObj.StaffDelete(ID), JsonRequestBehavior.AllowGet);
        }
        ////
        ///

        ///
        public ActionResult Fees()
        {
            return View();
        }
        public JsonResult FeeList()
        {
            return Json(feesObj.FeeListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddFee(Fees fee)
        {
            return Json(feesObj.FeeAdd(fee), JsonRequestBehavior.AllowGet);
        }
        public JsonResult FeeGetbyID(int ID)
        {
            var fee = feesObj.FeeListAll().Find(x => x.Fee_id.Equals(ID));
            return Json(fee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult FeeUpdate(Fees fee)
        {
            return Json(feesObj.FeeUpdate(fee), JsonRequestBehavior.AllowGet);
        }
        public JsonResult FeeDelete(int ID)
        {
            return Json(feesObj.FeeDelete(ID), JsonRequestBehavior.AllowGet);
        }

        ////
        ///
        ////
        ///
        public ActionResult Class()
        {
            return View();
        }
        public JsonResult ClassList()
        {
            return Json(classObj.ClassListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ClassAdd(Class _class)
        {
            return Json(classObj.ClassAdd(_class), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ClassGetbyID(int ID)
        {
            var clas = classObj.ClassListAll().Find(x => x.Class_id.Equals(ID));
            return Json(clas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult ClassUpdate(Class _class)
        {
            return Json(classObj.ClassUpdate(_class), JsonRequestBehavior.AllowGet);
        }
        public JsonResult ClassDelete(int ID)
        {
            return Json(classObj.ClassDelete(ID), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult subjects()
        {

            return View();
        }
        public JsonResult subList()
        {
            return Json(subjectObj.subListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult subAdd(Subjects emp)
        {
            return Json(subjectObj.subAdd(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult subGetbyID(int ID)
        {
            var subj = subjectObj.subListAll().Find(x => x.Subject_id.Equals(ID));
            return Json(subj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult subUpdate(Subjects emp)
        {
            return Json(subjectObj.subUpdate(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult subDelete(int ID)
        {
            return Json(subjectObj.subDelete(ID), JsonRequestBehavior.AllowGet);
        }

    }
}