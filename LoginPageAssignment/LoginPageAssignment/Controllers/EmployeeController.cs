using LoginPageAssignment.DTOs;
using LoginPageAssignment.EF;
using LoginPageAssignment.EF.Tables;
using Microsoft.AspNetCore.Mvc;

namespace LoginPageAssignment.Controllers
{
    public class EmployeeController : Controller
    {
        public ShopMSContext db;
        public EmployeeController(ShopMSContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(RegistrationDto r)
        {
            if (ModelState.IsValid)
            {
                var emp = new Employee()
                {
                    EmpName = r.Name,
                    EmpEmail = r.Email,
                    EmpPassword = r.Password,
                };
                db.Employees.Add(emp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(r);
        }
    }
}
