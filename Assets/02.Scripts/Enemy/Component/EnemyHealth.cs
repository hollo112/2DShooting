using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyHealth : MonoBehaviour
{
    [Header("체력")]
    private float _health = 100f;

    public void TakeDamage(float Damage)
    {
        _health -= Damage;

        if (_health < 0)
        {
            Destroy(gameObject);
        }
    }
}
