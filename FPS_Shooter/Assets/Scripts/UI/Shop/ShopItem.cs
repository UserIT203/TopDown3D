using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;

public class ShopItem : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;

    private Item _item;

    public event UnityAction<Item, ShopItem> SellButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnButtonClick);
        _sellButton.onClick.AddListener(TryLockItem);
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(OnButtonClick);
        _sellButton.onClick.RemoveListener(TryLockItem);
    }

    public void Render(Item weapon)
    {
        _item = weapon;

        _label.text = _item.Label;
        _price.text = _item.Price.ToString();
        _icon.sprite = _item.Icon;
    }

    private void TryLockItem()
    {
        if (_item.IsBuyed)
            _sellButton.interactable = false;
    }

    private void OnButtonClick()
    {
        SellButtonClick?.Invoke(_item, this);
    }
}