namespace LibraryManagement.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public string Avatar { get; set; }
        public ICollection<Book> Books { get; set; } = new List<Book>();

    }
}
