using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Alpha : MonoBehaviour
{

    public AlphaState CurrentState;
    public static List<Alpha> Alphas = new List<Alpha>();
    [SerializeField] private float FieldOfAlpha, FieldOfView, FieldOfAttack;
    [SerializeField] public GameObject prefabBlue;
    public int chance;
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
    { chance = Random.Range(0, 10000);
        Debug.Log(chance);
        CurrentState.Transition();
        if (!CurrentState.setUpDone)
        { CurrentState.SetUp();
            CurrentState.setUpDone = true; }
        CurrentState.Do(); }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, FieldOfAlpha);
        
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, FieldOfView);
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FieldOfAttack);
        
    }
}