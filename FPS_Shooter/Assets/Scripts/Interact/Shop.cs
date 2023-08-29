using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shop : Interactable
{
    [SerializeField] private UnityEvent _openShopEvent;

    private ShopInput _input;

    private void Start()
    {
        _input = new ShopInput();
        _input.Enable();

        _input.Shop.OpenShop.performed += ctx => OnOpenShop();
    }

    private void OnOpenShop()
    {
        if(_hasInteract)
            _openShopEvent?.Invoke();
    }
}
