using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using work_with_multiple_table.Data;
using work_with_multiple_table.Models;
using work_with_multiple_table.Models.ViewModel;

namespace work_with_multiple_table.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationContext context;

        public EmployeeController(ApplicationContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            EmployeeDepartmentListView emp = new EmployeeDepartmentListView();
            var empData = context.Employees.ToList();
            var deptData = context.Departments.ToList();

            emp.employees = empData;
            emp.departments = deptData;

            return View(emp);
        }
        // get
        public async Task<IActionResult> Create(int id)
        {
            ViewBag.department = await context.Departments.ToListAsync();
            EmployeeDepartmentSummaryView employeeDepartment = new EmployeeDepartmentSummaryView();
            try
            {
                if (id == 0)
                {
                    return View(employeeDepartment);
                }
                else
                {
                    employeeDepartment = ((EmployeeDepartmentSummaryView)(from e in context.Employees.Where(e => e.EmployeeId == id)
                                          join d in context.Departments
                                          on e.DepartmentId equals d.DepartmentId
                                          select new EmployeeDepartmentSummaryView
                                          {
                                              EmployeeId = e.EmployeeId,
                                              name = e.name,
                                              age = e.age,
                                              gender = e.gender,
                                              DateofBirth = e.DateofBirth,
                                              DepartmentId = d.DepartmentId,
                                              deptcode = d.deptcode,
                                              deptname = d.deptname
                                          }));
                    if (employeeDepartment == null)
                    {
                        return NotFound();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View(employeeDepartment);
}

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeDepartmentSummaryView empDep)
        {
            ViewBag.department = await context.Departments.ToListAsync();
            try
            {
                ModelState.Remove("deptcode");
                if (!ModelState.IsValid)
                {
                    ModelState.AddModelError(string.Empty, "Please enter valid data!");
                    return View(empDep);
                }
                else
                {
                    var data = new Employee()
                    {
                        name = empDep.name,
                        age = empDep.age,
                        DateofBirth = empDep.DateofBirth,
                        deptname = empDep.deptname,
                        gender = empDep.gender,
                        DepartmentId = empDep.DepartmentId
                    };
                    await context.Employees.AddAsync(data);
                    await context.SaveChangesAsync();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return RedirectToAction("Index");
        }


    }
}
