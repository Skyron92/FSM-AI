using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class MyFSMAI : MonoBehaviour
{
    public MyState CurrentState;
    [SerializeField] int SightRange;
     public NavMeshAgent NavMeshAgent { get; private set; }
     private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        CurrentState = new MyWait(this);
    }

     private void Update()
     {
         CurrentState.Transition();
         if (!CurrentState.SetupDone)
         {
             CurrentState.SetUp();
             CurrentState.SetupDone = true;
         }
         CurrentState.Do();
     }

     private void OnDrawGizmos()
     {
         Gizmos.color = Color.red;
         Gizmos.DrawWireSphere(transform.position, SightRange);
     }

     public List<Ennemy> EnnemiesInRanges()
     {
         List<Ennemy> inRange = new List<Ennemy>();
         foreach (Ennemy ennemy in Ennemy.Ennemies)
         {
             if (Vector3.Distance(ennemy.transform.position, transform.position) <= SightRange) inRange.Add(ennemy);
             inRange = inRange.OrderBy(ennemy => Vector3.Distance(ennemy.transform.position, transform.position)).ToList();
         }
         return inRange;
     }
}