using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyStateMachine))]
public class MoveState : State
{
    private void Update()
    {
        Agent.SetDestination(Target.transform.position);
    }
}
