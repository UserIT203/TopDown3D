using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransition : Transition
{
    [SerializeField] private float _lookRadius;

    private void Update()
    {
        NeedTransit = TrySeePlayer();
    }

    private bool TrySeePlayer()
    {
        if (Target == null)
            return false;

        float distance = Vector3.Distance(transform.position, Target.transform.position);

        if(distance <= _lookRadius && distance >= Agent.stoppingDistance)
        {
            Vector3 targetDirection = Target.transform.position - transform.position;

            Ray ray = new Ray(transform.position, targetDirection);
            
            if(Physics.Raycast(ray, out RaycastHit hitInfo, _lookRadius))
            {
                if(hitInfo.collider.TryGetComponent<Player>(out Player player))
                {
                    return true;
                }
            }

            Debug.DrawRay(ray.origin, ray.direction * _lookRadius, Color.red);
        }

        return false;
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _lookRadius);
    }
}
