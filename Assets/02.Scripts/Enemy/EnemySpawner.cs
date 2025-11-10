using UnityEngine;

public enum EEnemyType
{
    Straight,
    Trace,
    Bounce,
}


public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy 프리팹")]
    public GameObject[] EnemyPrefabs;

    [Header("Enemy 생성 확률")]
    public float[] EnemyRandomWeight;

    [Header("생성 주기")]
    public float MinRandomValue = 1f;
    public float MaxRandomValue = 3f;
    private float _spawnCooltime;
    private float _spawnTimer = 0f;

    private void Start()
    {
        SetCooltimeRandom();
    }

    private void Update()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer < _spawnCooltime)
        {
            return;
        }


        ChooseEnemyRandom();
        SetCooltimeRandom();

        _spawnTimer = 0f;
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
                Instantiate(EnemyPrefabs[i], transform.position, Quaternion.identity);             
                return;
            }
        }      
    }
}