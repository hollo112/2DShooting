using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("능력치")]
    private float _health = 5;
    private const float _maxhealth = 3;

    [Header("이펙트 프리팹")]
    public GameObject ExplosionPrefab;

    public void TakeDamage(float damage)
    {
        _health -= damage;

        if(_health <= 0 )
        {
            Destroy(gameObject);
            MakeEffect(ExplosionPrefab);
        }
    }

    private void MakeEffect(GameObject prefab)
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
    }

    public void Heal(float healValue)
    {
        _health += healValue;
        _health = Mathf.Min(_health, _maxhealth);
    }
}
