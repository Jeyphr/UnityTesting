using UnityEngine;



public class Vitality
{
    #region Properties
    [SerializeField] private int maxHealth { get; set; }
    [SerializeField] private int currentHealth { get; set; }

    // ------------------------------------------------------
    [SerializeField] private bool isInvincible { get; set; }
    [SerializeField] private bool canSavingThrow { get; set; }
    #endregion

    // ------------------------------------------------------
    public Vitality(int maxHealth, int currentHealth, bool isInvincible, bool canSavingThrow)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = currentHealth;
        this.isInvincible = isInvincible;
        this.canSavingThrow = canSavingThrow;
    }

    // ------------------------------------------------------
    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
    }

    // ------------------------------------------------------

}
