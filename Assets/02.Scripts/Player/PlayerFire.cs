using UnityEditor;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("총알 프리팹")]
    public GameObject StraightBulletPrefab;
    public GameObject SubBulletPrefab;
    public GameObject WaveBulletPrefab;
    private GameObject _currentBulletPrefab;

    [Header("발사 위치")]
    public Transform[] FirePosition;
    public Transform SubFirePositionLeft;
    public Transform SubFirePositionRight;

    [Header("발사 간격")]
    public float Cooltime = 0.6f;
    private float _fireTimer = 0f;

    public enum FireType
    {
        Auto = 1,
        Manual = 2
    }

    public enum BulletType
    {
        Straight = 1,
        SineWave = 2
    }

    [Header("공격 모드")]
    public FireType CurrentFireType = FireType.Auto; // 1: 자동, 2: 수동
    public BulletType CurrentBulletType = BulletType.Straight;
    void Start()
    {
        
    }

    void Update()
    {
        ChangeFireMode();
        ChangeBulletType();
        //FireBullet();
    }

    void FireBullet()
    {
        _fireTimer += Time.deltaTime;
        if (_fireTimer < Cooltime)
        {
            return;
        }

        foreach (Transform pos in FirePosition)
        {
            Instantiate(_currentBulletPrefab, pos.position, Quaternion.identity);
        }

        var leftSubBullet = Instantiate(SubBulletPrefab, SubFirePositionLeft.position, Quaternion.identity).GetComponent<Bullet>();
        leftSubBullet.Direction = Bullet.BulletDirection.Left;
        var rightSubBullet = Instantiate(SubBulletPrefab, SubFirePositionRight.position, Quaternion.identity).GetComponent<Bullet>();
        rightSubBullet.Direction = Bullet.BulletDirection.Right;

        _fireTimer = 0f;
    }

    void ChangeFireMode()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            CurrentFireType = FireType.Auto;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            CurrentFireType = FireType.Manual;
        }

        switch (CurrentFireType)
        {
            case FireType.Auto: // 자동
                FireBullet();
                break;
            case FireType.Manual: // 수동
                if(Input.GetKey(KeyCode.Space))
                {
                    FireBullet();
                }
                break;
        }
    }

    void ChangeBulletType()
    {
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentBulletType = BulletType.Straight;
        }
        else if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            CurrentBulletType = BulletType.SineWave;
        }

        switch (CurrentBulletType)
        {
            case BulletType.Straight:
                _currentBulletPrefab = StraightBulletPrefab;
                break;
            case BulletType.SineWave:
                _currentBulletPrefab = WaveBulletPrefab;
                break;
        }
    }
}
