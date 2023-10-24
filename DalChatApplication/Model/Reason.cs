namespace DalChatApplication.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Reason")]
    public partial class Reason
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Reason()
        {
            ReportUser = new HashSet<ReportUser>();
        }

        [Key]
        public int ReportReasonID { get; set; }

        [Required]
        [StringLength(50)]
        public string Reasons { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportUser> ReportUser { get; set; }
        public override string ToString()
        {
            return Reasons.ToString();
        }
    }
}
