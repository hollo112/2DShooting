using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("능력치")]
    [SerializeField] private int _healthCount = 3;
    
    public void TakeDamage()
    {
        _healthCount--;

        if(_healthCount <= 0 )
        {
            Destroy(gameObject);
        }
    }
}
