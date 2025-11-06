using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("능력치")]
    private float _health = 3;
    
    public void TakeDamage(float damage)
    {
        _health -= damage;
        Debug.Log(_health);
        if(_health <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
