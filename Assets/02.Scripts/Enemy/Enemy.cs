using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Enemy : MonoBehaviour
{
    [Header("능력치")]
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _health = 100f;

    void Update()
    {
        MoveEnemy();
    }

    public void MoveEnemy()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamagePlayer(other.gameObject);
    }

    private void DamagePlayer(GameObject target)
    {
        if (target.CompareTag("Player") == false) return;

        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage();

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
