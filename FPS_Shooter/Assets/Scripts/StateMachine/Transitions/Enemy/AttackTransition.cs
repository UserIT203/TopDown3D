using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTransition : Transition
{
    private void Update()
    {
        float distance = Vector3.Distance(transform.position, Target.transform.position);

        if (distance <= Agent.stoppingDistance)
            NeedTransit = true;
    }
}
