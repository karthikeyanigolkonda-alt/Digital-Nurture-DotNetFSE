using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementAPI.DTOs;

public class CreateEmployeeDto
{
    [Required]
    [StringLength(100)]
    public string? FirstName { get; set; }

    [Required]
    [StringLength(100)]
    public string? LastName { get; set; }

    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    [StringLength(100)]
    public string? Department { get; set; }
}
