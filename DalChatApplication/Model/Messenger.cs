namespace DalChatApplication.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Messenger")]
    public partial class Messenger
    {
        [Key]
        public int idMessenger { get; set; }

        [Required]
        [StringLength(50)]
        public string Username1 { get; set; }

        [Required]
        [StringLength(50)]
        public string Username2 { get; set; }

        [Column("Messenger")]
        [Required]
        public string Messenger1 { get; set; }

        public DateTime TimeMessenger { get; set; }

        public virtual Login Login { get; set; }

        public virtual Login Login1 { get; set; }
    }
}
