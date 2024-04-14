using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography.X509Certificates;

namespace VacationRegister.Models
{
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You have to enter a name")]
        [StringLength(30)]
        public required string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You have to enter a name")]
        [StringLength(40)]
        public required string LastName { get; set; }
        [Display(Name = "Date of birth")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [ForeignKey("Department")]
        [Display(Name = "Department")]
        [Required]
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public virtual ICollection<Leave>? Leaves { get; set; }
        [NotMapped]
        
        public string Fullname
        {
            get { return FirstName + " " + LastName; }
        }
    }
}
