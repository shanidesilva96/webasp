using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketProA.Models
{
    public partial class Cart
    {
        [Key]
        [Column("CartID")]
        public int CartId { get; set; }
        public int ReferenceNo { get; set; }
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Column("ItemID")]
        public int ItemId { get; set; }
        [Column("QTY")]
        public int Qty { get; set; }

        [ForeignKey(nameof(CustomerId))]
        [InverseProperty("Cart")]
        public virtual Customer Customer { get; set; }
        [ForeignKey(nameof(ItemId))]
        [InverseProperty(nameof(Items.Cart))]
        public virtual Items Item { get; set; }
    }
}
