namespace ECovidVerify.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Answer")]
    public partial class Answer
    {
        public string Id { get; set; }

        [StringLength(128)]
        public string QuestionId { get; set; }

        [StringLength(128)]
        public string PatientInfoId { get; set; }

        public virtual PatientInfo PatientInfo { get; set; }

        public virtual Question Question { get; set; }
    }
}
