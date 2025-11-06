using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy 프리팹")]
    public GameObject StraightEnemyPrefab;
    public GameObject TraceEnemyPrefab;

    [Header("Enemy 생성 확률")]
    public float StraightEnemyRandomValue = 0.7f;
    public float TraceEnemyRandomValue = 0.3f;

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
        float random = Random.value;

        GameObject spawningPrefab = null;

        if (random < StraightEnemyRandomValue)
        {
            spawningPrefab = StraightEnemyPrefab;
        }
        else if(random < StraightEnemyRandomValue + TraceEnemyRandomValue)
        {
            spawningPrefab = TraceEnemyPrefab;
        }
        Debug.Log(spawningPrefab.name);
        Instantiate(spawningPrefab, transform.position, Quaternion.identity);
    }
}