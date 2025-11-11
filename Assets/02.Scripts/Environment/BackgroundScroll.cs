using UnityEngine;

public class BackgroundScroll : MonoBehaviour
{
    // 배경 스크롤
    // 필요 속성
    // -머터리얼
    // -스크롤 속도

    private Material _material;

    void Start()
    {
        _material = GetComponent<Material>();    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
