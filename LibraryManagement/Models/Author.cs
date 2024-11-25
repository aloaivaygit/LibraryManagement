using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Author
    {
        public int AuthorId { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]

        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        [MaxLength(100)]
        public string Biography { get; set; }

        [MaxLength(100)]
        public string Nationality { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [MaxLength(100)]
        public string Website { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public string Avatar { get; set; }

        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
