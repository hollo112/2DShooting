using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("능력치")]
    [SerializeField] private int _healthCount = 3;
    
    public int HealthCount { get { return _healthCount; } }
    public void TakeDamage()
    {
        _healthCount--;
    }
}
