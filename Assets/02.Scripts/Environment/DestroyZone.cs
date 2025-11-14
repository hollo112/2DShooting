using UnityEngine;

public class DestroyZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet") || collision.CompareTag("Enemy"))
        {
            collision.gameObject.SetActive(false);
            return;
        }

        if (collision.CompareTag("EnemyHitBox")) return;
        Destroy(collision.gameObject);
    }
}
