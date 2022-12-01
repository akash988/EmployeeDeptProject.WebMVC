using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EmployeeDeptProject.Web.Models
{
    public class Department
    {
        [Key]
        public int DeptId { get; set; }
        [DisplayName("Enter DepartmentName")]
        
        [StringLength(20, ErrorMessage = "Length should be 20 character only")]
        [RegularExpression(@"^[a-zA-Z]+[ a-zA-Z-_]*$", ErrorMessage = "Please Enter the valid Department Name")]
        [Required]
        public string DeptName { get; set; }

    }
}
