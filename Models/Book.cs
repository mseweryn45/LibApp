using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LibApp.Models
{
    public class Book
    {
        public int Id { get; set; }
		[Required]
		[StringLength(255)]
		public string Name { get; set; }
		[Required]
		public string AuthorName { get; set; }
		[Required]
		public Genre Genre { get; set; }
		[Required]
		[Display(Name="Genre")]
		public byte GenreId { get; set; }
		public DateTime DateAdded { get; set; }
		[Required(ErrorMessage = "ReleaseDate is required.")]
		[Display(Name="Release Date")]
		public DateTime ReleaseDate { get; set; }
		[Required]
		[Range(1,20,ErrorMessage ="NumberInStock must be between 1 and 20.")]
		[Display(Name = "Number in Stock")]
		public int NumberInStock { get; set; }
		[Required]
		public int NumberAvailable { get; set; }
	}
      
}
