using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy 프리팹")]
    public GameObject StraightEnemy;
    public GameObject FollowingEnemy;

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
        //GameObject enemyObject = Instantiate(EnemyPrefab);
        //enemyObject.transform.position = transform.position;
    }
}
