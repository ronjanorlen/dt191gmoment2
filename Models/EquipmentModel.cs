using System.ComponentModel.DataAnnotations; // Stöd för DataAnnotations

namespace dt191gmoment2.Models;

// Utrustningsmodell 
public class EquipmentModel
{
    // Properties

    // Namn
    [Required(ErrorMessage = "Ange ditt namn")] // DataAnnotation - kräver att fält fylls i 
    [Display(Name = "Ditt namn")] // label 
    public string? FirstName { get; set; } 

    // Skida eller snowboard 
    [Required(ErrorMessage = "Ange skid-/snowboardmodell")] // DataAnnotation - kräver att fält fylls i 
    [Display(Name = "Utrustning")] // label 
    public string? SkiSnowboard { get; set; } 

    // Längd på utrustning
    [Required(ErrorMessage = "Ange längd på utrustningen")] // DataAnnotation - kräver att fält fylls i 
    [Display(Name = "Längd")] // label 
    [MaxLength(3)] // max 3 tecken 
    public int? EquipLength { get; set; } 

    // Bindning 
    [Required(ErrorMessage = "Ange vilken bindning du använder")] // DataAnnotation - kräver att fält fylls i 
    [Display(Name = "Bindning")] // label 
    public string? Binding { get; set; } 
}