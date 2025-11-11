using UnityEngine;

public class Boom : MonoBehaviour
{
    [Header("파티클 프리팹")]
    public GameObject ParticlePrefab;

    private float _damage = 100f;
    private float _timer = 3f;
    private GameObject _boomInstance;

    private void Start()
    {
        _boomInstance = Instantiate(ParticlePrefab, transform.position, Quaternion.identity);
    }

    private void Update()
    {
        AliveTimer();

    }

    private void AliveTimer()
    {
        _timer -= Time.deltaTime;
        if (_timer < 0)
        {
            Destroy(gameObject);
            Destroy(_boomInstance);
        }

    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        DamageEnemy(target.gameObject);
    }

    private void DamageEnemy(GameObject target)
    {
        if (target.CompareTag("Enemy") == false) return;

        EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
        if (enemyHealth == null) return;

        enemyHealth.TakeDamage(_damage);
    }
}
