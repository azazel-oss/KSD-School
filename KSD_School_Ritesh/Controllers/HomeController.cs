using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KSD_School_Ritesh.Models;
using KSD_School_Ritesh.DAL;
using System.Dynamic;
using Newtonsoft.Json;

namespace KSD_School_Ritesh.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            return View();
        }

        #region DAL Declarations
        StudentDAL studentDal = new StudentDAL();
        ClassDAL classDal = new ClassDAL();
        FeesDAL feesDAL = new FeesDAL();
        StaffDAL staffDAL = new StaffDAL();
        SubjectsDAL subjectDAL = new SubjectsDAL();
        MarksDAL MarksDal = new MarksDAL();
        SessionDAL SessionDal = new SessionDAL();
        CanteenBillDAL canteenBillDAL = new CanteenBillDAL();
        CanteenInventoryDAL CanteenInventoryDal = new CanteenInventoryDAL();
        SectionDAL sectionObj = new SectionDAL();
        TimetableDAL timetableObj = new TimetableDAL();
        QuestionDAL questionObj = new QuestionDAL();
        ExamDAL examObj = new ExamDAL();

        #endregion

        #region Student
        public ActionResult student()
        {
            //if (Session["Username"] == null)
            //{
            //    return RedirectToAction("Login", "Auth");
            //}
            //else { return View(); }
            return View();

        }
        public ActionResult StudentDetails(int Id)
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.student = studentDal.GetStudentById(Id);
            FeesDAL objFees = new FeesDAL();
            ViewData["FeeList"] = objFees.GetFeesFromStudentId(Id);
            mymodel.SessionList = SessionDal.ListAllSession();
            return View(mymodel);
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

        public JsonResult ListSession()
        {
            return Json(SessionDal.ListAllSession(), JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddSession(Session session)
        {
            return Json(SessionDal.AddSession(session), JsonRequestBehavior.AllowGet);
        } 
        #endregion

        #region Staff
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
        #endregion

        #region Fees
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
        #endregion

        #region Class
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
        #endregion

        #region Subjects
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
        #endregion

        #region Marks
        public ActionResult Marks(Marks mrk)
        {
            dynamic mymodel = new ExpandoObject();

            ViewData["Sessionlist"] = MarksDal.Distinct_session();



            ViewData["Studentlist"] = MarksDal.Distinct_Student();
            ViewData["Alldata"] = MarksDal.Showmarks();



            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            else { return View(); }

        }
        public JsonResult Showmarks(Marks emp)
        {
            return Json(MarksDal.Showmarks(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Addmarks(Marks emp)
        {
            return Json(MarksDal.Addmarks(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult MarksGetbyID(int ID)
        {
            var subj = MarksDal.Showmarks().Find(x => x.id.Equals(ID));
            return Json(subj, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Updatemarks(Marks emp)
        {
            return Json(MarksDal.Updatemarks(emp), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Deletemarks(int ID)
        {
            return Json(MarksDal.Deletemarks(ID), JsonRequestBehavior.AllowGet);
        } 
        #endregion

        #region Canteen Bill
        public ActionResult CanteenBill()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Auth");
            }
            else { return View(); }
        }
        public JsonResult ShowCanteenBills()
        {
            return Json(canteenBillDAL.ListAllBills(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddBill(CanteenBill parchi)
        {
            return Json(canteenBillDAL.AddBill(parchi), JsonRequestBehavior.AllowGet);
        }

        public JsonResult getBillByID(int ID)
        {
            var canteen = canteenBillDAL.ListAllBills().Find(x => x.Id.Equals(ID));
            return Json(canteen, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateBill(CanteenBill parchi)
        {
            return Json(canteenBillDAL.UpdateBill(parchi), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteBill(int ID)
        {
            return Json(canteenBillDAL.DeleteBill(ID), JsonRequestBehavior.AllowGet);
        } 
        #endregion

        #region Canteen Inventory
        public ActionResult CanteenInventory()
        {
            //if (Session["Username"] == null)
            //{
            //    return RedirectToAction("Login", "Auth");
            //}
            //else { return View(); }
            return View();
        }
        public JsonResult ListItem()
        {
            return Json(CanteenInventoryDal.ListAllItems(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult AddItem(CanteenInventory parchi)
        {
            return Json(CanteenInventoryDal.AddItem(parchi), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetItemByID(int ID)
        {
            var canteen = CanteenInventoryDal.ListAllItems().Find(x => x.Id.Equals(ID));
            return Json(canteen, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateItem(CanteenInventory parchi)
        {
            return Json(CanteenInventoryDal.UpdateItem(parchi), JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteItem(int ID)
        {
            return Json(CanteenInventoryDal.DeleteItem(ID), JsonRequestBehavior.AllowGet);
        } 
        #endregion

        #region Section
        public ActionResult Section()
        {
            return View();
        }
        public JsonResult SectionList()
        {
            return Json(sectionObj.ListAllSection(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult SectionAdd(Section section)
        {
            return Json(sectionObj.AddSection(section), JsonRequestBehavior.AllowGet);
        }
        public JsonResult SectionGetbyID(int ID)
        {
            var clas = sectionObj.ListAllSection().Find(x => x.Id.Equals(ID));
            return Json(clas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SectionUpdate(Section section)
        {
            return Json(sectionObj.UpdateSection(section), JsonRequestBehavior.AllowGet);
        }
        public JsonResult SectionDelete(int ID)
        {
            return Json(sectionObj.DeleteSection(ID), JsonRequestBehavior.AllowGet);
        } 
        #endregion

        #region Timetable
        public ActionResult TimeTable()
        {
            List<SelectListItem> classItems = new List<SelectListItem>();
            foreach (var item in classDal.claListAll())
            {
                classItems.Add(new SelectListItem
                {
                    Text = item.Class_name.Trim(),
                    Value = item.Class_id.ToString()
                });
            }
            List<SelectListItem> subjectItems = new List<SelectListItem>();
            foreach (var item in subjectDAL.subListAll())
            {
                subjectItems.Add(new SelectListItem
                {
                    Text = item.Subject_name.Trim(),
                    Value = item.Subject_id.ToString()
                });
            }
            List<SelectListItem> staffItems = new List<SelectListItem>();
            foreach (var item in staffDAL.staListAll())
            {
                staffItems.Add(new SelectListItem
                {
                    Text = item.Name.Trim(),
                    Value = item.Staff_id.ToString()
                });
            }
            List<SelectListItem> sectionItems = new List<SelectListItem>();
            foreach (var item in sectionObj.ListAllSection())
            {
                sectionItems.Add(new SelectListItem
                {
                    Text = item.Room.Trim(),
                    Value = item.Id.ToString()
                });
            }
            ViewBag.ClassItems = classItems;
            ViewBag.SubjectItems = subjectItems;
            ViewBag.StaffItems = staffItems;
            ViewBag.SectionItems = sectionItems;
            return View();
        }
        public JsonResult TimetableList()
        {
            return Json(timetableObj.ListTimetable(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult TimetableAdd(Timetable timetable)
        {
            return Json(timetableObj.AddTimetable(timetable), JsonRequestBehavior.AllowGet);
        }
        public JsonResult TimetableGetbyID(int ID)
        {
            var clas = timetableObj.ListTimetable().Find(x => x.Id.Equals(ID));
            return Json(clas, JsonRequestBehavior.AllowGet);
        }
        public JsonResult TimetableUpdate(Timetable timetable)
        {
            return Json(timetableObj.UpdateTimetable(timetable), JsonRequestBehavior.AllowGet);
        }
        public JsonResult TimetableDelete(int ID)
        {
            return Json(timetableObj.DeleteTimetable(ID), JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Exam

        public JsonResult AddExamTerm(Exam exam)
        {
            var result = Json(examObj.AddExamTerm(exam), JsonRequestBehavior.AllowGet);
            return result;
        }
        public JsonResult GetExamIdFromData(ExamData exam)
        {
            var result = Json(questionObj.GetExamIdFromData(exam), JsonRequestBehavior.AllowGet);
            return result;
        }

        public ActionResult ExamTeacher()
        {
            dynamic mymodel = new ExpandoObject();
            mymodel.SessionList = SessionDal.ListAllSession();
            mymodel.ClassList = classDal.claListAll();
            mymodel.SubjectList = subjectDAL.subListAll();
            ViewData["QuestionList"] = questionObj.Listque();
            return View(mymodel);
        }
        #endregion
       
        #region Question
        public ActionResult Question() { 
            return View();
        }
        public JsonResult AddQuestion(string q, string o)
        {
            Question question = JsonConvert.DeserializeObject<Question>(q);
            List<Option> options = JsonConvert.DeserializeObject<List<Option>>(o);
            return Json(questionObj.AddQuestion(question, options), JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetQuestionsToDisplay(int examId)
        {
            return Json(questionObj.GetQuestionsFromExamId(examId), JsonRequestBehavior.AllowGet);
        }
        //public ActionResult Question(login log) {
        //    //LoginDAL loginDA = new LoginDAL();
        //    //string role = loginDA.LoginCheck(log);

        //    //if (role == "student")
        //    //{
        //    //    ViewData["name"] = log.Username;
        //    //    Session["Username"] = log.Username;
        //    //    
        //    //}
        //    //else
        //    //{
        //    //    return RedirectToAction("login", "auth");

        //    //}
        //    return View();
        //}
        public JsonResult Listque()
        {
            return Json(questionObj.Listque(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult queGetbyID(int ID)
        {
            var clas = questionObj.Listque().Find(x => x.que_id.Equals(ID));
            return Json(clas, JsonRequestBehavior.AllowGet);
        }
        //public JsonResult Updateque(Question que)
        //{
        //    return Json(questionObj.Updateque(que), JsonRequestBehavior.AllowGet);
        //}
        public JsonResult Deleteque(int ID)
        {
            return Json(questionObj.Deleteque(ID), JsonRequestBehavior.AllowGet);
        }
        #endregion

    }
}
    