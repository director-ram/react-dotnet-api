using System.ComponentModel.DataAnnotations;

namespace MyProject.models;

public class User
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Username { get; set; }

    [Required]
    public required string Name { get; set; }


    [Required]
    public required string PasswordHash { get; set; }  // Store hashed password


    public required string Role { get; set; } // "Admin" or "User"

}
