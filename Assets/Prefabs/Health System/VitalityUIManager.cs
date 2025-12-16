using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Reflection.Emit;

public class VitalityUIManager : MonoBehaviour
{
    // ------------------------------------------------------
    #region Properties
    [SerializeField] private Vitality vitality;
    [SerializeField] private Image barFill;
    [SerializeField] private Image background;
    [SerializeField] private TextMeshProUGUI label;
    #endregion

    // ------------------------------------------------------
    #region Methods
    private void UpdateHealthBar(int currentHealth, int maxHealth)
    {
        if (barFill == null)
        {
            Debug.LogWarning("Bar Fill Image is not assigned.");
            return;
        }

        if (label == null)
        {
            Debug.LogWarning("Label TextMeshProUGUI is not assigned.");
            return;
        }

        float fillAmount = (float)currentHealth / maxHealth;
        label.text = $"{currentHealth} / {maxHealth} HP";

        Debug.Log($"Current Health: {currentHealth}, Max Health: {maxHealth}");
        Debug.Log($"Fill Amount Calculated: {fillAmount}");

        if (fillAmount <= 0 || fillAmount > 1 || float.IsNaN(fillAmount))
        {
            Debug.LogWarning("Calculated fill amount is out of bounds.");
            fillAmount = 0;
        }

        barFill.fillAmount = fillAmount;
    }

    // bloody background effect gets more transparent as health decreases
    private void UpdateBackground(int currentHealth, int maxHealth)
    {
        if (background == null)
        {
            Debug.LogWarning("Background Image is not assigned.");
            return;
        }

        float opacity = (float)currentHealth / maxHealth;
        if (opacity < 0 || opacity > 1 || float.IsNaN(opacity))
        {
            Debug.LogWarning("Calculated opacity is out of bounds.");
            opacity = 0;
        }

        Color bgColor = background.color;
        bgColor.a = 1 - opacity; // Inverse opacity for bloody effect
        background.color = bgColor;

    }
    #endregion

    // ------------------------------------------------------
    #region Enable / Disable
    void OnEnable()
    {
        if (vitality != null)
        {
            vitality.onHealthChanged += UpdateHealthBar;
            UpdateHealthBar(vitality.currentHealth, vitality.maxHealth); // Initialize health bar on enable
            UpdateBackground(vitality.currentHealth, vitality.maxHealth); // Initialize background on enable
        }
    }
    void OnDisable()
    {
        if (vitality != null)
        {
            vitality.onHealthChanged -= UpdateHealthBar;
        }
    }
    #endregion
}
