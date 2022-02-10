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
        public ActionResult login()
        {

            return View();
        }
        public ActionResult index()
        {

            return View();
        }
        StudentDAL studentObj = new StudentDAL();
        ClassDAL classObj = new ClassDAL();
        FeesDAL feesDAL = new FeesDAL();
        StaffDAL staffObj = new StaffDAL();
        SubjectsDAL subjectObj = new SubjectsDAL();
        SessionDAL sessionObj = new SessionDAL();

        public ActionResult student()
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

        public ActionResult staff()
        {

            return View();
        }
        public JsonResult staList()
        {
            return Json(staffObj.staListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult staAdd(Staff emp)
        {
            return Json(staffObj.staAdd(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult stagetbyID(int ID)
        {
            var Staf = staffObj.staListAll().Find(x => x.Staff_id.Equals(ID));
            return Json(Staf, JsonRequestBehavior.AllowGet);
        }
        public JsonResult staUpdate(Staff emp)
        {
            return Json(staffObj.staUpdate(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult staDelete(int ID)
        {
            return Json(staffObj.staDelete(ID), JsonRequestBehavior.AllowGet);
        }
        ////
        ///

        ///
        public ActionResult fees()
        {

            return View();
        }
        public JsonResult feList()
        {
            return Json(feesDAL.feListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddFee(Fees fee)
        {
            return Json(feesDAL.FeeAdd(fee), JsonRequestBehavior.AllowGet);
        }
        public JsonResult feGetbyID(int ID)
        {
            var fee = feesDAL.feListAll().Find(x => x.Fee_id.Equals(ID));
            return Json(fee, JsonRequestBehavior.AllowGet);
        }
        public JsonResult feUpdate(Fees emp)
        {
            return Json(feesDAL.feUpdate(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult feDelete(int ID)
        {
            return Json(feesDAL.feDelete(ID), JsonRequestBehavior.AllowGet);
        }

        ////
        ///
        ////
        ///
        public ActionResult _class()
        {

            return View();
        }
        public JsonResult claList()
        {
            return Json(classObj.claListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult claAdd(Class emp)
        {
            return Json(classObj.claAdd(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult claGetbyID(int ID)
        {
            var clas = classObj.claListAll().Find(x => x.Class_id.Equals(ID));
            return Json(clas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult claUpdate(Class emp)
        {
            return Json(classObj.claUpdate(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult claDelete(int ID)
        {
            return Json(classObj.claDelete(ID), JsonRequestBehavior.AllowGet);
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