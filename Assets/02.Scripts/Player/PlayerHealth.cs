using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("능력치")]
    private float _health = 3;
    private const float _maxhealth = 3;
    
    public void TakeDamage(float damage)
    {
        _health -= damage;

        if(_health <= 0 )
        {
            Destroy(gameObject);
        }
    }

    public void Heal(float healValue)
    {
        _health += healValue;
        _health = Mathf.Min(_health, _maxhealth);
    }
}
