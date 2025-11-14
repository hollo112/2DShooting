using System;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    private int _bossSpawnScore = 1000;
    private bool _isSpawned = false;
    public static event Action OnBossSpawned;

    private void OnEnable()
    {
        ScoreManager.OnScoreChanged += HandleScore;
    }
    private void OnDisable()
    {
        ScoreManager.OnScoreChanged -= HandleScore;
    }
    private void HandleScore(int score)
    {
        Debug.Log("HandleScore: " + score);
        if (_isSpawned) return;

        if (score >= _bossSpawnScore)
        {
            _isSpawned = true;
            SpawnBoss();
        }
    }

    private void SpawnBoss()                                
    {
        EnemyFactory.Instance.MakeBoss(transform.position);
        OnBossSpawned?.Invoke();
    }
}
