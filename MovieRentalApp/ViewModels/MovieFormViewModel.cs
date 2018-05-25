using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MovieRentalApp.Models;

namespace MovieRentalApp.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }

        public MovieFormViewModel() //empty constructor for new movie
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie) //parameterized constructor for editing movie
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
        }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Released Date")]
        public DateTime? ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Genre")]
        public int? GenreId { get; set; }

        [Required]
        [Display(Name = "Number In Stock")]
        [Range(1, 50)]
        public int? NumberInStock { get; set; }

        /*
         * pure view model: in order to make the MovieForm page loaded without any pre-setting data 
         * in the field when creating new movie, we replace the Movie object in this class with 
         * specific properties from the Movie model, and make all the fields nullable. 
         */
    }
}