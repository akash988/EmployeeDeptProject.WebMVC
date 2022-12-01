using EmployeeDeptProject.DataAccess.Data;
using EmployeeDeptProject.DataAccess.Repository.IRepository;
//using EmployeeDeptProject.Web.Data;
using EmployeeDeptProject.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeDeptProject.Web.Controllers
{
    public class DepartmentController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;
        public DepartmentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IActionResult DeptIndex()
        {
            var allcategories = _unitOfWork.Department.GetAll();


            //TempData["Lname"] = "Akash";
            //TempData["Fname"] = "Gawas";
            //ViewBag.MyName = "Hello";
            return View(allcategories);
        }

        public IActionResult DeptDetails(int? id)
        {
            var category = _unitOfWork.Department.GetFirstOrDefault(c=>c.DeptId==id);
            return View(category);
        }
        //get post
        public IActionResult DeptCreate()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeptCreate(Department catobj)
        {

            //if (catobj.CategoryName == catobj.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("custom error", "Display order cannot match the category name");
            //}
            if (ModelState.IsValid)
            {
                _unitOfWork.Department.Add(catobj);
                _unitOfWork.Save();
                TempData["Success"] = "Sucessfully Inserted the data";
                return RedirectToAction(nameof(DeptIndex));
            }
            else
            {
                return View();
            }
        }
        public IActionResult DeptEdit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDB = _unitOfWork.Department.GetFirstOrDefault(c=>c.DeptId==id);
            if (categoryFromDB == null)
            {
                return NotFound();
            }
            return View(categoryFromDB);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeptEdit(Department catobj)
        {


            _unitOfWork.Department.Update(catobj);
            _unitOfWork.Save();
            TempData["Success"] = "Sucessfully Update the data";
            return RedirectToAction(nameof(DeptIndex));

        }

        public IActionResult DeptDelete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var categoryFromDB = _unitOfWork.Department.GetFirstOrDefault(c=>c.DeptId==id);
            if (categoryFromDB == null)
            {
                return NotFound();
            }
            return View(categoryFromDB);
        }
        [HttpPost]
        [ActionName("DeptDelete")]
        public IActionResult DeptDeletePost(int? id)
        {
            var obj = _unitOfWork.Department.GetFirstOrDefault(c=>c.DeptId==id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Department.Remove(obj);
            _unitOfWork.Save();
            TempData["Success"] = "Sucessfully Deleted the data";
            return RedirectToAction(nameof(DeptIndex));
        }
    }
}
