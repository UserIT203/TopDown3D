using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private float _interactDistance;
    [SerializeField] private Transform _target;

    protected bool _hasInteract = false;

    private void Update()
    {
        if (_target == null)
            return;

        float distance = Vector3.Distance(transform.position, _target.position);

        if(_interactDistance >= distance)
        {
            _hasInteract = true;
            Interact();
        }
        else
        {
            _hasInteract = false;
        }
    }

    protected virtual void Interact()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _interactDistance);
    }
}
