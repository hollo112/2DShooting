using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("능력치")]
    private float _health = 3;
    
    public void TakeDamage(float damage)
    {
        _health -= damage;

        if(_health <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
