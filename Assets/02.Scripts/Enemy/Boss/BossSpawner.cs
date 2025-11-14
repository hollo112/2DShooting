using System;
using UnityEngine;

public class BossSpawner : MonoBehaviour
{
    private int _startScore = 1000;
    private int _interval = 1000;
    private int _nextSpawnScore;
    public static event Action OnBossSpawned;
    private GameObject _boss;

    private void Start()
    {
        _nextSpawnScore = _startScore;
    }
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
        if (score >= _nextSpawnScore)
        {
            SpawnBoss();
            _nextSpawnScore += _interval; // 다음 목표 점수로 업데이트
        }
    }

    private void SpawnBoss()                                
    {
        _boss = EnemyFactory.Instance.MakeBoss(transform.position);
        OnBossSpawned?.Invoke();
    }
}
