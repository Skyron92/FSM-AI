using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class FSMAI2 : MonoBehaviour {
    
    public State CurrentState;
    public int SightRange;

    public NavMeshAgent NavMeshAgent { get; private set; }

    private void Awake() {
        NavMeshAgent = GetComponent<NavMeshAgent>();
        CurrentState = new Wait(this);
    }

    private void Update() {
        CurrentState.Transition();
        if (!CurrentState.SetupDone) {
            CurrentState.Setup();
            CurrentState.SetupDone = true;
        }
        CurrentState.Do();
    }

    public List<Monster> MonstersInRange() {
        List<Monster> inRange = new List<Monster>();
        foreach (Monster monster in Monster.Monsters) {
            if (Vector3.Distance(monster.transform.position, transform.position) <= SightRange) inRange.Add(monster);
        }
        inRange = inRange.OrderBy(monster => Vector3.Distance(monster.transform.position, transform.position)).ToList();
        return inRange;
    }

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, SightRange);
    }

}