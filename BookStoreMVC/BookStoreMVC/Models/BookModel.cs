using BookStoreMVC.Data;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreMVC.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required (ErrorMessage ="Please enter the title of your book")]
        public string Title { get; set; }

        [Required (ErrorMessage ="Please enter the author name")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        [Required (ErrorMessage ="Select a language of your book")]
        public int LanguageId { get; set; }
        public string Language { get; set; }

        [Required (ErrorMessage ="Please enter the total pages")]
        [Display (Name ="Total pages of book")]
        public int? TotalPages { get; set; }

        [Display(Name ="Choose the cover photo of your book")]
        [Required]
        public IFormFile CoverPhoto { get; set; }
        public string CoverImageUrl { get; set; }


    }
}
