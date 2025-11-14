using UnityEngine;

public class WaveBullet : Bullet
{
    [Header("흔들림 속성")]
    public float ShakeAmplitude = 0.5f; // 흔들림 진폭
    public float ShakeFrequency = 5f;   // 흔들림 빈도

    private float _elapsedTime = 0f; // 누적 시간

    private Vector2 _startPosition;

    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable()
    {
        _elapsedTime = 0f;
        _startPosition = transform.position;
    }
    public override void MoveBullet()
    {
        // 누적 시간 증가
        _elapsedTime += Time.deltaTime;

        // 기본 이동
        Vector2 direction = GetDirection(Direction);
        Vector2 baseMove = direction * Speed * _elapsedTime;

        // 흔들림 계산
        float offset = Mathf.Sin(_elapsedTime * ShakeFrequency) * ShakeAmplitude;

        // 방향별 흔들림 적용
        Vector2 perpendicular = Vector2.zero;
        switch (Direction)
        {
            case BulletDirection.Up:
            case BulletDirection.Down:
                perpendicular = new Vector2(offset, 0); // 좌우 흔들림
                break;
            case BulletDirection.Left:
            case BulletDirection.Right:
                perpendicular = new Vector2(0, offset); // 상하 흔들림
                break;
        }
        // 최종 이동
        Vector2 newPosition = _startPosition + baseMove + perpendicular;
        transform.position = newPosition;
    }
}
