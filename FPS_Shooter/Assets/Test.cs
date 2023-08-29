using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class InstantiateBulletsShooting : MonoBehaviour
{
    [SerializeField] private GameObject _template;
    [SerializeField] private float _timeWaitShooting;

    public float BulletSpeed;
    public Transform ObjectToShoot;

    private void Start()
    {
        StartCoroutine(ShootingWorker());
    }

    private IEnumerator ShootingWorker()
    {
        bool isWork = enabled;

        while (isWork)
        {
            var _vector3direction = (ObjectToShoot.position - transform.position).normalized;
            var newBullet = Instantiate(_template, transform.position + _vector3direction, Quaternion.identity);

            newBullet.GetComponent<Rigidbody>().transform.up = _vector3direction;
            newBullet.GetComponent<Rigidbody>().velocity = _vector3direction * BulletSpeed;

            yield return new WaitForSeconds(_timeWaitShooting);
        }
    }
}