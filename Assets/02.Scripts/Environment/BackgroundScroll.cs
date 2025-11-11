using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    // 배경 스크롤
    // 필요 속성
    // -머터리얼
    // -스크롤 속도

    public Material  Material;
    public float ScrollSpeed = 0.1f;

    private void Start()
    {

    }

    private void Update()
    {
        Vector2 direction = Vector2.up;
        Material.mainTextureOffset += direction * ScrollSpeed * Time.deltaTime;
    }
}
