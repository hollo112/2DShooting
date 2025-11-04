using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [Header("탄환 속도")]
    protected float Speed;

    public enum BulletDirection
    {
        Up,
        Down,
        Left,
        Right
    }

    [Header("탄환 이동방향")]
    public BulletDirection Direction = BulletDirection.Up;

    protected virtual void Start()
    {
        
    }

    protected virtual void Update()
    {
        MoveBullet();
    }

    protected Vector2 GetDirection(BulletDirection direction)
    {
        switch(direction)
        {
            case BulletDirection.Up:
                return Vector2.up;
            case BulletDirection.Down:
                return Vector2.down;
            case BulletDirection.Left:
                return Vector2.left;
            case BulletDirection.Right:
                return Vector2.right;
            default:
                return Vector2.up;
        }
    }

    public abstract void MoveBullet();
}
