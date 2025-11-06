using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyAttack : MonoBehaviour
{
    [Header("능력치")]
    public float Damage = 1.0f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamagePlayer(other.gameObject);
    }

    private void DamagePlayer(GameObject target)
    {
        if (target.CompareTag("Player") == false) return;

        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage(Damage);

        Destroy(this.gameObject);
    }
}
