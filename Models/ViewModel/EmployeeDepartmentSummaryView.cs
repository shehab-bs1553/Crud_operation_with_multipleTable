using System.ComponentModel.DataAnnotations;

namespace work_with_multiple_table.Models.ViewModel
{
    public class EmployeeDepartmentSummaryView
    {
        [Key]
        [Display(Name = "Employee Id :")]
        public int EmployeeId { get; set; }

        [Display(Name = "Deparment Id :")]
        [Range(1, 1000, ErrorMessage = "Please select department")]
        public int DepartmentId { get; set; }

        [Display(Name = "Name :")]
        [Required(ErrorMessage = "Please enter name")]
        public string name { get; set; } = default!;

        [Display(Name = "Age :")]
        [Required(ErrorMessage = "Please enter age")]
        public int age { get; set; } = default!;

        [Display(Name = "Date of Birth :")]
        [Required(ErrorMessage = "Please enter DateofBirth")]
        public DateTime DateofBirth { get; set; } = default!;


        [Required(ErrorMessage = "Please select generr")]
        public string? gender { get; set; }


        [Display(Name = "Department Name :")]
        public string deptname { get; set; } = default!;

        [Display(Name = "Department Code :")]
        public string deptcode { get; set; } = default!;
    }
}
