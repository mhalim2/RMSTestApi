using System.ComponentModel.DataAnnotations.Schema;

namespace RMSTestApi.Models
{
    [Table("Speciality")]    
    public partial class Specialty
    {
        public int specialtyID { get; set; }        
        public string? specialtyName { get; set; }
        public string? modifiedby { get; set; }
        public DateTime? modifiedDate { get; set; }

    }
}
