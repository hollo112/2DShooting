using UnityEngine;

public class StraightPattern : IBossPattern
{
    public float FireInterval => 1f;
    public float PatternDuration => 10f;
    public float RestTime => 3f;
    
    private bool _isReversed = false;
    private float _firstDefault = 2f;
    private float _secondDefault = -0.5f;
    
    public void Execute(Transform firePoint)
    {
        float firstPos = _isReversed ? -_firstDefault : _firstDefault;
        float secondPos = _isReversed ? -_secondDefault : _secondDefault;

        Vector2 firstPoint = firePoint.position + new Vector3(firstPos, 0f);
        Vector2 secondPoint = firePoint.position + new Vector3(secondPos, 0f);

        BulletFactory.Instance.MakeBullet(EBulletType.BossStraight, firstPoint, false);
        BulletFactory.Instance.MakeBullet(EBulletType.BossStraight, secondPoint, false);

        
        _isReversed = !_isReversed;
    }
    
    
}
