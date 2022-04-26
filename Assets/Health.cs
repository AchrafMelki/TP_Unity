using UnityEngine;
using UnityEngine.UI;
using System.Collections;
public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isInvincible = false;
    public float invicibilityRedDelay = 0.2f;
    public float invincibilityTime = 3f;
    public SpriteRenderer graphics;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;
            healthBar.SetHealth(currentHealth);
            isInvincible = true;
            StartCoroutine(InvinciblityRed());
            StartCoroutine(InvincibilityDelay());
        }
    }

    public IEnumerator InvinciblityRed()
    {
        while (isInvincible)
        {
            graphics.color = new Color(1f, 0f, 0f, 1f);
            yield return new WaitForSeconds(invicibilityRedDelay);
            graphics.color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invicibilityRedDelay);
        }
    }

    public IEnumerator InvincibilityDelay()
    {
        yield return new WaitForSeconds(invincibilityTime);
        isInvincible = false;
    }
}
