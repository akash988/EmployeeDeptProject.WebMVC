using EmployeeDeptProject.DataAccess.Data;
using EmployeeDeptProject.Models.Models;
using EmployeeDeptProject.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace EmployeeDeptProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public IActionResult Index()
        {
           //ogin loginModel = new Login();
            return View();    
            
        }
        //[HttpPost]
        //public IActionResult Index(Login loginModel)
        //{

        //    EmployeeDBContext employeeContext = new EmployeeDBContext();

        //    var status = employeeContext.Logins.Where(m => m.UserName == loginModel.UserName && m.Password == loginModel.Password).FirstOrDefault();

        //    if (status == null)

        //    {

        //        ViewBag.LoginStatus = 0;

        //    }

        //    else

        //    {

        //        return RedirectToAction("Home");

        //    }

        //    return View(loginModel);

        //}




        public IActionResult Privacy()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}