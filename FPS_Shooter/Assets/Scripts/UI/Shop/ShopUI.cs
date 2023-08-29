using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private List<Item> _item;
    [SerializeField] private Player _player;
    [SerializeField] private ShopItem _template;
    [SerializeField] private GameObject _itemContainer;

    private void Start()
    {
        gameObject.SetActive(false);

        for (int i = 0; i < _item.Count; i++)
        {
            AddItem(_item[i]);
        }
    }

    private void AddItem(Item item)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClick;
        view.Render(item);
    }

    private void OnSellButtonClick(Item item, ShopItem shopItem)
    {
        TrySellItem(item, shopItem);
    }

    private void TrySellItem(Item item, ShopItem shopItem)
    {
        if (item.Price <= _player.Money)
        {
            _player.BuyItem(item.GetComponent<Weapon>());
            item.Buy();
            shopItem.SellButtonClick -= OnSellButtonClick;
        }
    }
}
