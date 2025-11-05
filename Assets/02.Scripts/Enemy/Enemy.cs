using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("능력치")]
    public float Speed = 1.0f;
    public float Health = 100f;

    void Start()
    {
        
    }

    void Update()
    {
        MoveEnemy();
    }

    public void MoveEnemy()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * Speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") == false) return;
        Destroy(this.gameObject);

        PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
        playerHealth.DamageCount--;
        if(playerHealth.DamageCount <= 0 )
        {
            Destroy(other.gameObject);
        }
    }
}
