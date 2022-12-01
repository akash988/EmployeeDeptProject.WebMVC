using EmployeeDeptProject.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDeptProject.DataAccess.Repository.IRepository
{
    public interface IDepartmentRepository:IRepository<Department>
    {
        void Update(Department dept); 
    }
}
