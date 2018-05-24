using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieRentalApp.Models;

namespace MovieRentalApp.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; } 
        //use IEnumerable instead of List, b/c we don't need any functionality provided by List class; IEnumerable is enough

        public Customer Customer { get; set; }
    }
}