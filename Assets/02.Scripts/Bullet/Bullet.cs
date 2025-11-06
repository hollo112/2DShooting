using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [Header("탄환 속도")]
    public float Speed = 6f;
    [Header("탄환 데미지")]
    public float Damage = 60f;

    private bool _isHit = false;
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
        Debug.Log(other.gameObject.name);
        DamageEnemy(other.gameObject);
        _isHit = true;
    }

    private void DamageEnemy(GameObject target)
    {
        if (target.CompareTag("EnemyHitBox") == false) return;
        if (_isHit)
        {   
            Destroy(gameObject);
            return;
        }
        Debug.Log("Enemy3");
        EnemyHitBox enemyHit = target.GetComponent<EnemyHitBox>();
        enemyHit.OnHit(Damage);
        
        Destroy(gameObject);
    }
}
