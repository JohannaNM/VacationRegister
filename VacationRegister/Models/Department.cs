using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationRegister.Models
{
    public class Department
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DepartmentId { get; set; }
        [StringLength(40)]
        public string DepartmentName { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
