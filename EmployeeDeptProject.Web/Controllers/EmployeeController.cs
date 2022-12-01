using EmployeeDeptProject.DataAccess.Data;
using EmployeeDeptProject.DataAccess.Repository.IRepository;
//using EmployeeDeptProject.Web.Data;
using EmployeeDeptProject.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace EmployeeDeptProject.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly EmployeeDBContext _db;
        public EmployeeController(IUnitOfWork unitOfWork,EmployeeDBContext db)
        {
            _unitOfWork = unitOfWork;
            _db = db;
        }
        

        public IActionResult Index()
       {
            var allemployees = _db.Employees.Include(c => c.Departments);
            
           //var allcategories = _unitOfWork.Employee.GetAll();


            //TempData["Lname"] = "Akash";
            //TempData["Fname"] = "Gawas";
            //ViewBag.MyName = "Hello";
               return View(allemployees);
       }
       
       
       public IActionResult EmpDetails(int? id)
       {
         var category = _unitOfWork.Employee.GetFirstOrDefault(c=>c.EmpId==id);
         return View(category);
       }
    //get post
       public IActionResult EmpCreate()
       {
          ViewBag.DeptId = new SelectList(_unitOfWork.Department.GetAll(), "DeptId","DeptName");
          return View();
       }
       [HttpPost]
       [ValidateAntiForgeryToken]
       public IActionResult EmpCreate(Employee catobj)
       {

            //if (catobj.CategoryName == catobj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("custom error", "Display order cannot match the category name");
            //}
            _unitOfWork.Employee.Add(catobj);
            _unitOfWork.Save();
            TempData["Success"] = "Sucessfully Inserted the data";
            return RedirectToAction(nameof(Index));
            if (ModelState.IsValid)
           {
                
            }
           else
           {
                ViewBag.DeptId = new SelectList(_unitOfWork.Department.GetAll(), "DeptId", "DeptName");
                return View();
           }
       }
       public IActionResult EmpEdit(int? id)
       {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDB = _unitOfWork.Employee.GetFirstOrDefault(c=>c.EmpId==id);
            if (categoryFromDB == null)
            {
                return NotFound();
            }
            ViewBag.DeptId = new SelectList(_unitOfWork.Department.GetAll(), "DeptId", "DeptName");
            return View(categoryFromDB);
       }
       [HttpPost]
       [ValidateAntiForgeryToken]
       [ActionName("EmpEdit")]
       public IActionResult EmpEdit(Employee catobj)
       {


           _unitOfWork.Employee.Update(catobj);
           _unitOfWork.Save();
           TempData["Success"] = "Sucessfully Update the data";
            ViewBag.DeptId = new SelectList(_unitOfWork.Department.GetAll(), "DeptId", "DeptName");
            return RedirectToAction(nameof(Index));

       }

       public IActionResult EmpDelete(int? id)
       {
           if (id == null || id == 0)
           {
            return NotFound();
           }
           var categoryFromDB = _unitOfWork.Employee.GetFirstOrDefault(c=>c.EmpId==id);
           if (categoryFromDB == null)
           {
            return NotFound();
           }
           return View(categoryFromDB);
       }
       [HttpPost]
       [ActionName("EmpDelete")]
       public IActionResult EmpDeletePost(int? id)
       {
            var obj = _unitOfWork.Employee.GetFirstOrDefault(c=>c.EmpId==id);
            if (obj == null)
            {
               return NotFound();
            }
            _unitOfWork.Employee.Remove(obj);
            _unitOfWork.Save();
             TempData["Success"] = "Sucessfully Deleted the data";
             return RedirectToAction(nameof(Index));
       }
    }
}
