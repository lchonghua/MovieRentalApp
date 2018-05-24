using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Models
{
    public class MembershipType
    {
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public int Id { get; set; } //name by convention, and by default, this will be treated as primary key
        public string Name { get; set; }
    }
}