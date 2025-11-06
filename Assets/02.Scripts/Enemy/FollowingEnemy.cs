using UnityEngine;

public class FollowingEnemy : Enemy
{
    void Start()
    {
        
    }

    protected override void Update()
    {
       base.Update();
    }

    protected override void MoveEnemy()
    {
        // 1. 플레이어의 위치를 구한다
        GameObject PlayerObject = GameObject.FindWithTag("Player");

        // 2. 위치에 따라 방향을 구한다
        Vector2 direction = PlayerObject.transform.position - transform.position;
        // 3. 방향에 맞게 이동한다
        direction.Normalize();
        transform.Translate(direction * Speed * Time.deltaTime);
    }
}
