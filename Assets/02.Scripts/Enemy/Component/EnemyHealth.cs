using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    [Header("체력")]
    private float _health = 100f;
    private EnemyDropItem _enemyDropItem;

    private void Awake()
    {
        _enemyDropItem = GetComponent<EnemyDropItem>();
    }

    public void TakeDamage(float Damage)
    {
        _health -= Damage;

        if (_health < 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if( _enemyDropItem != null )
        {
            _enemyDropItem.DropItem();
        }

        Destroy(gameObject);
    }
}
