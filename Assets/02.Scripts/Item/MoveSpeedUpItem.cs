using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveSpeedUpItem : MonoBehaviour
{
    [Header("이동스피드업 값")]
    public float MoveSpeedUpValue = 0.3f;

    [Header("파티클 프리팹")]
    public GameObject ParticlePrefab;

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player") == false) return;

        PlayerMove playerMove = target.GetComponent<PlayerMove>();
        playerMove.MoveSpeedUp(MoveSpeedUpValue);

        MakeParticleEffect();

        Destroy(gameObject);
    }

    private void MakeParticleEffect()
    {
        if (ParticlePrefab == null) return;
        Instantiate(ParticlePrefab, transform.position, Quaternion.identity);
    }
}
