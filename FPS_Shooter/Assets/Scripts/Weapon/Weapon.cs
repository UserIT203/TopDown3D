using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Weapon : Item
{
    [Header("Weapon")]
    [SerializeField] private float _damage;
    [SerializeField] private float _damageDistance;
    [SerializeField] private int _bulletInMagazine;
    [SerializeField] private float _reloadTime;

    private int _currentBulletInMagazine;
    private bool _isReload = false;
    private bool _haveBullet = true;

    public bool IsRealod => _isReload;
    public bool HaveBullet => _haveBullet;

    public event UnityAction<int> ChangeBullet;
    public event UnityAction<int, bool> Reloading;

    private void OnEnable()
    {
        ChangeBullet?.Invoke(_currentBulletInMagazine);
    }

    private void OnDisable()
    {
        _isReload = false;
    }

    public void Init()
    {
        _currentBulletInMagazine = _bulletInMagazine;
    }

    public void TakeGun()
    {
        ChangeBullet?.Invoke(_currentBulletInMagazine);
    }

    public void Shoot(Transform shootPoint,Vector3 target)
    {
        if (target == null || shootPoint == null)
            return;

        if (_isReload == true)
            return;

        if(_currentBulletInMagazine <= 0)
        {
            _haveBullet = false;
            return;
        }

        Vector3 direction = new Vector3(target.x, shootPoint.position.y, target.z);
        Ray ray = new Ray(shootPoint.position, direction);

        if (Physics.Raycast(ray, out RaycastHit hitInfo, _damageDistance))
        {
            if (hitInfo.collider.TryGetComponent<HitObjecth>(out HitObjecth hitObjecth))
            {
                hitObjecth.ApplyDamage(_damage);
            }
        }

        _currentBulletInMagazine--;
        ChangeBullet?.Invoke(_currentBulletInMagazine);
    }

    public IEnumerator TryReloading(int playerBullet)
    {
        if(_currentBulletInMagazine == _bulletInMagazine || playerBullet == 0 || _isReload == true)
        {
            Debug.Log("Exit");
            yield break;
        }

        _haveBullet = true;
        _isReload = true;

        int neededBullet;
        neededBullet = _bulletInMagazine - _currentBulletInMagazine;

        Reloading?.Invoke(neededBullet, _isReload);
        WaitForSeconds waitingTime = new WaitForSeconds(_reloadTime);

        yield return waitingTime;

        _isReload = false;
        Reaload(playerBullet, neededBullet);
    }

    private void Reaload(int playerBullet, int neededBullet)
    {
        if (neededBullet > playerBullet)
            neededBullet = playerBullet;

        _currentBulletInMagazine += neededBullet;

        Reloading?.Invoke(neededBullet, _isReload);
        ChangeBullet?.Invoke(_currentBulletInMagazine);
    }
}
