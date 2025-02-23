
using Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Data.Entities

{

    public class StatusTypesEntity
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string StatusName { get; set; } = null!;

        [JsonIgnore]
        public ICollection<ProjectEntity> Projects { get; set; } = [];

    }
}
