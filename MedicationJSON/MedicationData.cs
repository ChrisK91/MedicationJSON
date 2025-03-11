using System.ComponentModel.DataAnnotations;
using MedicationJSON.Helpers;

namespace MedicationJSON.Models;

/// <summary>
/// Information for a single medication entry  
/// </summary>
public class MedicationData
{
    /// <summary>
    /// The Medications name. The name should be in english and might be used to match other entries.
    /// </summary>
    [Required]
    public required string Name { get; set; }

    /// <summary>
    /// Aliases or other names for the same medication. For localized aliases, see <seealso cref="LocalizedAliases"/>
    /// These might also be brand names.
    /// </summary>
    public List<String>? Aliases { get; set; }

    /// <summary>
    /// Categories of the current medication might be used to group medications on a display control, to color them differently or to filter them.
    /// </summary>
    public List<String>? Categories { get; set; }

    /// <summary>
    /// Localized Names of the current substance. Might contain multiple names for the same substance.
    /// These might also be brand names.
    /// </summary>
    public List<LocalizedString>? LocalizedAliases { get; set; }

    /// <summary>
    /// An optional description or comment regarding this entry
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Localized descriptions for the medication
    /// </summary>
    public List<LocalizedString>? LocalizedDescriptions { get; set; }

    /// <summary>
    /// The mediaction contained in this dataset
    /// </summary>
    [Required]
    public required List<MedicationPreparation> Preparations { get; set; }

    // TODO: Group localizations?
}

/// <summary>
/// Information about how a certain medication is prepared. This is targeted towards i.v. mixtures currently.
/// </summary>
public class MedicationPreparation
{
    /// <summary>
    /// The total volume of the preparation
    /// </summary>
    [Required]
    public required UnitNumber Volume { get; set; }

    /// <summary>
    /// The total amount of active ingredient of the preparation
    /// </summary>
    [Required]
    public required UnitNumber Dose { get; set; }
}