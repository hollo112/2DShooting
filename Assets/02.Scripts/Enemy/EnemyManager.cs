using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public static EnemyManager Instance { get; private set; }
    private List<GameObject> _enemies = new List<GameObject>();

    private void Awake()
    {
        Instance = this;
    }

    public void RegisterEnemy(GameObject enemy)
    {
        if (!_enemies.Contains(enemy))
            _enemies.Add(enemy);
    }

    public void UnregisterEnemy(GameObject enemy)
    {
        _enemies.Remove(enemy);
    }

    public Transform GetClosestEnemy(Vector2 playerPos)
    {
        GameObject closest = null;
        float minDist = float.MaxValue;
        foreach (var enemy in _enemies)
        {
            if (enemy == null) continue;

            if (enemy.transform.position.y <= playerPos.y)
                continue;

            float dist = Vector2.Distance(playerPos, enemy.transform.position);
            if (dist < minDist)
            {
                minDist = dist;
                closest = enemy;
            }
        }
        if (closest != null)
        {
            return closest.transform;
        }
        return null;
    }

    public int CountEnemiesNear(Vector2 point, float range)
    {
        int count = 0;
        foreach (var enemy in _enemies)
        {
            if (enemy == null) continue;
            float dist = Vector2.Distance(point, enemy.transform.position);
            if (dist < range)
                count++;
        }
        return count;
    }
}
