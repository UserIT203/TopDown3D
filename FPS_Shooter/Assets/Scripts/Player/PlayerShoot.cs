using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(PlayerWeaponPool))]
public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private Weapon _currentWeapon;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _weaponPosition;
    [SerializeField] private int _allBullet;
    [SerializeField] private Camera _mainCamera;
    [Header("Grenade")]
    [SerializeField] private Grenade _grenadeTemplate;
    [SerializeField] private int _grenadeCount;

    private PlayerInput _input;
    private PlayerWeaponPool _weaponPool;

    private Vector3 _mousePosition;
    
    private int _currentWeaponNumber = 0;
    private Coroutine _reloadCorotine;
    private int _currentGrenadeCount;

    public int AllBullet => _allBullet;

    public Weapon CurrentWeapon => _currentWeapon;

    public event UnityAction OnChangeWeapon;

    private void Awake()
    {
        _currentGrenadeCount = _grenadeCount;

        _weaponPool = GetComponent<PlayerWeaponPool>();
        ConnectPlayerInput();

        _weaponPool.InitializedWeapon(_weapons, _weaponPosition);
        ChangeWeapon();
    }

    public void AddWeapon(Weapon weapon)
    {
        _weapons.Add(weapon);
        _weaponPool.CreateWeapon(weapon, _weaponPosition);
    }

    private void ConnectPlayerInput()
    {
        _input = new PlayerInput();
        _input.Enable();

        _input.Player.Shoot.performed += ctx => TryShoot(_input);
        _input.Player.NextWeapon.performed += ctx => NextWeapon();
        _input.Player.PreviousWeapon.performed += ctx => PreviousWeapon();
        _input.Player.ReloadWeapon.performed += ctx => Reload();
        _input.Player.ThrowGrenade.performed += ctx => TryThrowGrenade(_grenadeTemplate.gameObject);
    }

    private void TryShoot(PlayerInput input)
    {
        if (_mainCamera == null || Time.timeScale == 0)
            return;

        _mousePosition = input.Player.Look.ReadValue<Vector2>();
        _mousePosition.z = _mainCamera.nearClipPlane + 1;

        Ray cameraRay = _mainCamera.ScreenPointToRay(_mousePosition);
        Vector3 point = cameraRay.GetPoint(100);

        _currentWeapon.Shoot(_weaponPosition, point);
    }

    private void TryReloading(int neededBullet, bool isReloading)
    {
        if(isReloading == false)
            _allBullet -= neededBullet;
    }

    private void Reload()
    {
        _reloadCorotine = StartCoroutine(_currentWeapon.TryReloading(_allBullet));
    }

    private void TryThrowGrenade(GameObject grenade)
    {
        if (_currentGrenadeCount == 0 || gameObject == null)
            return;

        GameObject spawned = Instantiate(grenade, transform.position, Quaternion.identity);
        spawned.GetComponent<Grenade>().Throw(transform.forward);

        _currentGrenadeCount--;
    }

    private void NextWeapon()
    {
        if (_currentWeaponNumber == _weapons.Count - 1)
            _currentWeaponNumber = 0;
        else
            _currentWeaponNumber++;

        ChangeWeapon();
    }

    private void PreviousWeapon()
    {
        if (_currentWeaponNumber == 0)
            _currentWeaponNumber = _weapons.Count - 1;
        else
            _currentWeaponNumber--;

        ChangeWeapon();
    }

    private void ChangeWeapon()
    {
        if (_currentWeapon != null)
            _currentWeapon.Reloading -= TryReloading;

        if (_reloadCorotine != null)
            StopCoroutine(_reloadCorotine);

        _currentWeapon = _weaponPool.SetWeapon(_currentWeaponNumber);
        _currentWeapon.Reloading += TryReloading;

        OnChangeWeapon?.Invoke();
        _currentWeapon.TakeGun();
    }
}
