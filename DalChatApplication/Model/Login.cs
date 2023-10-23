namespace DalChatApplication.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Login")]
    public partial class Login
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Login()
        {
            AddFriend = new HashSet<AddFriend>();
            AddFriend1 = new HashSet<AddFriend>();
            Messenger = new HashSet<Messenger>();
            Messenger1 = new HashSet<Messenger>();
            ReportUser = new HashSet<ReportUser>();
            ReportUser1 = new HashSet<ReportUser>();
        }

        [Key]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string ConfirmPass { get; set; }

        [Required]
        public string image { get; set; }

        [Required]
        public string Email { get; set; }

        public int? IDPermission { get; set; }

        public bool? UserStatus { get; set; }

        public string BackgroundImage { get; set; }

        public string UserDescription { get; set; }

        [StringLength(15)]
        public string Gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateofBirth { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddFriend> AddFriend { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddFriend> AddFriend1 { get; set; }

        public virtual Permission Permission { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Messenger> Messenger { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Messenger> Messenger1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportUser> ReportUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReportUser> ReportUser1 { get; set; }
    }
}
