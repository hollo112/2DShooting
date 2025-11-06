using UnityEngine;

public class EnemyHitBox : MonoBehaviour
{
    [Header("받는 데미지%")]
    public float DamagePercent = 100f; 
    private EnemyHealth _enemyHealth;

    private void Awake()
    {
        _enemyHealth = GetComponentInParent<EnemyHealth>();
    }

    public void OnHit(float damage)
    {
        Debug.Log("OnHit");
        float finalDamage = damage * (DamagePercent / 100f);
        _enemyHealth.TakeDamage(finalDamage);
    }
}
