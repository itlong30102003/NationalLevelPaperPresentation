namespace NationalLevelPaperPresentation.Models
{
    using NationalLevelPaperPresentation.Models;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Activity")]
    public partial class Activity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Activity()
        {
            Participant = new HashSet<Participant>();


        }

        [Key]
        public int activity_id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date { get; set; }

        public TimeSpan? time { get; set; }

        public double? fee { get; set; }

        [StringLength(100)]
        public string eligibility { get; set; }

        [Column(TypeName = "text")]
        public string prize_details { get; set; }

        [Column(TypeName = "text")]
        public string address { get; set; }

        [Column(TypeName = "text")]
        public string terms_and_conditions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Participant> Participant { get; set; }


    }
}
