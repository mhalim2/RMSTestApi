using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMSTestApi.Models
{
    [Table("Referral")]
    public partial class Provider
    {
        public int ProviderId { get; set; }
        public string?IndetifierNo{ get; set; }
        public int specialtyId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string? City { get; set; }
        public string? Province { get; set; }
        public bool IstakingNewPatient { get; set; }
        public DateAndTime? LastestAvailablityDate { get; set; }
        public string? ModifiedBy {get; set;}
        public DateTime ModifiedDate { get; set; }


    }
}
