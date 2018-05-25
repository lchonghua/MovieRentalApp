using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MovieRentalApp.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [ForeignKey("GenreId")]       
        public Genre Genre { get; set; }

        [Display(Name = "Released Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Date Added")]
        public DateTime DateAdded { get; set; }

        [Display(Name = "Number In Stock")]
        [Range(1,50)]
        public int NumberInStock { get; set; }

        [Required(ErrorMessage = "The Genre field is required")]
        public int GenreId { get; set; }
    }
}