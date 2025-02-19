
using Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entites
{
    public class ProjectEntity
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string ProjectName { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]

        public string StartDate { get; set; } = null!;

        public string EndDate { get; set; } = null!;

        [Required]
        public string StatusId { get; set; } = null!;



        public UserEntity User { get; set; } = null!;


    }
}
