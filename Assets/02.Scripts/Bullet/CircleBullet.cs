using UnityEngine;

public class CircleBullet : Bullet
{
    [Header("이동 속도")]
    public float SpeedValue = 5f;

    [Header("회전 속성")]
    public float AngularSpeed = 2f; // 회전 속도 (라디안/초)
    public float Radius = 2f;       // 원의 반지름

    private float _angle = 0f; // 현재 각도
    private Vector2 _centerPosition;

    protected override void Start()
    {
        base.Start();
        _centerPosition = transform.position;
    }

    public override void MoveBullet()
    {
        _angle += AngularSpeed * Time.deltaTime;

        // 기본이동
        Vector2 direction = GetDirection(Direction);
        _centerPosition += direction * SpeedValue * Time.deltaTime;

        float x = _centerPosition.x + Mathf.Cos(_angle) * Radius;
        float y = _centerPosition.y + Mathf.Sin(_angle) * Radius;

        Vector2 newPosition = new Vector2(x, y);
        transform.position = newPosition;
    }
}
