using UnityEngine;

public class WeaponHitbox : MonoBehaviour
{
    private PlayerController2D owner;
    public int damage = 20;

    public void SetOwner(PlayerController2D player)
    {
        owner = player;
    }

    public void UpdateDirection(bool facingRight)
    {
        // Flip the hitbox if needed
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs(scale.x) * (facingRight ? 1 : -1);
        transform.localScale = scale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyBase enemy = other.GetComponent<EnemyBase>();
        if (enemy != null && owner != null)
        {
            // Deal damage to enemy
            // Assuming enemy has a TakeDamage method, but since it's base class, maybe add it later
            Debug.Log("Hit enemy!");
            // enemy.TakeDamage(damage);
        }
    }
}