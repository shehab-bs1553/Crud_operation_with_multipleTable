using Microsoft.AspNetCore.Mvc;
using work_with_multiple_table.Data;
using work_with_multiple_table.Models;

namespace work_with_multiple_table.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly ApplicationContext context;

        public DepartmentController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var deptData = context.Departments.ToList();
            return View(deptData);
        }

        // get
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Department obj)
        {
            //if (obj.Name == obj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("CustomError", "The DisplayOrder Can't exactly match the Name. ");
            //}
            if ((ModelState.IsValid))
            {
                context.Departments.Add(obj);
                context.SaveChanges();
                TempData["success"] = "Department created successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
    }
}
