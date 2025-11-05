using UnityEngine;

public class HeartBullet : Bullet
{
    private float _elapsedTime = 0f; // 누적 시간
    private Vector2 _startPosition;
    protected override void Start()
    {
        base.Start();
        _startPosition = transform.position;
    }

    public override void MoveBullet()
    {
        // 누적 시간 증가
        _elapsedTime += Time.deltaTime;

        // 하트 계산
        float x = _elapsedTime;
        float inputY = Mathf.Clamp(_elapsedTime, -1f, 1f);
        float y = inputY + Mathf.Sqrt(1 - Mathf.Pow(inputY, 2));
        Vector2 perpendicular = Vector2.zero;
        switch (Direction)
        {
            case BulletDirection.Up:
            case BulletDirection.Down:
                perpendicular = new Vector2(x, y); 
                break;
            case BulletDirection.Left:
            case BulletDirection.Right:
                perpendicular = new Vector2(y, x); 
                break;
        }

        Vector2 newPosition = _startPosition + perpendicular;
        transform.position = newPosition;
    }
}
