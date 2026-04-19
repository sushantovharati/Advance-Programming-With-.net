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

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginDto l)
        {
            if (ModelState.IsValid)
            {
                var user = (from e in db.Employees
                            where e.EmpEmail == l.EmpEmail && e.EmpPassword == l.EmpPassword
                            select e).FirstOrDefault();

                if (user != null)
                {
                    return RedirectToAction("EmployeeDashboard", new { name = user.EmpName });
                }
                else
                {
                    ModelState.AddModelError("", "Invalid email or password");
                }
            }

            return View(l);
        }
        public IActionResult EmployeeDashboard(string name)
        {
            ViewBag.Name = name;
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
            if ((from e in db.Employees where e.EmpEmail == r.Email select e).Any())
            {
                ModelState.AddModelError("Email", "Email already exists");
            }

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
