using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Models
{
    public class MembershipType
    {
        public int Id { get; set; } //name by convention, and by default, this will be treated as primary key

        [Required]
        public string Name { get; set; }

        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }

        //define two specific membership types that we use in our application to avoid use hard-coded 0 and 1.
        public static readonly int Unknown = 0;
        public static readonly int PayAsYouGo = 1;

    }
}