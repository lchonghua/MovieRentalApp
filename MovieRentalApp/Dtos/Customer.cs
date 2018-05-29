using MovieRentalApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Dtos
{
    public class Customer
    {
        // copy the properties from Customer model
        // modify the properties: they should be either primitive types or custom DTOs
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribedToNewsletter { get; set; }

        
        //public MembershipType MembershipType { get; set; }  exclude MembershipType, b/c this is a domain class, so it creates a dependency of this DTO to a domain model

        public int MembershipTypeId { get; set; }

        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; } = null;
    }
}