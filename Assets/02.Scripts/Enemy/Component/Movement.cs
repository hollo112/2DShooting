using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    [Header("이동 속도")]
    public float Speed = 2.0f;

    private void Update()
    {
        Move();    
    }

    protected abstract void Move();
}
