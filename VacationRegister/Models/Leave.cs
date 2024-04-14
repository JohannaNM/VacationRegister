using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace VacationRegister.Models
{
    public class Leave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveId { get; set; }
        
        [Required(ErrorMessage = "You have to enter a start date")]
        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }
        
        [Required(ErrorMessage = "You have to enter a end date")]
        [DataType(DataType.Date)]
        [Display(Name = "End date")]
        public DateTime EndDate { get; set; }
        
        [Display(Name = "Days")]
        public double? DiffInDays 
        { 
            get { return (EndDate - StartDate).TotalDays; }
        }

        [Display(Name = "Notes")]
        [StringLength(120)]
        public string? LeaveNotes { get; set; }
        
        private DateTime _Created = DateTime.Now;
        [Display(Name = "Created")]
        public DateTime CreateDate { get { return _Created; } set { _Created = value; } }
        
        [ForeignKey("LeaveType")]
        [Display(Name = "Type of leave")]
        [Required(ErrorMessage = "You have to select type of leave")]
        public int FkLeaveTypeId { get; set; }
        public LeaveType? LeaveType { get; set; }
       
        [ForeignKey("Employee")]
        [Display(Name = "Employee")]
        [Required(ErrorMessage = "You have to choose a Employee")]
        public int FkEmpId { get; set; }
        public Employee? Employee { get; set; }

        
    }
}
