
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RMSTestApi.Models
{

    [Table("Patient")]
    public partial class Patient
    {
        public int patientId {  get; set; }
        public string? Hsn { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Dob { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? province { get; set; }
        public string? modifiedby { get; set; }
        public DateTime ? ModifiedDate { get; set; }

    }
}
