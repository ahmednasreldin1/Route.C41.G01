using Microsoft.AspNetCore.Mvc;
using Route.C41.G01.BLL.Interfaces;
using Route.C41.G01.BLL.Repositories;
using Route.C41.G01.DAL.Models;

namespace Route.C41.G01.PL.Controllers
{
    // Inheritance : DepartmentController is   a Controller
    // Composition : DepartmentController has  a IDepartmentRepository
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentsRepo; // NULL

        public DepartmentController(IDepartmentRepository departmentsRepo) // Ask CLR for Creating an Object from any Class Implementing "IDepartmentRepository"
        {
            //_departmentsRepo = /*new DepartmentRepository();*/
            _departmentsRepo = departmentsRepo;
        }

        // /Department/Index
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentsRepo.GetAll();

            return View(departments);
        }

        // /Department/Create
        //[HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (ModelState.IsValid) // Server-Side Validation
            {
                var count = _departmentsRepo.Add(department);
                if (count > 0)
                    return RedirectToAction(nameof(Index));
            }

            return View(department);
        }
    }
}
