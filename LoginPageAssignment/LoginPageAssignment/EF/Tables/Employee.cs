using System.ComponentModel.DataAnnotations;

namespace LoginPageAssignment.EF.Tables
{
    public class Employee
    {
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string EmpEmail { get; set; }
        public string EmpPassword { get; set; }

    }
}
