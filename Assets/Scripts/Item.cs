using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public ItemMetaData MetaData;
    public int Amount;

    public Item(ItemMetaData metaData, int amount)
    {
        MetaData = metaData;
        Amount = amount;
    }
}
