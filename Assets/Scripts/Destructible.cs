using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour
{
    public float destructionTime = 1f;

    [Range(0f, 1f)]
    public float itemSpwanChance = 0.2f;
    public GameObject[] Items;

    private void Start()
    {
        Destroy(gameObject, destructionTime);
    }
    private void OnDestroy()
    {
        if (Items.Length > 0 && Random.value < itemSpwanChance)
        {
            int randomIndex = Random.Range(0, Items.Length);
            Instantiate(Items[randomIndex], transform.position, Quaternion.identity);
        }
    }
}
