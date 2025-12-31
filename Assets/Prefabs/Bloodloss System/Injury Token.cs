using UnityEngine;

/// <summary>
/// Types of injuries that can be represented by Injury Tokens.
/// </summary>
/// 
/// Token Value     -> Severity Level (1-10)
/// Token Priority  -> Importance of the injury (higher priority injuries should be treated first)
///     
    
#region Enums
/// <summary>
/// Injury and limb types work together to specify the nature and location of the injury.
/// Different injury types have different implications for blood loss, stat penalties, and death.
/// 
/// Getting a puncture wound to the head or upper torso will instantly kill the player,
/// but getting a bruise on an arm will have minimal effects.
/// 
/// Fractures will cripple the player's movement if they occur on legs or arms.
/// Burns can cause ongoing damage over time that cannot be healed with traditional healing methods.
/// </summary>
public enum InjuryType
{
    Cut,
    Bruise,
    Puncture,
    Fracture,
    Burn
}

public enum Limb
{
    Head,
    UpperTorso,
    LowerTorso,
    Arm,
    Leg
}
#endregion


public class InjuryToken : Token
{
    /// <summary>
    /// Injustry Token representing a specific injury type and severity.
    /// </summary>

    #region Properties
    [Header("Injury Token Settings")]
    public InjuryType injuryType { get; set; }
    public Limb affectedLimb { get; set; }
    public float injuryLevel { get; set; } // Severity level from 1 to 10
    public float lossAmount { get; set; }
    #endregion
    
}
