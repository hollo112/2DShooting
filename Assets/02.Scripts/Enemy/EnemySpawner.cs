using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy 생성 확률")]
    public float[] EnemyRandomWeight;

    [Header("생성 주기")]
    public float MinRandomValue = 1f;
    public float MaxRandomValue = 3f;
    private float _spawnCooltime;
    private float _spawnTimer = 0f;
    private bool _canSpawn = true;
    private void Start()
    {
        SetCooltimeRandom();
    }

    private void Update()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer < _spawnCooltime)   {return;}
        if(!_canSpawn)  {return;}
        
        ChooseEnemyRandom();
        SetCooltimeRandom();

        _spawnTimer = 0f;
    }
    private void OnEnable()
    {
        BossSpawner.OnBossSpawned += StopSpawn;
    }

    private void OnDisable()
    {
        BossSpawner.OnBossSpawned -= StopSpawn;
    }

    private void StopSpawn()
    {
        _canSpawn = false;
    }
    
    private void SetCooltimeRandom()
    {
        float randomCooltime = UnityEngine.Random.Range(MinRandomValue, MaxRandomValue);
        _spawnCooltime = randomCooltime;
    }

    private void ChooseEnemyRandom()
    {
        float totalWeight = 0f;
        foreach (float enemyWeight in EnemyRandomWeight)
        {
            totalWeight += enemyWeight;
        }

        float randomValue = Random.Range(0f, totalWeight);
        float cumulativeWeight = 0f;

        for(int i = 0; i < EnemyRandomWeight.Length; i++)
        {
            cumulativeWeight += EnemyRandomWeight[i];
            if(randomValue <= cumulativeWeight)
            {
                EEnemyType enemyType = GetEnemyType(i);
                EnemyFactory.Instance.MakeEnemy(enemyType, transform.position);      
                return;
            }
        }      
    }

    private EEnemyType GetEnemyType(int index)
    {
        switch (index)
        {
            case 0:
                return EEnemyType.Straight;
            case 1:
                return EEnemyType.Trace;
            case 2:
                return EEnemyType.Bounce;
            default:
                return EEnemyType.None;
        }
    }
}