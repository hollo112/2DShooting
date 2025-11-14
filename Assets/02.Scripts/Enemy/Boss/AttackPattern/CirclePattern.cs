using UnityEngine;

public class CirclePattern: IBossPattern
{
    public float FireInterval => 0.6f;
    public float PatternDuration => 6f;
    public float RestTime => 5f;
    public void Execute(Transform firePoint)
    {
        BulletFactory.Instance.MakeBullet(EBulletType.BossCircle, firePoint.position, false);
    }
}
