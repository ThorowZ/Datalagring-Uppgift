using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace Data.Entities

{

    [Index(nameof(Email), IsUnique = true)]
    public class UserEntity
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = null!;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = null!;

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Email { get; set; } = null!;

        [Column(TypeName = "varchar(15)")]
        public string? PhoneNumber { get; set; }

        public ICollection<ProjectEntity> Project { get; set; } = new List<ProjectEntity>();
    }
}