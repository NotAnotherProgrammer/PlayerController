using UnityEngine;

public class WalkerEnemy : EnemyBase
{
    public float moveSpeed = 2.5f;
    public float destroyX = -30f;

    private void Update()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x < destroyX)
        {
            Destroy(gameObject);
        }
    }
}