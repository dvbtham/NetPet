using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PetNet.Model.Models
{
    [Table("Reviews")]
    public class Review
    {
        public int Id { get; set; }

        public long ProductId { get; set; }

        public Product Product { get; set; }

        [MaxLength(256)]
        public string CustomerId { get; set; }

        public ApplicationUser Customer { get; set; }

        public int Rating { get; set; }

        [MaxLength(500)]
        public string Content { get; set; }

        public bool IsDeleted { get; set; }
    }
}
