
using System.ComponentModel.DataAnnotations;

namespace DAL.Model
{
    public class Author
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string ImageName { get; set; }

        public string? Mail { get; set; }

        public string? TwitterUserName { get; set; }
    }
}
