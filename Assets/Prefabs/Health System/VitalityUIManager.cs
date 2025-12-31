using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Reflection.Emit;
using UnityEditor.VersionControl;

public class VitalityUIManager : MonoBehaviour
{
    #region Properties
    [Header("Vitality UI Settings")]
    [SerializeField] public bool logHealthUIChanges = false;

    [Header("Object References")]
    [SerializeField] private Vitality vitality;
    [SerializeField] private Image barFill;
    [SerializeField] private Image background;
    [SerializeField] private TextMeshProUGUI label;
    #endregion



    #region Methods
    // ----------------------------------------------------------
    // Update the health bar UI based on current health
    private void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (barFill == null) { Debug.LogError("BarFill image is null in VitalityUIManager"); return;}
        if (label == null) { Debug.LogError("Label is null in VitalityUIManager"); return; }

        float fillAmount = (float)currentHealth / maxHealth;
        label.text = $"{currentHealth} / {maxHealth} HP";


        if(logHealthUIChanges)
        {
            onLogDetails?.Invoke($"Updating Health Bar: {currentHealth}/{maxHealth} HP ({fillAmount * 100}%)");
        }

        if (fillAmount <= 0 || fillAmount > 1 || float.IsNaN(fillAmount)) { Debug.LogWarning("Fill amount is out of bounds or NaN in VitalityUIManager"); fillAmount = 0;}
        barFill.fillAmount = fillAmount;
    }

    // ----------------------------------------------------------
    // bloody background effect gets more transparent as health decreases
    private void UpdateBackground(int currentHealth, int maxHealth)
    {
        if (background == null) { Debug.LogError("Background image is null in VitalityUIManager"); return; }

        float opacity = (float)currentHealth / maxHealth;
        if (opacity < 0 || opacity > 1 || float.IsNaN(opacity)) { opacity = 0; }

        Color bgColor = background.color;
        bgColor.a = 1 - opacity; // Inverse opacity for bloody effect
        background.color = bgColor;

    }
    #endregion



    #region Enable / Disable
    // ----------------------------------------------------------
    // Logging event
    public delegate void LogDetails(string details);
    public event LogDetails onLogDetails;

    // ----------------------------------------------------------
    // Subscribe and unsubscribe to vitality events
    void OnEnable()
    {
        if (vitality == null) { Debug.LogError("Vitality component is null in VitalityUIManager"); return; }
        vitality.onHealthChanged += UpdateHealthBar;
        UpdateHealthBar(vitality.currentHealth, vitality.maxHealth); // Initialize health bar on enable
        UpdateBackground(vitality.currentHealth, vitality.maxHealth); // Initialize background on enable
    }
    void OnDisable()
    {
        if (vitality == null) { return; }
        vitality.onHealthChanged -= UpdateHealthBar;
    }

    #endregion
}
