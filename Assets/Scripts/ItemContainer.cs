using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemContainer : MonoBehaviour
{
    public ItemMetaData Item;
    public int Amount;
    SpriteRenderer Sprite;
    private void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        Sprite.sprite = Item.Icon;
    }

    public void PickUp(GameObject sender)
    {
        sender.GetComponent<Inventory>().Add(Item.CreateItem(Amount));
        Destroy(gameObject);
    }
}
