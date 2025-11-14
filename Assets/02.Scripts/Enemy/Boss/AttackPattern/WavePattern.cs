using UnityEngine;

public class WavePattern : IBossPattern
{
    public float FireInterval => 0.4f;
    public float PatternDuration => 6f;
    public float RestTime => 3f;
    public void Execute(Transform firePoint)
    {
        BulletFactory.Instance.MakeBullet(EBulletType.BossWave, firePoint.position, false);
    }
}
