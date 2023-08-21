using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public enum ItemType
    {
        ExtraBomb,
        BastRadius,
        SpeedIncrease,
    }

    public ItemType Type;

    private void OnItemPickup(GameObject player)
    {
        switch (Type)
        {
            case ItemType.ExtraBomb:
                player.GetComponent<BombControler>().AddBomb();
                break;
            case ItemType.BastRadius:
                player.GetComponent<BombControler>().explosionRadius++;
                break;
            case ItemType.SpeedIncrease:
                player.GetComponent<PlayerMovment>().speed++;
                break;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) OnItemPickup(collision.gameObject);
    }

}
