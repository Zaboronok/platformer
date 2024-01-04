using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public int health = 5;
    public int maxHealth = 5;

    private bool _invulnerable = false;

    //public AudioSource takeDamageSound;
    public AudioSource addHealthSound;
    public HealthUI healthUI;
    //public DamageScreen damageScreen;
    //public Blink blink;
    public UnityEvent eventOnTakeDamage;

    private void Start()
    {
        healthUI.Setup(maxHealth);
        healthUI.DisplayHealth(health);
    }

    public void TakeDamage(int damage)
    {
        if(!_invulnerable) {
            health -= damage;

            if (health <= 0)
            {
                health = 0;
                Die();
            }

            _invulnerable = true;
            Invoke("StopInvulnerable", 1f);
            //takeDamageSound.Play();
            healthUI.DisplayHealth(health);
            //damageScreen.StartEffect();
            //blink.StartBlink();
            eventOnTakeDamage.Invoke();
        }

    }

    public void AddHealth(int healthValue)
    {
        health += healthValue;

        if(health > maxHealth)
        {
            health = maxHealth;
        }

        addHealthSound.Play();
        healthUI.DisplayHealth(health);
    }

    public void Die()
    {
        Debug.Log("Player is die");
    }

    void StopInvulnerable()
    {
        _invulnerable = false;
    }
}
