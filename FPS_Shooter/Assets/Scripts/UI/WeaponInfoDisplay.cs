using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class WeaponInfoDisplay : MonoBehaviour
{
    [Header("Bullet UI")]
    [SerializeField] private TMP_Text _currentBullet;
    [SerializeField] private TMP_Text _allBullet;
    [Header("Weapon Info UI")]
    [SerializeField] private Text _weaponStateInfo;
    [SerializeField] private string _notBulletText;
    [SerializeField] private string _reloadText;
    [SerializeField] private float _animationTime;

    [SerializeField] private PlayerShoot _player;

    private Color _defoltColorText;

    private void OnEnable()
    {
        _weaponStateInfo.enabled = false;
        _defoltColorText = _weaponStateInfo.color;

        _player.OnChangeWeapon += ChangeWeapon;
    }

    private void OnDisable()
    {
        _player.CurrentWeapon.ChangeBullet -= DisplayBullets;
        _player.CurrentWeapon.ChangeBullet -= ShowNoBulletText;
        _player.CurrentWeapon.Reloading -= ShowReloadText;

        _player.OnChangeWeapon -= ChangeWeapon;      
    }

    private void ChangeWeapon()
    {
        _player.CurrentWeapon.ChangeBullet += DisplayBullets;
        _player.CurrentWeapon.ChangeBullet += ShowNoBulletText;
        _player.CurrentWeapon.Reloading += ShowReloadText;

        StopWeaponAnimation();
    }

    private void DisplayBullets(int currentBullet)
    {
        _currentBullet.text = currentBullet.ToString();
        _allBullet.text = _player.AllBullet.ToString();
    }

    private void ShowReloadText(int bullet, bool isReloading) 
    {
        StopWeaponAnimation();

        if (isReloading)
            SetText(_reloadText);
    }

    private void ShowNoBulletText(int bullet) 
    {
        StopWeaponAnimation();

        if (bullet <= 0)
            SetText(_notBulletText);
    }

    private void SetText(string text)
    {
        _weaponStateInfo.enabled = true;

        _weaponStateInfo.text = text;
        _weaponStateInfo.DOFade(0, _animationTime).SetLoops(-1, LoopType.Yoyo);
    }

    private void StopWeaponAnimation()
    {
        _weaponStateInfo.DOKill();

        _weaponStateInfo.enabled = false;
        _weaponStateInfo.color = _defoltColorText;
    }
}
