using System.ComponentModel.DataAnnotations; // Stöd för DataAnnotations

namespace dt191gmoment2.Models;

// Utrustningsmodell 
public class EquipmentModel
{
    // Properties

    // Namn
    [Required(ErrorMessage = "Ange vem som åker på utrustningen")] // DataAnnotation - kräver att fält fylls i 
    [Display(Name = "Åkare")] // label 
    public string? FirstName { get; set; }

    // Skida eller snowboard 
    [Required(ErrorMessage = "Ange skid-/snowboardmodell")] // DataAnnotation - kräver att fält fylls i 
    [Display(Name = "Utrustning")] // label 
    public string? SkiSnowboard { get; set; }

    // Längd på utrustning
    [Required(ErrorMessage = "Ange längd på utrustning")] // DataAnnotation - kräver att fält fylls i 
    [Display(Name = "Längd")] // label 
    [Range(1, 999, ErrorMessage = "Längd på utrustning måste vara mellan 1 och 999cm")]
    public int? EquipLength { get; set; } = 0; // Standardvärde

    // Bindning 
    [Required(ErrorMessage = "Ange vilken bindning du använder")] // DataAnnotation - kräver att fält fylls i 
    [Display(Name = "Bindning")] // label 
    public string? Binding { get; set; }
}