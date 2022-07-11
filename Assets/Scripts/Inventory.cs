using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Inventory : MonoBehaviour
{
    public Dictionary<uint, Item> Items;
    public GameObject ItemPanelPrefab;
    public GameObject ItemContainerPrefab;
    public GameObject InventoryPanel;
    private Dictionary<uint, GameObject> ItemPanels;
    private void Awake()
    {
        Items = new Dictionary<uint, Item>();
        ItemPanels = new Dictionary<uint, GameObject>();
    }

    public void Add(Item item)
    {
        var id = item.MetaData.ID;
        if (Items.TryAdd(id, item))
        {
            CreatePanel(item);
        }
        else
        {
            Items[id].Amount += item.Amount;
            UpdatePanelText(Items[id]);
        }
    } 

    public bool Contains(uint id)
    {
        return Items.ContainsKey(id);
    }

    public Item Remove(uint id)
    {
        if (!Items.ContainsKey(id))
            return null;
        var item = Items[id];
        var itemPanel = ItemPanels[id].GetComponent<ItemPanel>();
        if (item.Amount > 1)
        {
            item.Amount -= 1;
            UpdatePanelText(item);
        }
        else
        {
            Items.Remove(id);
            Destroy(itemPanel.gameObject);
            ItemPanels.Remove(id);
        }
        return item.MetaData.CreateItem(1);
    }

    private void CreatePanel(Item item)
    {
        var id = item.MetaData.ID;
        ItemPanels.Add(item.MetaData.ID, Instantiate(ItemPanelPrefab, InventoryPanel.transform));
        var itemPanel = ItemPanels[id].GetComponent<ItemPanel>();
        itemPanel.SetIcon(item.MetaData.Icon);
        itemPanel.ItemID = id;
        itemPanel.LeftClick += PanelLeftClick;
        itemPanel.RightClick += PanelRightClick;
        UpdatePanelText(item);
    }

    private void UpdatePanelText(Item item)
    {
        var itemPanel = ItemPanels[item.MetaData.ID].GetComponent<ItemPanel>();
        var newText = item.MetaData.Name;
        if (item.Amount > 1)
            newText += $" - {item.Amount}";
        itemPanel.SetText(newText);
    } 

    private void PanelLeftClick(uint id)
    {
        var item = Items[id];
        if (item is Consumable)
        {
            if (((Consumable)item).Use(gameObject))
            {
                Remove(id);
            }
        }
    }

    private void PanelRightClick(uint id)
    {
        var item = Remove(id);
        var container = Instantiate(ItemContainerPrefab).GetComponent<ItemContainer>();
        container.Item = item.MetaData;
        container.Amount = 1;
        container.transform.position = transform.position;
        container.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
    }

    private void OnDestroy()
    {
        foreach(var panel in ItemPanels.Values)
        {
            Destroy(panel);
        }
    }
}
