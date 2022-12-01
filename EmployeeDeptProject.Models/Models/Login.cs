using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDeptProject.Models.Models
{
    public class Login
    {
        [Key]
        public int Id { get; set; } 
        [Required]
        [DisplayName("Enter UserName")]
        public string UserName { get; set; }
        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 12)]
        [DataType(DataType.Password)]
        [DisplayName(" Enter Your Password")]
        public string Password { get; set; }
    }
}
