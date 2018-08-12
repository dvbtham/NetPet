using System.ComponentModel.DataAnnotations;

namespace PetNet.Web.Models
{
    public class ReviewViewModel
    {
        public int Id { get; set; }

        public long ProductId { get; set; }

        [MaxLength(256)]
        public string CustomerId { get; set; }
        
        public int Rating { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}