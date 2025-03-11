using System.ComponentModel.DataAnnotations;
using Semver;

namespace MedicationJSON.Models;

/// <summary>
/// Contains general information
/// </summary>
public class Information
{
    /// <summary>
    /// Points to the Source-Website of the current medication data
    /// </summary>
    public Uri? Website { get; set; }

    /// <summary>
    /// The author of the current medication data
    /// </summary>
    public String? Author { get; set; }

    /// <summary>
    /// A disclaimer, that should be displayed. It needs to be accepted, before the supplied data is used any further.
    /// </summary>
    public String? Disclaimer { get; set; }

    /// <summary>
    /// A description of the current medication data
    /// </summary>
    public String? About { get; set; }

    /// <summary>
    /// The version of the current medication data can be used to check, if updates are required.
    /// Must conform to semantic versioning (https://semver.org/).
    /// </summary>
    [Required]
    public required String Version { get; set; }

    /// <summary>
    /// When the current data was last updated
    /// </summary>
    public DateTime LastUpdated { get; set; }

    /// <summary>
    /// List of all medications
    /// </summary>
    [Required]
    public required List<MedicationData> MedicationData {get;set;}
}
