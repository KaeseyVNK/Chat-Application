namespace DalChatApplication.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ReportUser")]
    public partial class ReportUser
    {
        [Key]
        public int ReportID { get; set; }

        [Column("ReportUser")]
        [Required]
        [StringLength(50)]
        public string ReportUser1 { get; set; }

        [Required]
        [StringLength(50)]
        public string ReportedUser { get; set; }

        public int ReportReasonID { get; set; }

        public string Note { get; set; }

        public virtual Login Login { get; set; }

        public virtual Login Login1 { get; set; }

        public virtual Reason Reason { get; set; }
    }
}
