using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [Header("총알 프리팹")]
    public GameObject BulletPrefab;

    [Header("발사 위치")]
    public Transform FirePosition;

    void Start()
    {
        
    }

    void Update()
    {
        FireBullet();
    }

    void FireBullet()
    {
        if(Input.GetKey(KeyCode.Space))
        {
            GameObject bullet = Instantiate(BulletPrefab);
            bullet.transform.position = FirePosition.position;
        }
    }
}
