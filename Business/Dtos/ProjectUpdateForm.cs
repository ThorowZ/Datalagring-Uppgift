
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Business.Dtos;

public class ProjectUpdateForm
{
    [Required]
    public int Id { get; set; }

    [Required]
    public string ProjectName { get; set; } = null!;

    [Required]
    public string Description { get; set; } = null!;


    [Column(TypeName = "date")]
    public DateTime StartDate { get; set; }

    [Column(TypeName = "date")]
    public DateTime? EndDate { get; set; }

    [Required]
    public string StatusName { get; set; } = null!;

    public string UserFirstName { get; set; } = null!;

    public string UserLastName { get; set; } = null!;

    public int UserId { get; set; }

}
