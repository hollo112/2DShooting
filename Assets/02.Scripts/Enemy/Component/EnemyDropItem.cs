using UnityEngine;

public class EnemyDropItem : MonoBehaviour
{
    [Header("아이템 프리팹")]
    public GameObject[] ItemPrefabs;
    [Header("아이템별 드랍 확률")]
    public float[] ItemRandomWeight;
    [Header("아이템 드랍 확률")]
    public float DropPercent = 50f;


    public void DropItem()
    {
        if (Random.Range(0f, 100f) > DropPercent)
            return;

        GameObject dropPrefab = ChooseRandomItem();
        if(dropPrefab != null )
        {
            Instantiate(dropPrefab, transform.position, Quaternion.identity);
        }
    }

    private GameObject ChooseRandomItem()
    {
        float totalWeight = 0f;
        foreach (float itemWeight in ItemRandomWeight)
        {
            totalWeight += itemWeight;
        }

        float randomValue = Random.Range(0f, totalWeight);
        float cumulativeWeight = 0f;

        for (int i = 0; i < ItemRandomWeight.Length; i++)
        {
            cumulativeWeight += ItemRandomWeight[i];
            if (randomValue <= cumulativeWeight)
            {
                
                return ItemPrefabs[i];
            }
        }

        return null;
    }
}
