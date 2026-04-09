using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Stats")]
    public int maxHealth = 100;
    public int currentHealth = 100;
    public int lives = 3;
    public int damagePerHit = 20;

    [Header("Respawn")]
    public Transform respawnPoint;

    [Header("Invincibility")]
    public float invincibleTime = 1f;

    private bool invincible;
    private float invincibleTimer;
    private PlayerController2D playerController;
    private Rigidbody2D rb;

    public System.Action<int, int> OnHealthChanged;
    public System.Action<int> OnLivesChanged;

    private void Awake()
    {
        playerController = GetComponent<PlayerController2D>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    private void Start()
    {
        OnHealthChanged?.Invoke(currentHealth, maxHealth);
        OnLivesChanged?.Invoke(lives);
    }

    private void Update()
    {
        if (invincible)
        {
            invincibleTimer -= Time.deltaTime;
            if (invincibleTimer <= 0f)
            {
                invincible = false;
            }
        }
    }

    public void TakeDamage(int amount)
    {
        if (invincible) return;
        if (GameManager.Instance == null || GameManager.Instance.GameEnded) return;

        currentHealth -= amount;
        if (currentHealth < 0) currentHealth = 0;

        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (currentHealth <= 0)
        {
            LoseLife();
        }
        else
        {
            invincible = true;
            invincibleTimer = invincibleTime;
        }
    }

    private void LoseLife()
    {
        lives--;
        OnLivesChanged?.Invoke(lives);

        if (lives <= 0)
        {
            currentHealth = 0;
            OnHealthChanged?.Invoke(currentHealth, maxHealth);

            if (GameManager.Instance != null)
            {
                GameManager.Instance.GameOver(false);
            }

            gameObject.SetActive(false);
            return;
        }

        Respawn();
    }

    private void Respawn()
    {
        currentHealth = maxHealth;
        OnHealthChanged?.Invoke(currentHealth, maxHealth);

        if (respawnPoint != null)
        {
            transform.position = respawnPoint.position;
        }

        rb.linearVelocity = Vector2.zero;

        invincible = true;
        invincibleTimer = invincibleTime;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        EnemyBase enemy = other.GetComponent<EnemyBase>();
        if (enemy != null)
        {
            TakeDamage(enemy.contactDamage);
        }
    }
}