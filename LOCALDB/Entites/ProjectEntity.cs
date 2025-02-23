
using Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Data.Entities

{
    public class ProjectEntity
    {

        [Key]
        public int Id { get; set; }



        [Required]
        [Column(TypeName = "nvarchar(150)")]
        public string ProjectName { get; set; } = null!;

        [Required]
        public string Description { get; set; } = null!;

        [Required]

        [Column(TypeName = "date")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime? EndDate { get; set; }

        
        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserEntity User { get; set; } = null!;


        
        [ForeignKey("Status")]
        public int StatusId { get; set; }
        public StatusTypesEntity Status { get; set; } = null!;


    }
}
