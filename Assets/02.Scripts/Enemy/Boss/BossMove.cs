using UnityEngine;

public class BossMove : Movement
{
    private float _stopPositionX = 0f;
    private float _stopPositionY = 4.35f;
    protected override void Move()
    {
        if (transform.position.y <= _stopPositionY)   {return;} 
        Vector2 direction = Vector2.down;
        transform.Translate(direction * Speed * Time.deltaTime);
    }
}
