using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketProA.Models
{
    public partial class Items
    {
        public Items()
        {
            Cart = new HashSet<Cart>();
        }

        [Key]
        [Column("ItemID")]
        public int ItemId { get; set; }
        [Required]
        [StringLength(50)]
        public string ItemName { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? ItemPrice { get; set; }

        [InverseProperty("Item")]
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
