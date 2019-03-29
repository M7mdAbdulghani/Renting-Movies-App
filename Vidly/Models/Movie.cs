using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        public String Name { get; set; }
        [Required]
        [Display(Name = "Number in Stock")]
        [Range(1, 20, ErrorMessage = "The field Number in Stock must be between 1 and 20")]
        [Min10IfActionGenre]
        public int ? NumberInStock { get; set; }
        [Required]
        [Display(Name = "Release Date")]
        public DateTime ? ReleasedDate { get; set; }
        public DateTime ? DateAdded { get; set; }
        public Genre Genre { get; set; }
        [Display(Name = "Genre")]
        public int GenreId { get; set; }
    }
}