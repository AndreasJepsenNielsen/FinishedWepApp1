using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Fulde Navn")]
        public string Name { get; set; }
        [Display(Name = "Fødselsdato")]
        [Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }    

      
        public bool IsSubscribedToNewsletter { get; set; }
        
        public MembershipType MembershipType { get; set; }

        [Display(Name = "Medlemsskabs Type")]
        public byte MembershipTypeId { get; set; }
    }
}