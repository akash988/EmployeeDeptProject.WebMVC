using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDeptProject.Web.Models
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        [DisplayName("Enter the Employee Name")]
        [StringLength(20,ErrorMessage ="Length should be 20 character only")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Please Enter the valid Employee name")]
        [Required]
        public string EmpName { get; set; }
        [DisplayName("Enter the Employee Salary")]
        [Range(1.1, float.MaxValue, ErrorMessage = "The Salary {0} must be greater than {1}.")]
        [Required]
        public int EmpSalary { get; set; }
        [DisplayName("Select Department Name")]
        [Required]
        public int DeptId { get; set; }
        [ForeignKey("DeptId")]
        public Department Departments { get; set; }
        
    }
}
