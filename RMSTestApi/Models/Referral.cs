using System.ComponentModel.DataAnnotations.Schema;

namespace RMSTestApi.Models
{
    [Table("Referral")]
    public class Referral
    {

        public int ReferralID { get; set; }
        public int PatientID { get; set; }
        public int ProviderID { get; set; }
        public int SpecialtyID { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string? ModifiedBy { get; set; }

    }
}
