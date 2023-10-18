namespace DalChatApplication.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AddFriend")]
    public partial class AddFriend
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string User1 { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string User2 { get; set; }

        public bool? FriendRequestFlag { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateTime { get; set; }

        public virtual Login Login { get; set; }

        public virtual Login Login1 { get; set; }
    }
}
