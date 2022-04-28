using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;
using UnityEngine.Playables;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    public bool isInvincible = false;
    public float invicibilityRedDelay = 0.01f;
    public float invincibilityTime = 3f;
    public SpriteRenderer graphics;
    public HealthBar healthBar;
    public GameObject Player;
    public Animator animator;
    public GameObject gameOverUI;
    public static Health instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("Il y a plus d'une instance de PlayerHealth dans la scène");
            return;
        }

        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth<=0)
        {
            OnPlayerDeath();
        }
    }

    public void Respawn()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth); 
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

    public void OnPlayerDeath()
    {
        Player.SetActive(false);
        gameOverUI.SetActive(true);
    }
    private IEnumerator waitTwoSeconds()
    {
        yield return new WaitForSeconds(0.3f);
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        graphics.enabled = false;
    }
}
