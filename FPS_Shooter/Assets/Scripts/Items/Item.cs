using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [Header("UI Component")]
    [SerializeField] private string _label;
    [SerializeField] private int _price;
    [SerializeField] private Sprite _icon;
    [SerializeField] protected bool _isBuyed = false;

    [SerializeField] private bool _isBaff = false;

    public string Label => _label;
    public int Price => _price;
    public Sprite Icon => _icon;
    public bool IsBaff => _isBaff;
    public bool IsBuyed => _isBuyed;

    public void Buy()
    {
        _isBuyed = true;
    }
}
