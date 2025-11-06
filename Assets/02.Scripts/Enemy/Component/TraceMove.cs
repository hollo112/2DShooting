using UnityEngine;

public class TraceMove : Movement
{
    private GameObject _playerObject;
    
    private void Start()
    {
        _playerObject = GameObject.FindWithTag("Player");    
    }
    protected override void Move()
    {
        GameObject PlayerObject = _playerObject;

        if (PlayerObject == null) return;

        Vector2 direction = PlayerObject.transform.position - transform.position;
        direction.Normalize();
        transform.Translate(direction * Speed * Time.deltaTime);
    }
}
