using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
        public DayOfWeek PickupDay { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TempStart { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TempEnd { get; set; }
        [DataType(DataType.Date)]
        public DateTime? OneTimePickup { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
        [ForeignKey("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
    }
}
