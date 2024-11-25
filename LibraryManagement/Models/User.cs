using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [MaxLength(200)]
        [Required]
        public string Fullname { get; set; }

        public string Description { get; set; }

        [Required]
        public string Password { get; set; }

 
        [MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; }

        public string Address { get; set; }

        public int Status { get; set; }

        public DateTime CreatedDate { get; set; }

        public string UserCode { get; set; }

        public bool IsLocked { get; set; }

        public bool IsDeleted { get; set; }

        public bool IsActive { get; set; }

        public string ActiveCode { get; set; }

        public string Avatar { get; set; }
        public ICollection<Loan> Loans { get; set; }

    }

}
