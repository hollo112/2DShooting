using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public abstract class Enemy : MonoBehaviour
{
    [Header("능력치")]
    public float Speed = 2.0f;
    public float Damage = 1.0f;
    private float _health = 100f;

    protected virtual void Update()
    {
        MoveEnemy();
    }

    protected abstract void MoveEnemy();

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

    public void TakeDamage(float Damage)
    {
        _health -= Damage;
        if (_health < 0)
        {
            Destroy(gameObject);
        }
    }
}
