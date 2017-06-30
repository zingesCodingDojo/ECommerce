using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class HamsterCreditCard : BaseEntity
    {
        [Key]
        public string HamsterCreditCardId { get; set; }
        public string CardNumber { get; set; }
        public DateTime CardExpired { get; set; }
        public string CardCVN { get; set; }
        public DateTime CardCreated_At { get; set; }
        public DateTime CardUpdated_At { get; set; }
        [ForeignKey("HamsterId")]
        public string HamsterId { get; set; }
        public Hamster Hamster { get; set; }

    }
}