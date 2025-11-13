using System.Collections.Generic;
using UnityEngine;

public enum EEnemyType
{
    None,
    Straight,
    Trace,
    Bounce,
}

public class EnemyFactory : MonoBehaviour
{
    public static EnemyFactory Instance {get; private set;}
    
    [Header("Enemy 프리팹")]
    [SerializeField]private GameObject _straightEnemyPrefab;
    [SerializeField]private GameObject _traceEnemyPrefab;
    [SerializeField]private GameObject _bounceEnemyPrefab;
    
    [Header("풀링")] 
    public int PoolSize = 20;
    private Dictionary<EEnemyType, GameObject> _enemyPrefabs;      // 프리팹 저장
    private Dictionary<EEnemyType, GameObject[]> _enemyPools;      // 각 타입별 풀 저장
    private void Awake()
    {
        if(Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

        InitPrefabs();
        InitPools();
    }

    private void InitPrefabs()
    {
        _enemyPrefabs = new Dictionary<EEnemyType, GameObject>
        {
            { EEnemyType.Straight, _straightEnemyPrefab },
            { EEnemyType.Trace, _traceEnemyPrefab },
            { EEnemyType.Bounce, _bounceEnemyPrefab },
        };
    }

    private void InitPools()
    {
        _enemyPools = new Dictionary<EEnemyType, GameObject[]>();

        foreach (var enemyType in _enemyPrefabs.Keys)
        {
            GameObject[] pool = new GameObject[PoolSize];
            GameObject prefab = _enemyPrefabs[enemyType];

            for (int i = 0; i < PoolSize; i++)
            {
                pool[i] = Instantiate(prefab, transform);
                pool[i].SetActive(false);
            }

            _enemyPools[enemyType] = pool;
        }
    }
    
    public GameObject MakeEnemy(EEnemyType type, Vector3 position)
    {
        GameObject enemy = GetFromPool(type);

        if (enemy == null)
        {
            Debug.LogError($"{type} 풀에 적이 부족합니다!");
            return null;
        }

        enemy.transform.position = position;
        enemy.SetActive(true);

        return enemy;
    }
    
    private GameObject GetFromPool(EEnemyType type)
    {
        GameObject[] pool = _enemyPools[type];

        for (int i = 0; i < PoolSize; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        return null;
    }
}
