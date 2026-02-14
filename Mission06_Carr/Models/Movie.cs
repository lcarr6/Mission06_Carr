using System.ComponentModel.DataAnnotations;

namespace Mission06_Carr.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }
        
        [Required] public string Category { get; set; }

        [Required] public string Title { get; set; }

        [Required] public int Year { get; set; }

        [Required] public string Director { get; set; }

        [Required] public string Rating { get; set; }

        // Not required
        public bool? Edited { get; set; }

        // Not required
        public string? LentTo { get; set; }

        // Not required, max 25 characters
        [StringLength(25)] public string? Notes { get; set; }
    }
}    