using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CRUDWebApplication1.Context;

namespace CRUDWebApplication1.Controllers
{
    public class StudentController : Controller
    {
		// GET: Student
		db_testEntities dbObj = new db_testEntities();
        public ActionResult Student( tbl_Student obj)
        {
			
             return View();
        }
		[HttpPost]
		public ActionResult AddStudent(tbl_Student model)
		{
			
			if (ModelState.IsValid)
			{
				tbl_Student obj = new tbl_Student();

				obj.ID = model.ID;
				obj.Name = model.Name;
				obj.Fname = model.Fname;
				obj.Email = model.Email;
				obj.Mobile = model.Mobile;
				obj.Description = model.Description;

				dbObj.tbl_Student.Add(obj);
				dbObj.SaveChanges();

				if (model.ID == 0)
				{
					dbObj.tbl_Student.Add(obj);
					dbObj.SaveChanges();
				}
				else
				{
					dbObj.Entry(obj).State = System.Data.Entity.EntityState.Modified;
					dbObj.SaveChanges();
				}
			}
			ModelState.Clear();


			return View("Student");
		}


		public ActionResult StudentList()
		{
			var res = dbObj.tbl_Student.ToList();

			return View(res);
		}

		public ActionResult Delete(int id)
		{

			var res = dbObj.tbl_Student.Where(x => x.ID == id).First();
			dbObj.tbl_Student.Remove(res);
			dbObj.SaveChanges();

			var List = dbObj.tbl_Student.ToList();

			return View(" StudentList",List);


		}
			

				

		


	}
}