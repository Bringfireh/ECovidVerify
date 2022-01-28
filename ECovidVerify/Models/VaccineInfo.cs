namespace ECovidVerify.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VaccineInfo")]
    public partial class VaccineInfo
    {
        public string Id { get; set; }

        [StringLength(128)]
        public string PatientInfoId { get; set; }

        public DateTime? DateOfVaccination { get; set; }

        [StringLength(128)]
        public string VaccineType { get; set; }

        [StringLength(128)]
        public string Jab { get; set; }

        public virtual PatientInfo PatientInfo { get; set; }
    }
}
