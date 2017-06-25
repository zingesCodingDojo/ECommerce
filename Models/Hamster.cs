using System;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public abstract class BaseEntity{}
    public class Hamster : BaseEntity
    {
        [Key]
        public int HamsterId { get; set; }
        public int HamsterSecurity { get; set; }
        public string HamsterFirstName { get; set; }
        public string HamsterLastName { get; set; }
        public string HamsterLoginName { get; set; }
        public string HamsterPassword { get; set; }
        public string HamsterAddress { get; set; }
        public int HamsterPhoneNumber { get; set; }
        public int HamsterCredits { get; set; }
        public DateTime HamsterCreated_At { get; set; }
        public DateTime HamsterUpdated_At { get; set; }
    }
}