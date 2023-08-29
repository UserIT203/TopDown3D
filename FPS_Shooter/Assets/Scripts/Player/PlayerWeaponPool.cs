using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(PlayerShoot))]
public class PlayerWeaponPool : MonoBehaviour
{
    private List<GameObject> _weaponsTemplate = new List<GameObject>();

    public void InitializedWeapon(List<Weapon> weapons, Transform container)
    {
        foreach (var weapon in weapons)
        {
            CreateWeapon(weapon, container);
        }
    }

    public void CreateWeapon(Weapon weapon, Transform container)
    {
        GameObject weaponTemplate = Instantiate(weapon.gameObject, Vector3.zero, Quaternion.identity);
        weaponTemplate.GetComponent<Weapon>().Init();

        weaponTemplate.SetActive(false);
        weaponTemplate.transform.SetParent(container);
        weaponTemplate.transform.localPosition = new Vector3(0, 0, 0.5f);
        weaponTemplate.transform.localRotation = Quaternion.identity;

        _weaponsTemplate.Add(weaponTemplate.gameObject);
    }

    public Weapon SetWeapon(int weaponNumber)
    {
        Reset();

        _weaponsTemplate[weaponNumber].SetActive(true);
        return _weaponsTemplate[weaponNumber].GetComponent<Weapon>();
    }

    private void Reset()
    {
        foreach (var weapon in _weaponsTemplate)
            weapon.SetActive(false);
    }
}
