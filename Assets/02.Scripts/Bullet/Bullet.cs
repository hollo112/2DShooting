using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("이동속도")]
    public float FirstSpeed = 1f;
    public float LastSpeed = 7f;
    private float _speed;

    [Header("가속시간")]
    public float AccerationTime = 1.2f;
    private float _elapsedTime = 0f;

    void Start()
    {
        _speed = FirstSpeed;
    }

    void Update()
    {
        AccelerateBullet();
        //AccelerateBullet2();
        MoveBullet();
    }

    void AccelerateBullet()
    {
        if (_elapsedTime < AccerationTime)
        {
            _elapsedTime += Time.deltaTime;
            float t = _elapsedTime / AccerationTime; // 0 ~ 1
            _speed = Mathf.Lerp(FirstSpeed, LastSpeed, t);
        }
    }

    void AccelerateBullet2()
    {
        float acceleration = (LastSpeed - FirstSpeed) / AccerationTime;
        _speed += acceleration * Time.deltaTime;
        _speed = Mathf.Min(_speed, LastSpeed);
    }

    void MoveBullet()
    {
        Vector2 position = transform.position;
        Vector2 newPosition = position + Vector2.up * _speed * Time.deltaTime;
        transform.position = newPosition;
    }
}
