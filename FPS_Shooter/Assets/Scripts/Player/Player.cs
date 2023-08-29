using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : HitObjecth
{
    public int Money { get; private set; }

    private PlayerShoot _playerShoot;

    public event UnityAction<float, float> HealthChange;

    private void Awake()
    {
        SetCurrentHealth();

        _playerShoot = GetComponent<PlayerShoot>();
    }

    public void BuyItem(Weapon item)
    {
        Money -= item.Price;

        if (item.IsBaff == false)
            _playerShoot.AddWeapon(item);
    }

    public override void ApplyDamage(float damage)
    {
        base.ApplyDamage(damage);
        HealthChange?.Invoke(_currentHealth, Health);
    }
}
