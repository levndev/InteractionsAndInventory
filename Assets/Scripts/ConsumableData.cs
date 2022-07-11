using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ConsumableType
{
    Restoration,
    Buff
}

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Consumable", order = 2)]
public class ConsumableData : ItemMetaData
{
    public ConsumableType ConsumableType;
    public float RestoreAmount;
    public override Item CreateItem(int amount)
    {
        return new Consumable(this, amount);
    }
}
