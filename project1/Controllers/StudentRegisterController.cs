using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using project1.Data;
using project1.Models;

namespace project1.Controllers
{
    public class StudentRegisterController : Controller
    {
        private readonly ApplicationDbContext _Db;

        public StudentRegisterController(ApplicationDbContext Db)
        {
            _Db= Db;

        }
        public IActionResult Index()
        {

            IEnumerable<Student> objStudentList = _Db.Students;
            return View(objStudentList);
        }

        //get
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student obj)
        {

            if (ModelState.IsValid)
            {
                _Db.Students.Add(obj);
                _Db.SaveChanges();
                TempData["success"] = "student Create successfully";
                return RedirectToAction("Index");
            }
            return View(obj);


        }

        //Edit
        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            var studentFromDb= _Db.Students.Find(Id);

            if (studentFromDb==null)
            {
                return NotFound();
            }

            
            return View(studentFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student obj)
        {

            if (ModelState.IsValid)
            {
                _Db.Students.Update(obj);
                _Db.SaveChanges();
                TempData["success"] = "student edit successfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }



        //Delete
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var studentFromDb = _Db.Students.Find(Id);

            if (studentFromDb == null)
            {
                return NotFound();
            }

            return View(studentFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {

       
            var obj = _Db.Students.Find(Id);

            if (obj == null)
            {
                return NotFound();
            }
            
                _Db.Students.Remove(obj);
                _Db.SaveChanges();

            TempData["success"] = "student Delete successfully";
            return RedirectToAction("Index");
            
        }


    }

}


