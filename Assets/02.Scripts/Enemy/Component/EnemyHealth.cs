using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    [Header("체력")]
    private float _health = 100f;
    private EnemyDropItem _enemyDropItem;
    private Animator _animator;

    [Header("폭발 프리팹")]
    public GameObject ExplosionPrefab;

    private void Awake()
    {
        _enemyDropItem = GetComponent<EnemyDropItem>();
        _animator = GetComponent<Animator>();
    }

    private void Start()
    {
        if (EnemyManager.Instance != null)
        {
            EnemyManager.Instance.RegisterEnemy(gameObject);
        }
    }

    public void TakeDamage(float Damage)
    {
        _animator.SetTrigger("Hit");
        _health -= Damage;

        if (_health <= 0)
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

        MakeExplosionEffect();

        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        EnemyManager.Instance.UnregisterEnemy(gameObject);
    }

    private void MakeExplosionEffect()
    {
        Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);
    }
}
