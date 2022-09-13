using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc1_student.Models;
using Mvc1_student.ViewModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Mvc1_student.Controllers
{
    public class stdController : Controller
    {
        MvcdbEntities2 db = new MvcdbEntities2();

        studentViewModel stdData = new studentViewModel();
       
        // GET: std
        public ActionResult Index()
        {           
            //var q = db.tb1_std.ToList();

            List<tb1_std> student = db.tb1_std.ToList();
            List<tb1_cls> classs = db.tb1_cls.ToList();
            List<tb1_sub> subject = db.tb1_sub.ToList();

            var Detail = from std in student
                         join cls in classs on std.std_clsid equals cls.cls_id
                         join sub in subject on std.std_subid equals sub.sub_id
                         select std;
            
            return View(Detail);
        }

        // GET: std/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: std/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: std/Create
        [HttpPost]
        public ActionResult Create(studentViewModel student)
        {
            try
            {
                // TODO: Add insert logic here

                tb1_std std = new tb1_std();
                tb1_cls cls = new tb1_cls();
                tb1_sub subj = new tb1_sub();

                std.std_name = student.std_name;
                std.std_add = student.std_add;
                std.std_phn = student.std_phn;
                            
                int studentid = std.std_id;  //.............
               
                cls.cls_name = student.cls_name;               
                int classid = cls.cls_id;  //.............
               
                subj.sub_one = student.sub_one;
                subj.sub_two = student.sub_two;
                subj.sub_three = student.sub_three;
                int subid = subj.sub_id;   //..............

                std.std_clsid = classid;
                std.std_subid = subid;

                db.tb1_std.Add(std);               
                db.tb1_cls.Add(cls);               

                db.tb1_sub.Add(subj);
                db.SaveChanges();
               // db.SaveChanges();
               // db.SaveChanges();

                return RedirectToAction("Index");
              

            }
            catch
            {
                ViewBag.msg = "Data Not add";
                return View();
            }
        }
        

        // GET: std/Edit/5
        public ActionResult Edit(int id)           
        {
            var user = db.tb1_std.Where(s => s.std_id == id).FirstOrDefault();

                var vm = new studentViewModel {
                    std_id = user.std_id,
                    std_name =user.std_name,
                    std_add=user.std_add,
                    std_phn =user.std_phn,
                    std_clsid =user.tb1_cls.cls_id,
                    cls_name = user.tb1_cls.cls_name,
                    std_subid=user.tb1_sub.sub_id,
                    sub_one =user.tb1_sub.sub_one,
                    sub_two =user.tb1_sub.sub_two,
                    sub_three =user.tb1_sub.sub_three
                };
                return View(vm);               
        }

        // POST: std/Edit/5
        [HttpPost]
        public ActionResult Edit(studentViewModel student)
        {
            try
            {
                // TODO: Add update logic here
                var user = db.tb1_std.Where(c => c.std_id == student.std_id ).FirstOrDefault();              

                user.std_id = student.std_id;
                user.std_name = student.std_name;
                user.std_add = student.std_add;
                user.std_phn = student.std_phn;
                user.tb1_cls.cls_name = student.cls_name;
                user.tb1_sub.sub_one = student.sub_one;
                user.tb1_sub.sub_two = student.sub_two;
                user.tb1_sub.sub_three = student.sub_three;

                db.SaveChanges();

                return RedirectToAction("Index");               
            }
            catch
            {
                ViewBag.msg = "not update";
                return View();
            }
        }

        // GET: std/Delete/5
        public ActionResult Delete(int id)
        {
            return View(db.tb1_std.Find(id));
        }

        // POST: std/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, tb1_std p)
        {
            try
            {
                // TODO: Add delete logic here
                var q = db.tb1_std.Find(id);
                db.Entry(q).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
