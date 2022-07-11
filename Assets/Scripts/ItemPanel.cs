using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemPanel : MonoBehaviour, IPointerClickHandler
{
    private TextMeshProUGUI Text;
    private Image Icon;
    public uint ItemID;
    public event Action<uint> LeftClick;
    public event Action<uint> MiddleClick;
    public event Action<uint> RightClick;
    public void OnPointerClick(PointerEventData eventData)
    {
        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                LeftClick?.Invoke(ItemID);
                break;
            case PointerEventData.InputButton.Middle:
                MiddleClick?.Invoke(ItemID);
                break;
            case PointerEventData.InputButton.Right:
                RightClick?.Invoke(ItemID);
                break;
        }
    }
    private void Awake()
    {
        Text = GetComponentInChildren<TextMeshProUGUI>();
        Icon = transform.Find("Icon").GetComponent<Image>();
    }

    public void SetText(string text)
    {
        Text.text = text;
    }

    public void SetIcon(Sprite sprite)
    {
        Icon.sprite = sprite;
    }
}
