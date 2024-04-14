using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VacationRegister.Models
{
    public class LeaveType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveTypeId { get; set; }
        [Display(Name = "Type of Leave")]
        [StringLength(40)]
        public string TypeofLeave { get; set; }
        [Display(Name = "Leave Description")]
        [StringLength(100)]
        public string LeaveDescr { get; set; }
        public virtual ICollection<Leave>? Leaves { get; set; }
    }
}
