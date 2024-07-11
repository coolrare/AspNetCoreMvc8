using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ModelBindingDemo.Models;

public class Student
{
    [Required]
    [BindRequired]
    public required string Name { get; set; }

    [BindRequired]
    [Range(0, 99)]
    public int Age { get; set; }

    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
}
