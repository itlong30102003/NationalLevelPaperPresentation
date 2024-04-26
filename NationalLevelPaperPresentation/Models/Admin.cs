namespace NationalLevelPaperPresentation.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Admin")]
    public partial class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [Column(Order = 1)]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required]
        [Column(Order = 2)]
        [StringLength(255)]
        public string Password { get; set; }
    }
}
