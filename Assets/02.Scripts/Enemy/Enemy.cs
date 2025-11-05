using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("능력치")]
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private float _health = 100f;

    void Update()
    {
        MoveEnemy();
    }

    public float Health { get { return _health; } }

    public void MoveEnemy()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == false) return;
        Destroy(this.gameObject);

        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage();
        if(playerHealth.HealthCount <= 0 )
        {
            Destroy(other.gameObject);
        }
    }

    public void TakeDamage(float Damage)
    {
        _health -= Damage;
    }
}
