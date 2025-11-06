using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    [Header("받는 데미지%")]
    public float DamagePercent = 100f; 
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
    }

    public void OnHit(float damage)
    {
        Debug.Log("OnHit");
        float finalDamage = damage * (DamagePercent / 100f);
        _enemy.TakeDamage(finalDamage);
    }
}
