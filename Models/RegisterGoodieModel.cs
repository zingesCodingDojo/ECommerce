using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class RegisterGoodieModel : BaseEntity
    {
        [Required(ErrorMessage = "Please insert a Goodie Name!")]
        [MinLength(3)]
        public string GoodieName { get; set;}
        [Required(ErrorMessage = "Goodie Description needs to be longer than 10 characters!")]
        [MinLength(10)]
        public string GoodieDescription { get; set; }
        [Required(ErrorMessage = "An image location is required for Hamsters to view!")]
        public string GoodieImageURL { get; set; }
        [Required(ErrorMessage = "Please tell Hammy the individual prices for the product!")]
        public int GoodiePrice { get; set; }
        public int GoodieQuantity { get; set; }
    }
}