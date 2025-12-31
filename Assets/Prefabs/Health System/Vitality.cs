using UnityEngine;


public class Vitality : MonoBehaviour
{
    #region Properties
    [Header("Vitality Settings")]
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int currentHealth = 100;
    [SerializeField] public bool isInvincible { get; set; }
    [SerializeField] public bool canSavingThrow { get; set; }
    [SerializeField] public bool logHealthChanges = false;



    [Header("Object References")]
    [SerializeField] private GameObject go { get; set; }
    #endregion



    #region Constructors
    public Vitality(int maxHealth, bool isInvincible = false, bool canSavingThrow = false)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth;
        this.isInvincible = isInvincible;
        this.canSavingThrow = canSavingThrow;
        this.go = this.gameObject;

        if (logHealthChanges) {onLogDetails?.Invoke($"{go.name} is born!");}
    }
    #endregion



    #region Methods
    // ----------------------------------------------------------
    // Apply damage to the entity by x amount
    private void TakeDamage(int damage)
    {
        if (isInvincible || damage <= 0) return;                // No damage taken if invincible or damage is non-positive.

        currentHealth -= damage;
        if (canSavingThrow && currentHealth > (maxHealth / 2))  // Saving throw prevents death when above half health, can't get one shot.
        {
            currentHealth = Mathf.Clamp(currentHealth, 1, maxHealth);
            return;
        }
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth <= 0) { Die(); }

        onHealthChanged?.Invoke(currentHealth, maxHealth);

        // Logging
        if(logHealthChanges) {onLogDetails?.Invoke($"Took {damage} damage. Current Health: {currentHealth}/{maxHealth}");}
    }

    // ----------------------------------------------------------
    // Heal the entity by x amount
    private void Heal(int amount)
    {
        if (isInvincible || amount <= 0) return;                // No healing if invincible or amount is non-positive.

        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        onHealthChanged?.Invoke(currentHealth, maxHealth);

        // Logging
        if(logHealthChanges) {onLogDetails?.Invoke($"Healed {amount} health. Current Health: {currentHealth}/{maxHealth}");}
    }

    // ----------------------------------------------------------
    // Handle entity death
    private void Die()
    {
        if (go == null) {return;}

        onDeath?.Invoke();
        GameObject.Destroy(go);

        // Logging
        if(logHealthChanges) {onLogDetails?.Invoke($"{go.name} has died.");}
    }
    #endregion



    #region Delegates & Events
    // ----------------------------------------------------------
    // Health changed and death events
    public delegate void OnHealthChanged(int currentHealth, int maxHealth);
    public event OnHealthChanged onHealthChanged;
    public delegate void OnDeath();
    public event OnDeath onDeath;
    public delegate void LogDetails(string details);
    public event LogDetails onLogDetails;
    #endregion
}
