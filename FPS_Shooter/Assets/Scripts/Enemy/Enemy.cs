using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : HitObjecth
{
    [SerializeField] private Player _player;


    public NavMeshAgent Agent { get; private set; }
    public Player Player => _player;

    private void Awake()
    {
        Agent = GetComponent<NavMeshAgent>();
    }
}
