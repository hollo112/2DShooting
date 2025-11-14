using UnityEngine;
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

        gameObject.SetActive(false);
    }
}
