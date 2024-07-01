using System.ComponentModel.DataAnnotations;

namespace work_with_multiple_table.Models
{
    public class Department
    {
        [Key]
        public int DepartmentId { get; set; }
        [Required]
        public string deptname { get; set; }
        [Required]

        public string deptcode { get; set; }
        public string location { get; set; }


    }
}
