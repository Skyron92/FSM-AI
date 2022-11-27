using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Blue : MonoBehaviour
{
   public BlueState CurrentState;
   public static List<Blue> Blues = new List<Blue>();
   [SerializeField] private float FieldOfView, FieldOfAttack;
   public NavMeshAgent NavMeshAgent { get; private set; }
   public float distanceWithAlpha;
   public Vector3 AlphaPosition;

   private void Awake()
   { Blues.Add(this);
      NavMeshAgent = GetComponent<NavMeshAgent>();
      CurrentState = new BlueMove(this); }

   private void Update()
   {
      AlphaPosition = Alpha._transform.position;
      distanceWithAlpha = Vector3.Distance(Alpha._transform.position, transform.position);
      CurrentState.Transition();
      if (CurrentState.setUpDone)
      {CurrentState.SetUp();
         CurrentState.setUpDone = true; }
      CurrentState.Do(); }

   private void OnDestroy()
   { Blues.Remove(this); }

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.cyan;
      Gizmos.DrawWireSphere(transform.position, FieldOfView);

      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position, FieldOfAttack);
   }
}