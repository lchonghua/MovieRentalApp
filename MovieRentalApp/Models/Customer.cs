using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MovieRentalApp.Models
{
    public class Customer
    {
        public int Id { get; set; }//Every entity need to have a PK, by convention, we name it Id (or CustomerId) - this will be recognized by EF.

        [Required(ErrorMessage ="Please enter customer's name.")]//how to overwrite default error msg
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Subscribe to Newsletter")]
        public bool IsSubscribedToNewsletter { get; set; }

        [ForeignKey("MembershipTypeId")]
        public MembershipType MembershipType { get; set; } //this is a navigation property which allow us to nav from one model to another

        [Display(Name = "Membership Type")]
        public int MembershipTypeId { get; set; }//name this property by convention, so that EF would recognize it and treat it as a foreign key to MembershipType table

        //[Min18YearsIfAMember] //customized validation: if the customer select something other than Pay As You Go, then this customer must be > 18yrs
        [Display(Name = "Date of Birth")]
        public DateTime? Birthday { get; set; } = null;
        
    }
}