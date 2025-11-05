using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [Header("탄환 속도")]
    [SerializeField]protected float Speed = 6f;
    [Header("탄환 데미지")]
    [SerializeField]protected float Damage = 60f;
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

    public void OnTriggerEnter2D(Collider2D other)
    {
        DamageEnemy(other.gameObject);
    }

    private void DamageEnemy(GameObject target)
    {
        if (target.CompareTag("Enemy") == false) return;

        Enemy enemy = target.GetComponent<Enemy>();
        enemy.TakeDamage(Damage);
        
        Destroy(gameObject);
    }
}
