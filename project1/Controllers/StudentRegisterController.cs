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
                return RedirectToAction("Index");
            }
            return View(obj);
     


        }


    }

}


