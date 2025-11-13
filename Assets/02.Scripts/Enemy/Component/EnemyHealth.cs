using System;
using UnityEngine;
public class EnemyHealth : MonoBehaviour
{
    [Header("체력")]
    private float _maxHealth = 100f;
    private float _health = 100f;
    [Header("점수")]
    private int _score = 100;

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

    private void OnEnable()
    {
        _health = _maxHealth;
    }

    public void TakeDamage(float Damage)
    {
        _animator.SetTrigger("Hit");
        _health -= Damage;
        Debug.Log(_health);
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

        ScoreManager.Instance.AddScore( _score );

        gameObject.SetActive(false);
    }

    public void DieImmediately()
    {
        TakeDamage(_health);
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
