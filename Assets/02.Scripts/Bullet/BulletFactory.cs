using System.Collections.Generic;
using UnityEngine;

public enum EBulletType
{
    StraightBullet,
    SubBullet,
    HeartBullet,
    PetBullet,
    BossWave,
    BossStraight,
    BossCircle,
}
public class BulletFactory : MonoBehaviour
{
    public static BulletFactory Instance { get; private set; }

    [Header("총알 프리팹")]
    [SerializeField]private GameObject _straightBulletPrefab;
    [SerializeField]private GameObject _subBulletPrefab;
    [SerializeField]private GameObject _heartBulletPrefab;
    [SerializeField]private GameObject _petBulletPrefab;
    [SerializeField]private GameObject _BossWaveBulletPrefab;
    [SerializeField]private GameObject _BossStraightBulletPrefab;
    [SerializeField]private GameObject _BossCircleBulletPrefab;

    [Header("풀링")] 
    public int PoolSize = 20;
    private Dictionary<EBulletType, GameObject> _bulletPrefabs;      // 프리팹 저장
    private Dictionary<EBulletType, GameObject[]> _bulletPools;      // 각 타입별 풀 저장

    private void Awake()
    {
        if (Instance != null && Instance != this)
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
        _bulletPrefabs = new Dictionary<EBulletType, GameObject>
        {
            { EBulletType.StraightBullet, _straightBulletPrefab },
            { EBulletType.SubBullet, _subBulletPrefab },
            { EBulletType.HeartBullet, _heartBulletPrefab },
            { EBulletType.PetBullet, _petBulletPrefab },
            { EBulletType.BossWave, _BossWaveBulletPrefab },
            { EBulletType.BossStraight, _BossStraightBulletPrefab },
            { EBulletType.BossCircle, _BossCircleBulletPrefab },
        };
    }

    private void InitPools()
    {
        _bulletPools = new Dictionary<EBulletType, GameObject[]>();

        foreach (var bulletType in _bulletPrefabs.Keys)
        {
            GameObject[] pool = new GameObject[PoolSize];
            GameObject prefab = _bulletPrefabs[bulletType];

            for (int i = 0; i < PoolSize; i++)
            {
                pool[i] = Instantiate(prefab, transform);
                pool[i].SetActive(false);
            }

            _bulletPools[bulletType] = pool;
        }
    }

    public GameObject MakeBullet(EBulletType type, Vector3 position, bool isRight)
    {
        GameObject bullet = GetFromPool(type);

        if (bullet == null)
        {
            Debug.LogError($"{type} 풀에 총알이 부족합니다!");
            return null;
        }

        bullet.transform.position = position;
        bullet.SetActive(true);

        ApplyDirection(bullet, isRight);

        return bullet;
    }

    private GameObject GetFromPool(EBulletType type)
    {
        GameObject[] pool = _bulletPools[type];

        for (int i = 0; i < PoolSize; i++)
        {
            if (!pool[i].activeInHierarchy)
            {
                return pool[i];
            }
        }

        return null;
    }

    private void ApplyDirection(GameObject bullet, bool isRight)
    {
        HeartBullet heart = bullet.GetComponent<HeartBullet>();
        if (heart != null)
        {
            heart._isRight = isRight;
        }
    }
}
