using UnityEngine;

public class HeartBullet : Bullet
{
    [Header("하트방향")]
    public bool _isRight = true;
    [Header("하트속성")]
    public float Depth = 3f;
    public float Height = 1f;

    private float _elapsedTime = 0f; // 누적 시간
    private Vector2 _startPosition;
    private bool _heartLow = false;

    protected override void Start()
    {
        base.Start();
        _startPosition = transform.position;
    }

    public override void MoveBullet()
    {
        float delta = Time.deltaTime * Speed;
        _elapsedTime += _heartLow ? -delta : delta;
        _elapsedTime = Mathf.Clamp(_elapsedTime,0f, 1f);

        // 하트 계산
        // 하트 y좌표 계산
        float inputY = _elapsedTime;
        float sqrtPart = Mathf.Sqrt(1f - inputY * inputY);
        float yBase = Mathf.Abs(inputY) + (_heartLow ? -sqrtPart : sqrtPart);

        // 깊이/높이 조정
        float y = yBase * Depth - Height;
        float x = _elapsedTime;

        // 상태 전환 조건
        if (!_heartLow && _elapsedTime >= 1f)
        {
            _heartLow = true;
            _elapsedTime = 1f;
        }
        else if (_heartLow && _elapsedTime <= 0f)
        {
            gameObject.SetActive(false);
            return;
        }

        if(!_isRight)
        {
            x = -x;
        }

        Vector2 offset = Vector2.zero;
        switch (Direction)
        {
            case BulletDirection.Up:
                offset = new Vector2(x, -y);
                break;
            case BulletDirection.Down:
                offset = new Vector2(x, y); 
                break;
            case BulletDirection.Left:
                offset = new Vector2(-y, x);
                break;
            case BulletDirection.Right:
                offset = new Vector2(y, x); 
                break;
        }

        Vector2 newPosition = _startPosition + offset;
        transform.position = newPosition;
    }
}
