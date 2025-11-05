using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy 프리팹")]
    public GameObject EnemyPrefab;

    [Header("생성 주기")]
    [SerializeField] private float _minRandomValue = 1f;
    [SerializeField] private float _maxRandomValue = 3f;
    private float SpawnCooltime;
    private float _spawnTimer = 0f;

    private void Start()
    {
        SetCooltimeRandom();
    }

    void Update()
    {
        _spawnTimer += Time.deltaTime;
        if (_spawnTimer < SpawnCooltime)
        {
            return;
        }

        GameObject enemyObject = Instantiate(EnemyPrefab);
        enemyObject.transform.position = transform.position;
       
        SetCooltimeRandom();

        _spawnTimer = 0f;
    }

    void SetCooltimeRandom()
    {
        float randomCooltime = UnityEngine.Random.Range(_minRandomValue, _maxRandomValue);
        SpawnCooltime = randomCooltime;
    }
}
