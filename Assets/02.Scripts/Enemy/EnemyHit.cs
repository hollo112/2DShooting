using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    [Header("받는 데미지%")]
    [SerializeField] private float DamagePercent = 100f; 
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
    }

    public void OnHit(float damage)
    {
        float finalDamage = damage * (DamagePercent / 100f);
        _enemy.TakeDamage(finalDamage);
    }
}
