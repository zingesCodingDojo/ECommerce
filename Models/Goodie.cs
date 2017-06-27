using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Goodie : BaseEntity
    {
        [Key]
        public int GoodieId { get; set; }
        public string GoodieName { get; set; }
        public string GoodieDescription { get; set; }
        public int GoodieQuantity { get; set; }
        public string GoodieImageURL { get; set; }
        public int GoodiePopularity { get; set; }
        public int GoodiePrice { get; set; }
        public DateTime GoodieCreated_At { get; set; }
        public DateTime GoodieUpdated_At { get; set; }
        public List<HammyWishList> HammyWishList { get; set; }
        public List<Comment> Comment { get; set; }
        public Goodie (){
            HammyWishList = new List<HammyWishList>();
            Comment = new List<Comment>();
        }
    }
}