using System;
using System.ComponentModel.DataAnnotations;


namespace MovieRentalApp.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }
                
        public DateTime DateAdded { get; set; }

        [Range(1, 50)]
        public int NumberInStock { get; set; }

        [Required(ErrorMessage = "The Genre field is required")]
        public int GenreId { get; set; }

        public GenreDto Genre { get; set; }
    }
}