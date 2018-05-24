using System.Collections.Generic;
using MovieRentalApp.Models;

namespace MovieRentalApp.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}