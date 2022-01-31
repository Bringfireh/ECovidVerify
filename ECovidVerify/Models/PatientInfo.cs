namespace ECovidVerify.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PatientInfo")]
    public partial class PatientInfo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PatientInfo()
        {
            Answer = new HashSet<Answer>();
            VaccineInfo = new HashSet<VaccineInfo>();
        }

        public string Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [StringLength(128)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [StringLength(128)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Middle Name")]
        [StringLength(128)]
        public string MiddleName { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [Display(Name = "Gender")]
        [StringLength(128)]
        public string Gender { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [StringLength(128)]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        [StringLength(128)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [StringLength(128)]
        public string City { get; set; }

        [StringLength(128)]
        public string Zip { get; set; }

        [StringLength(128)]
        public string Race { get; set; }

        [StringLength(128)]
        public string Ethnicity { get; set; }

        public bool? HealthInsurance { get; set; }

        [StringLength(128)]
        public string CHName { get; set; }

        public DateTime? CHDateOfBirth { get; set; }

        [StringLength(128)]
        public string CHEmployer { get; set; }

        [StringLength(128)]
        public string InsuranceCompany { get; set; }

        [StringLength(128)]
        public string MemberID { get; set; }

        [StringLength(128)]
        public string GroupNo { get; set; }

        [StringLength(128)]
        public string NameOfInsured { get; set; }

        [StringLength(128)]
        public string RelationshipToInsured { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Answer> Answer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VaccineInfo> VaccineInfo { get; set; }
    }
}
