using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Predator : MonoBehaviour
{
    public PredatorState CurrentState;
    public static List<Predator> Predators = new List<Predator>();
    [SerializeField] int FieldOfView, FieldOfAttack;
    [Range(5, 15)] public int DangerosityIndex;
    public NavMeshAgent NavMeshAgent { get; private set; }


    private void Update()
    {
        CurrentState.Transition();
        if (!CurrentState.SetUpDone)
        { CurrentState.SetUp();
            CurrentState.SetUpDone = true;
        }
        CurrentState.Do();
    }

    private void Awake()
    {
        Predators.Add(this);
        DangerosityIndex = Random.Range(5, 15);
        FieldOfAttack = DangerosityIndex / 2;
        FieldOfView = DangerosityIndex + 2;
        NavMeshAgent = GetComponent<NavMeshAgent>();
        CurrentState = new Patroi(this);
    }

    private void OnDestroy()
    {
        Predators.Remove(this);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, FieldOfView);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FieldOfAttack);
    }
}