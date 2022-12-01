using EmployeeDeptProject.DataAccess.Data;
using EmployeeDeptProject.DataAccess.Repository.IRepository;
using EmployeeDeptProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDeptProject.DataAccess.Repository
{
    public class EmployeeRepository:Repository<Employee>,IEmployeeRepository
    {
        private readonly EmployeeDBContext _db;
        public EmployeeRepository(EmployeeDBContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Employee emp)
        {
            _db.Update(emp);
        }
    }
}
