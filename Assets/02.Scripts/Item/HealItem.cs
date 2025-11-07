using UnityEngine;

public class HealItem : MonoBehaviour
{
    [Header("힐 값")]
    public float HealValue = 0.5f;

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player") == false) return;

        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        playerHealth.Heal(HealValue);

        Destroy(gameObject);
    }
}
