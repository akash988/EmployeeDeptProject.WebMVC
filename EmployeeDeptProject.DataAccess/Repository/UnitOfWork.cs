using EmployeeDeptProject.DataAccess.Data;
using EmployeeDeptProject.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDeptProject.DataAccess.Repository
{
    public class UnitOfWork:IUnitOfWork
    {
        private EmployeeDBContext _db;
        public UnitOfWork(EmployeeDBContext db)
        {
            _db = db;
            Employee = new EmployeeRepository(db);
            Department = new DepartmentRepository(db);
        }
        //public UnitOfWork(EmployeeDBContext db)
        //{
        //    _db = db;
        //    Department = new DepartmentRepository(_db);
        //}
        public IEmployeeRepository Employee { get; private set; }
        public IDepartmentRepository Department { get; private set; }   

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
