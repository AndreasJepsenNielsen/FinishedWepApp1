
using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        [Display(Name = "Navn")]
        public string Name { get; set; }
        

        
        public Genre Genre { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Display(Name = "Dato Tilføjet")]
        public DateTime DateAdded { get; set; }
        [Display(Name = "Udgivelses Dato")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Antal på lager")]
        [Range(1,20)]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }   
    }
}