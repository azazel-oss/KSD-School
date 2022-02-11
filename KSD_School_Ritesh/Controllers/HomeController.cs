using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSD_School_Ritesh.Models;
using KSD_School_Ritesh.DAL;

namespace KSD_School_Ritesh.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult index()
        {

            return View();
        }
        StudentDAL studentDal=new StudentDAL();
        ClassDAL classDal = new ClassDAL();
        FeesDAL feesDAL = new FeesDAL();
        StaffDAL staffDAL = new StaffDAL();
        SubjectsDAL subjectDAL = new SubjectsDAL();

        public ActionResult student()
        {
           if ( Session["Username"] == null) 
            {
                return RedirectToAction("Login", "Auth");
            }
            else { return View(); }
           
        }
        public JsonResult List()
        {
            return Json(studentDal.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Student emp)
        {
            return Json(studentDal.Add(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
            var Student = studentDal.ListAll().Find(x => x.Student_id.Equals(ID));
            return Json(Student, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Student emp)
        {
            return Json(studentDal.Update(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(studentDal.Delete(ID), JsonRequestBehavior.AllowGet);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public ActionResult staff()
        {

            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            else { return View(); }
        }
        public JsonResult staList()
        {
            return Json(staffDAL.staListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult staAdd(Staff emp)
        {
            return Json(staffDAL.staAdd(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult stagetbyID(int ID)
        {
            var Staf = staffDAL.staListAll().Find(x => x.Staff_id.Equals(ID));
            return Json(Staf, JsonRequestBehavior.AllowGet);
        }
        public JsonResult staUpdate(Staff emp)
        {
            return Json(staffDAL.staUpdate(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult staDelete(int ID)
        {
            return Json(staffDAL.staDelete(ID), JsonRequestBehavior.AllowGet);
        }
        ////
        ///

        ///
        public ActionResult fees()
        {

            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            else { return View(); }
        }
        public JsonResult feList()
        {
            return Json(feesDAL.feListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult feAdd(Fees emp)
        {
            return Json(feesDAL.feAdd(emp), JsonRequestBehavior.AllowGet);
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

            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            else { return View(); }
        }
        public JsonResult claList()
        {
            return Json(classDal.claListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult claAdd(Class emp)
        {
            return Json(classDal.claAdd(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult claGetbyID(int ID)
        {
            var clas = classDal.claListAll().Find(x => x.Class_id.Equals(ID));
            return Json(clas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult claUpdate(Class emp)
        {
            return Json(classDal.claUpdate(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult claDelete(int ID)
        {
            return Json(classDal.claDelete(ID), JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public ActionResult subjects()
        {

            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            else { return View(); }
        }
        public JsonResult subList()
        {
            return Json(subjectDAL.subListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult subAdd(Subjects emp)
        {
            return Json(subjectDAL.subAdd(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult subGetbyID(int ID)
        {
            var subj = subjectDAL.subListAll().Find(x => x.Subject_id.Equals(ID));
            return Json(subj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult subUpdate(Subjects emp)
        {
            return Json(subjectDAL.subUpdate(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult subDelete(int ID)
        {
            return Json(subjectDAL.subDelete(ID), JsonRequestBehavior.AllowGet);
        }

    }
}