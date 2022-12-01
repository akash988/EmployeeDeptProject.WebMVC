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
    public class DepartmentRepository:Repository<Department>,IDepartmentRepository
    {
        private readonly EmployeeDBContext _db;
        public DepartmentRepository(EmployeeDBContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Department dept)
        {
            _db.Update(dept);
        }
    }
}
