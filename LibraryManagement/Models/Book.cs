using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [Required]
        //[MaxLength(200)]
        [StringLength(200, ErrorMessage ="Can not be longer than 200 characters")]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string BookCode { get; set; }

        public string Publisher { get; set; }

        public DateTime PublishedYear { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public int TotalCopies { get; set; }

        public int AvailableCopies { get; set; }

        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }

        public string Avatar { get; set; }

        public string Pdf { get; set; }

        public Category? Category { get; set; }
        public Author? Author { get; set; }

        public ICollection<Loan> Loans { get; set; } = new List<Loan>();


    }
}
