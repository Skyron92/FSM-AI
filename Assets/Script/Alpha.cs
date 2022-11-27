using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Alpha : MonoBehaviour
{

    public AlphaState CurrentState;
    public static List<Alpha> Alphas = new List<Alpha>();
    [SerializeField] private float FieldOfAlpha, FieldOfView, FieldOfAttack;
    [SerializeField] public GameObject prefabBlue;
    public NavMeshAgent NavMeshAgent { get; private set; }
    private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        CurrentState = new AlphaPatroi(this);
        CurrentState.isAnAlpha = true;
        Alphas.Add(this);
    }

    private void OnDestroy()
    {
        Alphas.Remove(this);
    }

    private void Update()
    { CurrentState.Transition();
        if (!CurrentState.setUpDone)
        { CurrentState.SetUp();
            CurrentState.setUpDone = true; }
        CurrentState.Do(); }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, FieldOfAlpha);
        
        
    }
}