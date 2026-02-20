using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_Carr.Models
{
    // Represents a movie in Joel Hilton's collection
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        // Foreign key to the Categories table
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Year is required.")]
        [Range(1888, 9999, ErrorMessage = "Year must be 1888 or later (the year the first movie was made).")]
        public int Year { get; set; }

        // Director is optional
        public string? Director { get; set; }

        // Rating is optional
        public string? Rating { get; set; }

        [Required(ErrorMessage = "Please indicate if this movie has been edited.")]
        public bool Edited { get; set; }

        public string? LentTo { get; set; }

        [Required(ErrorMessage = "Please indicate if this movie has been copied to Plex.")]
        [Display(Name = "Copied To Plex")]
        public bool CopiedToPlex { get; set; }

        [StringLength(25)]
        public string? Notes { get; set; }
    }
}