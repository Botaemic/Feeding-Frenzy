using Botaemic.Unity.HealthSystems;
using UnityEngine;

public class Actor : MonoBehaviour
{
    [SerializeField]
    private float maximumHealthpoints = 10f;

    [SerializeField]
    private bool hasShield = false;
    [SerializeField]
    private float maximumShieldpoints = 10f;

    [SerializeField]
    private HealthBar healthBar = null;

    [SerializeField]
    private HealthPortrait healthPortrait = null;

    [SerializeField]
    private HealthBarCanvas healthBarCanvas = null;

    private HealthSystem healthSystem = null;


    private void Awake()
    {
        healthSystem = new HealthSystem(maximumHealthpoints, maximumShieldpoints, hasShield);

        if (healthBar != null) { healthBar.Setup(healthSystem); }
        if (healthPortrait != null) { healthPortrait.Setup(healthSystem); }
        if (healthBarCanvas != null) { healthBarCanvas.Setup(healthSystem); }
    }

    void Update()
    {
        if (healthSystem.HealthPoints < Mathf.Epsilon)
        {
            Destroy(gameObject);
        }
    }

    public void ReceiveDamage(float amount)
    {
        healthSystem.Damage(amount);
    }

    public void Heal(float amount)
    {
        healthSystem.Heal(amount);
    }

    public void RechargeShield(float amount)
    {
        healthSystem.RechargeShield(amount);
    }

}
