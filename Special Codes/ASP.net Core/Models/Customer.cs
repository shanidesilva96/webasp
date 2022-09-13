using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketProA.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Cart = new HashSet<Cart>();
        }

        [Key]
        [Column("CustomerID")]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [InverseProperty("Customer")]
        public virtual ICollection<Cart> Cart { get; set; }
    }
}
