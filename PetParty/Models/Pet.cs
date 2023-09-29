#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

namespace PetParty.Models;

public class Pet
{
    // public string? Name { get;set; } //the ? lets this string hold a null
    [Required]
    [NoZNames]
    [MinLength(2, ErrorMessage = "Name should be at least two characters")]
    public string Name { get; set; }

    [Display(Name = "Type of pet:")]
    [Required]
    // [Options]
    [ProvidedOptions("Bear","Deer","Bobcat")]
    // [DataType(DataType.Password)]
    public string Species { get; set; }

    [Required]
    [Range(1,int.MaxValue)]
    public int? Age { get; set; }

    public bool IsAdorable { get; set; }

}

// Create a class that inherits from ValidationAttribute
public class NoZNamesAttribute : ValidationAttribute
{    
    // Call upon the protected IsValid method
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)    
    {   
        // We are expecting the value coming in to be a string
        // so we need to do a bit of type casting to our object
        // Strings work similarly to arrays under the hood 
        // so we can grab the first letter using its index   
        // If we discover that the first letter of our string is z...  
        if (value == null || ((string)value).ToLower()[0] == 'z')
        {        
            // we return an error message in ValidationResult we want to render    
            return new ValidationResult("No names that start with Z allowed!");   
        } else {   
            // Otherwise, we were successful and can report our success  
            return ValidationResult.Success;  
        }  
    }
}

public class OptionsAttribute : ValidationAttribute
{    
    // Call upon the protected IsValid method
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)    
    {   
        //if we got this from the db, this could be nice and dynamic
        string[] ValidOptions = new string[]{"Dog","Cat","Fish"};

        if (ValidOptions.Contains((string)value))
        {        
            return ValidationResult.Success;  
        } else {   
            return new ValidationResult("Please pick a valid option");   
        }  
    }
}

public class ProvidedOptionsAttribute : ValidationAttribute
{   
    public string[]? Options { get;set; }

    public ProvidedOptionsAttribute(params string[] options)
    {
        Options = options;
    }
    // Call upon the protected IsValid method
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)    
    {  
        if (Options.Contains((string)value))
        {        
            return ValidationResult.Success;  
        } else {   
            return new ValidationResult("Please pick a valid option");   
        }  
    }
}

