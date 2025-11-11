using UnityEngine;

public class FireSpeedUpItem : MonoBehaviour
{
    [Header("공격스피드업 값")]
    public float FireSpeedUpValue = 0.1f;

    [Header("파티클 프리팹")]
    public GameObject ParticlePrefab;

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player") == false) return;

        PlayerFire playerFire = target.GetComponent<PlayerFire>();
        playerFire.FireSpeedUp(FireSpeedUpValue);

        MakeParticleEffect();
        Destroy(gameObject);
    }

    private void MakeParticleEffect()
    {
        if (ParticlePrefab == null) return;
        Instantiate(ParticlePrefab, transform.position, Quaternion.identity);
    }
}
