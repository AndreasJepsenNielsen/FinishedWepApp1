using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Navn")]
        public string Name { get; set; }    

        [Display(Name = "Genre")]
        [Required]
        public byte? GenreId { get; set; }  

        [Display(Name = "Udgivelses Dato")]
        [Required]
        public DateTime? ReleaseDate { get; set; }  
        
        [Display(Name = "Antal på lager")]
        [Range(1,20,ErrorMessage = "Feltet Antal på lager skal være et nummer")]
        [Required]
        public byte? NumberInStock { get; set; }    

        public byte NumberAvailable { get; set; }

        public string Title
        {
            get
            {
                 //Hvis filmen eksisterer returnerer den Edit movie, hvis den ikke eksisterer returnerer den New Movie, den tjekker om Movie er != null og om movie.id ikke er = 0 
                // bruges til at kunne se forskel på om man skal edit eller lave en film, egentlig selve koden for at edit/new er den samme i movieform

                return Id != 0 ? "Rediger Film" : "Ny Film";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0;
        }

        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId;
            NumberAvailable = movie.NumberInStock;
        }
    }
}