using System.ComponentModel.DataAnnotations;

namespace MedicationJSON.Helpers;

/// <summary>
/// Represents a number with an associated unit
/// </summary>
public class UnitNumber
{
    /// <summary>
    /// The value
    /// </summary>
    [Required]
    public required decimal Value { get; set; }

    /// <summary>
    /// The associated SI-unit
    /// </summary>
    [Required]
    public required string Unit { get; set; }
}

/// <summary>
/// Represents information about a localized string
/// </summary>
public class LocalizedString
{
    /// <summary>
    /// The culture of the current string, which should be resolvable according to https://www.rfc-editor.org/info/bcp47
    /// </summary>
    [Required]
    public required string Culture { get; set; }

    /// <summary>
    /// The content of the localized string
    /// </summary>
    [Required]
    public required string Value { get; set; }
}