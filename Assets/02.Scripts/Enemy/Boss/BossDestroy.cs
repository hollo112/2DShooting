using System;
using UnityEngine;

public class BossDestroy : MonoBehaviour
{
    public static event Action OnBossDie;
    private void OnDisable()
    {
        OnBossDie?.Invoke();
        Destroy(gameObject);
    }
}
