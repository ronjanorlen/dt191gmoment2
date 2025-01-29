using System.ComponentModel.DataAnnotations; // Stöd för DataAnnotations

namespace dt191gmoment2.Models;

// Utrustningsmodell 
public class EquipmentModel
{
    // Properties

    // Namn
    [Required]
    public required string FirstName { get; set; } 

    // Skida eller snowboard 
    [Required]
    public required string SkiSnowboard { get; set; } 

    // Längd på utrustning
    [Required]
    public required int EquipLength { get; set; } 

    // Bindning 
    [Required]
    public required string Binding { get; set; } 
}