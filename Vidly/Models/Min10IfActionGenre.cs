using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min10IfActionGenre : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie) validationContext.ObjectInstance;

            if (movie.NumberInStock != 10 && movie.GenreId == 3)
                return new ValidationResult("If the Genre is action, number in srock must be 10");
            return ValidationResult.Success;
        }
    }
}