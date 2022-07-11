using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumable : Item
{
    public Consumable(ConsumableData data, int amount) : base(data, amount)
    {
    }

    public bool Use(GameObject player)
    {
        var data = MetaData as ConsumableData;
        if (data.ConsumableType == ConsumableType.Restoration)
        {
            var health = player.GetComponent<Health>();
            if (health.Current == health.Max)
            {
                return false;
            }
            health.Replenish(data.RestoreAmount);
            return true;
        }
        return false;
    }
}
