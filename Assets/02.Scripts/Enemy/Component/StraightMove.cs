using UnityEngine;

public class StraightMove : Movement
{
    protected override void Move()
    {
        Vector2 direction = Vector2.down;
        transform.Translate(direction * Speed * Time.deltaTime);
    }
}
