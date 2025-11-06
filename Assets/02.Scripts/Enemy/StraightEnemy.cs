using UnityEngine;

public class StraightEnemy : Enemy
{
    protected override void Update()
    {
        base.Update();
    }
    protected override void MoveEnemy()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * Speed * Time.deltaTime);
    }
}
