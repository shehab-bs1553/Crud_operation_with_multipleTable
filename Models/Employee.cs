using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace work_with_multiple_table.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required]
        public string name { get; set; } = default!;
        [Required]
        public int age { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
       // public string dateofbirth { get; set; }
        public DateTime DateofBirth { get; set; }

        public string deptname { get; set; } 

        public int DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        
        public Department Department { get; set; }

    }
}
