using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BounceMove : Movement
{
    [Header("이동 범위")]
    public float MinX = -2.4f;
    public float MaxX = 2.4f;
    public float MinY = -5f;
    public float MaxY = 5f;

    private Vector2 _direction;

    private void Start()
    {
        _direction = new Vector2(Random.Range(-0.5f, 0.5f), -1f).normalized;
    }
    protected override void Move()
    {
        transform.Translate(_direction * Speed * Time.deltaTime);

        Vector2 position = transform.position;

        if (position.x <= MinX || position.x >= MaxX)
        {
            Bounce(Vector2.right);
            position.x = Mathf.Clamp(position.x, MinX, MaxX);
        }

        if (position.y <= MinY || position.y >= MaxY)
        {
            Bounce(Vector2.up);
            position.y = Mathf.Clamp(position.y, MinY, MaxY);
        }

        transform.position = position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Bullet") == true) { return; }

        Vector2 normal = (transform.position - collision.transform.position).normalized;
        Bounce(normal);
    }

    private void Bounce(Vector2 normal)
    {
        _direction = Vector2.Reflect(_direction, normal).normalized;
    }
}
