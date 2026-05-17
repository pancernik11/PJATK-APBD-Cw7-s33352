using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PcManager.Models;

[Table("Components")]
public class Component
{
    [Key]
    [MaxLength(10)]
    [Column(TypeName = "char(10)")]
    public string Code { get; set; } = null!;

    [Required]
    [MaxLength(300)]
    public string Name { get; set; } = null!;

    [Column(TypeName = "nvarchar(max)")]
    public string? Description { get; set; }

    public int ComponentManufacturersId { get; set; }

    [ForeignKey(nameof(ComponentManufacturersId))]
    public ComponentManufacturer Manufacturer { get; set; } = null!;

    public int ComponentTypesId { get; set; }

    [ForeignKey(nameof(ComponentTypesId))]
    public ComponentType Type { get; set; } = null!;

    public ICollection<PCComponent> PCComponents { get; set; } = new List<PCComponent>();
}
