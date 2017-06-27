using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class HammyWishList : BaseEntity
    {
        [Key]
        public int HammyWishListId { get; set; }
        [ForeignKey("HamsterId")]
        public string HamsterId { get; set; }
        public Hamster Hamster { get; set; }
        [ForeignKey("GoodieId")]
        public int GoodieId { get; set; }
        public Goodie Goodie { get; set; }
        public DateTime HammyWishListCreated_At { get; set; }
        public DateTime HammyWishListUpdated_At { get; set; }
    }
}