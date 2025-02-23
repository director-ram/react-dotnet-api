using System.ComponentModel.DataAnnotations;

namespace MyProject.models;

public class Company
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public required string Address { get; set; }
}
