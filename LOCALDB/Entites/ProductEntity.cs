
using System.ComponentModel.DataAnnotations;

namespace Data.Entites
{
    internal class ProductEntity
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]

        public string Description { get; set; }

        [Required]

        public DateTime? DateTime { get; set; }


    }
}
