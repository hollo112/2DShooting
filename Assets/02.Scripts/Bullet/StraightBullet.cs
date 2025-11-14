using UnityEngine;

public class StraightBullet : Bullet
{
    [Header("이동속도")]
    public float FirstSpeed ;
    public float LastSpeed ;
    //
    [Header("가속시간")]
    public float AccerationTime = 1.2f;
    private float _elapsedTime = 0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
    }

    private void OnEnable()
    {
        Speed = FirstSpeed;
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        AccelerateBullet();
    }
    private void AccelerateBullet()
    {
        if (_elapsedTime < AccerationTime)
        {
            _elapsedTime += Time.deltaTime;
            float t = _elapsedTime / AccerationTime; // 0 ~ 1
            Speed = Mathf.Lerp(FirstSpeed, LastSpeed, t);
        }
    }

    void AccelerateBullet2()
    {
        float acceleration = (LastSpeed - FirstSpeed) / AccerationTime;
        Speed += acceleration * Time.deltaTime;
        Speed = Mathf.Min(Speed, LastSpeed);
    }

    public override void MoveBullet()
    {
        Vector2 position = transform.position;
        Vector2 direction = GetDirection(Direction);
        Vector2 newPosition = position + direction * Speed * Time.deltaTime;
        transform.position = newPosition;
    }
}
