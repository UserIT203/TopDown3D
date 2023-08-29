using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Grenade : Item
{
    [Header("Own Parametrs")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private float _force;
    [SerializeField] private float _damage;
    [SerializeField] private float _timeToExplosion;
    [SerializeField] private float _explosionRadius;

    private Coroutine _explosionCoroutine;

    private void OnDestroy()
    {
        StopCoroutine(_explosionCoroutine);
    }

    public void Throw(Vector3 direction)
    {
        gameObject.SetActive(true);
        _rigidbody.AddForce(direction * _force, ForceMode.Impulse);

        _explosionCoroutine = StartCoroutine(Explosion());
    }

    private IEnumerator Explosion()
    {
        WaitForSeconds waitingTime = new WaitForSeconds(_timeToExplosion);

        yield return waitingTime;

        GiveDamage();
    }

    private void GiveDamage()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        foreach (var hit in hits)
        {
            if(hit.TryGetComponent(out HitObjecth hitObject))
            {
                hitObject.ApplyDamage(_damage);
            }
        }

        Destroy(gameObject);
    }
}
