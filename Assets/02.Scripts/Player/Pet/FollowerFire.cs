using UnityEngine;
using static UnityEditor.PlayerSettings;

public class FollowerFire : MonoBehaviour
{

    [Header("발사 위치")]
    public Transform FirePositionLeft;

    [Header("발사 간격")]
    private float _cooltime;
    private float _minCooltime = 4f;
    private float _maxCooltime = 7f;
    private float _fireTimer = 0f;

    // Update is called once per frame
    private void Update()
    {
        FireBullet();
    }

    private void FireBullet()
    {
        _fireTimer += Time.deltaTime;
        if (_fireTimer < _cooltime)
        {
            return;
        }
        MakeBullet();

        _fireTimer = 0f;
        RandomCooltime();
    }

    private void MakeBullet()
    {
        BulletFactory.Instance.MakeBullet(EBulletType.PetBullet, FirePositionLeft.position);
    }

    private void RandomCooltime()
    {
        _cooltime = Random.Range(_minCooltime, _maxCooltime);
    }
}
