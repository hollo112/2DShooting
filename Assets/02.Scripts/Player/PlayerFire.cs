using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("발사 위치")]
    public Transform FirePositionLeft;
    public Transform FirePositionRight;
    public Transform[] SubFirePosition;

    [Header("발사 간격")]
    private float _cooltime = 0.8f;
    private const float _minCooltime = 0.3f;
    private float _fireTimer = 0f;

    [Header("사운드")]
    public AudioSource FireSound;

    public enum FireType
    {
        Auto = 1,
        Manual = 2,
    }

    [Header("공격 모드")]
    public FireType CurrentFireType = FireType.Auto; // 1: 자동, 2: 수동
    public EBulletType CurrentBulletType = EBulletType.StraightBullet;
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

        FireSound.Play();

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
            CurrentBulletType = EBulletType.StraightBullet;
        }
        // else if (Input.GetKeyDown(KeyCode.Alpha4))
        // {
        //     CurrentBulletType = EBulletType.WaveBullet;
        // }
        // else if (Input.GetKeyDown(KeyCode.Alpha5))
        // {
        //     CurrentBulletType = EBulletType.CircleBullet;
        // }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            CurrentBulletType = EBulletType.HeartBullet;
        }
    }

    private void MakeMainBullet()
    {
        BulletFactory.Instance.MakeBullet(CurrentBulletType, FirePositionLeft.position, false);
        BulletFactory.Instance.MakeBullet(CurrentBulletType, FirePositionRight.position, true);
    }

    private void MakeSubBullet()
    {
        foreach (Transform pos in SubFirePosition)
        {
            BulletFactory.Instance.MakeBullet(EBulletType.SubBullet, pos.position, false);
        }
    }

    public void FireSpeedUp(float value)
    {
        _cooltime -= value;
        _cooltime = Mathf.Max(_cooltime, _minCooltime);
    }
}
