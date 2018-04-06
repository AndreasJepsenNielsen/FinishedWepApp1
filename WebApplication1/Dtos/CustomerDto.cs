using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Dtos
{
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        
        public string Name { get; set; }
       
        //[Min18YearsIfAMember]
        public DateTime? Birthdate { get; set; }


        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }   

       
        public byte MembershipTypeId { get; set; }

    }
}