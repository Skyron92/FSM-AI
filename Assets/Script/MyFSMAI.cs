using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Linq;

public class MyFSMAI : MonoBehaviour
{
    public MyState CurrentState;
    [SerializeField] float _hP = 20;
    [SerializeField] int SightRange;
     public NavMeshAgent NavMeshAgent { get; private set; }
     public Camera camera;
     public static List<MyFSMAI> FSMAIs = new List<MyFSMAI>();
     private void Awake()
    {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        CurrentState = new MyMove(this);
        camera = GetComponentInChildren<Camera>();
        FSMAIs.Add(this);
    }

     private void OnDestroy()
     {
         FSMAIs.Remove(this);
     }

     private void Update()
     {
         CurrentState.Transition();
         if (!CurrentState.SetupDone)
         { CurrentState.SetUp();
             CurrentState.SetupDone = true;
         }
         CurrentState.Do();
     }
     
     public void Damage(float damage)
     {
         _hP -= damage;
         if (_hP <= 0)
         { Destroy(gameObject);
         }
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
         { if (Vector3.Distance(ennemy.transform.position, transform.position) <= SightRange) inRange.Add(ennemy); }
         inRange = inRange.OrderBy(ennemy => Vector3.Distance(ennemy.transform.position, transform.position)).ToList();
         return inRange;
     }

     public List<Predator> PredatorsInRange()
     {
         List<Predator> inRange = new List<Predator>();
         foreach (Predator predator in Predator.Predators)
         {if(Vector3.Distance(predator.transform.position, transform.position) <= SightRange) inRange.Add(predator); }
         inRange = inRange.OrderBy(predator => Vector3.Distance(predator.transform.position, transform.position))
             .ToList();
         return inRange;
     }

     public List<Blue> BLuesInRange()
     { List<Blue> inRange = new List<Blue>();
         foreach (Blue blue in Alpha.Meute())
         {if(Vector3.Distance(blue.transform.position, transform.position) <= SightRange) inRange.Add(blue); }
         inRange = inRange.OrderBy(blue => Vector3.Distance(blue.transform.position, transform.position)).ToList();
         return inRange; }
}