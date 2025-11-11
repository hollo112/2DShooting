using UnityEngine;

public class HealItem : MonoBehaviour
{
    [Header("힐 값")]
    public float HealValue = 0.5f;

    [Header("파티클 프리팹")]
    public GameObject ParticlePrefab;

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player") == false) return;

        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        playerHealth.Heal(HealValue);

        MakeParticleEffect();

        Destroy(gameObject);
    }

    private void MakeParticleEffect()
    {
        if (ParticlePrefab == null) return;
        Instantiate(ParticlePrefab, transform.position, Quaternion.identity);
    }
}
