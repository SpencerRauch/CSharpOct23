#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;

namespace PetParty.Models;

public class Pet
{
    // public string? Name { get;set; } //the ? lets this string hold a null
    [Required]
    [MinLength(2, ErrorMessage = "Name should be at least two characters")]
    public string Name { get; set; }

    [Display(Name = "Type of pet:")]
    [Required]
    // [DataType(DataType.Password)]
    public string Species { get; set; }

    [Required]
    [Range(1,int.MaxValue)]
    public int? Age { get; set; }

    public bool IsAdorable { get; set; }

}