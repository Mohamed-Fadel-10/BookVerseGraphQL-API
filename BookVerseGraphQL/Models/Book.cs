using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BookVerseGraphQL.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public Author Author { get; set; } = null!;
    }
}
