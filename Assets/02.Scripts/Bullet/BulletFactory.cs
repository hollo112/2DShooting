using UnityEngine;

public enum EBulletType
{
    StraightBullet,
    SubBullet,
    WaveBullet,
    CircleBullet,
    HeartBullet,
    PetBullet,
}
public class BulletFactory : MonoBehaviour
{
    public static BulletFactory Instance { get; private set; }

    [Header("총알 프리팹")]
    public GameObject StraightBulletPrefab;
    public GameObject SubBulletPrefab;
    public GameObject WaveBulletPrefab;
    public GameObject CircleBulletPrefab;
    public GameObject HeartBulletPrefab;
    public GameObject PetBulletPrefab;
    private GameObject _bulletPrefab;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }
    public void MakeBullet(EBulletType bulletType, Vector3 position)
    {
        ChooseBullet(bulletType);
        Instantiate(_bulletPrefab, position, Quaternion.identity, transform);
    }

    public void MakeBullet(EBulletType bulletType, Vector3 position, bool isRight)
    {
        ChooseBullet(bulletType);
        GameObject bullet = Instantiate(_bulletPrefab, position, Quaternion.identity, transform);
        ChangeBulletSide(bullet, isRight);
    }

    private void ChooseBullet(EBulletType bulletType)
    {
        switch (bulletType)
        {
            case EBulletType.StraightBullet:
                _bulletPrefab = StraightBulletPrefab; break;
            case EBulletType.SubBullet:
                _bulletPrefab = SubBulletPrefab; break;
            case EBulletType.WaveBullet:
                _bulletPrefab = WaveBulletPrefab; break;
            case EBulletType.CircleBullet:
                _bulletPrefab = CircleBulletPrefab; break;
            case EBulletType.HeartBullet:
                _bulletPrefab = HeartBulletPrefab; break;
            case EBulletType.PetBullet:
                _bulletPrefab = PetBulletPrefab; break;
        }
    }

    private void ChangeBulletSide(GameObject bullet, bool _isRight)
    {
        HeartBullet heartBullet = bullet.GetComponent<HeartBullet>();
        if (heartBullet == null) return;
        if (_isRight)
        {
            heartBullet._isRight = true;
        }
        else
        {
            heartBullet._isRight = false;
        }
    }
}
