using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Generic,
    Consumable,
    Weapon
}

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item", order = 1)]
public class ItemMetaData : ScriptableObject
{
    public ItemType ItemType;
    public uint ID;
    public string Name;
    public float Weight;
    public Sprite Icon;
    public virtual Item CreateItem(int amount)
    {
        return new Item(this, amount);
    }
}
