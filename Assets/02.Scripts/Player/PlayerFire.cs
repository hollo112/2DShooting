using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("총알 프리팹")]
    public GameObject StraightBulletPrefab;
    public GameObject SubBulletPrefab;
    public GameObject WaveBulletPrefab;
    public GameObject CircleBulletPrefab;
    public GameObject HeartBulletPrefab;
    private GameObject _currentMainBulletPrefab;

    [Header("발사 위치")]
    public Transform FirePositionLeft;
    public Transform FirePositionRight;
    public Transform[] SubFirePosition;

    [Header("발사 간격")]
    private float _cooltime = 0.8f;
    private const float _minCooltime = 0.3f;
    private float _fireTimer = 0f;

    public enum FireType
    {
        Auto = 1,
        Manual = 2,
    }

    public enum BulletType
    {
        Straight = 1,
        Wave = 2,
        Circle = 3,
        Heart = 4,
    }

    [Header("공격 모드")]
    public FireType CurrentFireType = FireType.Auto; // 1: 자동, 2: 수동
    public BulletType CurrentBulletType = BulletType.Straight;
    private void Start()
    {
        
    }

    private void Update()
    {
        ChangeFireMode();
        ChangeBulletType();
        //FireBullet();
    }

    private void FireBullet()
    {
        _fireTimer += Time.deltaTime;
        if (_fireTimer < _cooltime)
        {
            return;
        }

        MakeMainBullet();
        MakeSubBullet();

        _fireTimer = 0f;
    }

    private void ChangeFireMode()
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

    private void ChangeBulletType()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            CurrentBulletType = BulletType.Straight;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            CurrentBulletType = BulletType.Wave;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            CurrentBulletType = BulletType.Circle;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            CurrentBulletType = BulletType.Heart;
        }
        switch (CurrentBulletType)
        {
            case BulletType.Straight:
                _currentMainBulletPrefab = StraightBulletPrefab;
                break;
            case BulletType.Wave:
                _currentMainBulletPrefab = WaveBulletPrefab;
                break;
            case BulletType.Circle:
                _currentMainBulletPrefab = CircleBulletPrefab;
                break;
            case BulletType.Heart:
                _currentMainBulletPrefab = HeartBulletPrefab;
                break;
        }
    }

    private void MakeMainBullet()
    {
        GameObject leftBullet = Instantiate(_currentMainBulletPrefab, FirePositionLeft.position, Quaternion.identity);
        ChangeBulletSide(leftBullet, false);
        GameObject rightBullet = Instantiate(_currentMainBulletPrefab, FirePositionRight.position, Quaternion.identity);
        ChangeBulletSide(rightBullet, true);
    }

    private void ChangeBulletSide(GameObject bullet, bool _isRight)
    {
        if(CurrentBulletType is BulletType.Heart)
        {
            HeartBullet heartBullet = bullet.GetComponent<HeartBullet>();
            if(_isRight)
            {
                heartBullet._isRight = true;
            }
            else
            {
                heartBullet._isRight = false;
            }
        }
    }
    private void MakeSubBullet()
    {
        foreach (Transform pos in SubFirePosition)
        {
            Instantiate(SubBulletPrefab, pos.position, Quaternion.identity);
        }
    }

    public void FireSpeedUp(float value)
    {
        _cooltime -= value;
        _cooltime = Mathf.Max(_cooltime, _minCooltime);
    }
}
