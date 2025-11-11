using UnityEngine;

public class PlayerMakeBoom : MonoBehaviour
{
    [Header("생성 위치")]
    private float _positionX = 0f;
    private float _positionY = 0f;

    [Header("Boom 프리팹")]
    public GameObject BoomPrefab;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.B))
        {
            MakeBomb();
        }
    }

    private void MakeBomb()
    {
        if (BoomPrefab == null) return;
        Vector2 boomPosition = new Vector2(_positionX, _positionY);
        Instantiate(BoomPrefab, boomPosition, Quaternion.identity);
    }
}
