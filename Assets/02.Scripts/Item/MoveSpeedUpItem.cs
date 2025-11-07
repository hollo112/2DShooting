using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class MoveSpeedUpItem : MonoBehaviour
{
    [Header("이동스피드업 값")]
    public float MoveSpeedUpValue = 0.3f;

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Player") == false) return;

        PlayerMove playerMove = target.GetComponent<PlayerMove>();
        playerMove.MoveSpeedUp(MoveSpeedUpValue);

        Destroy(gameObject);
    }
}
