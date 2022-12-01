using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Predator : MonoBehaviour
{
    public PredatorState CurrentState;
    public static List<Predator> Predators = new List<Predator>();
    [SerializeField] float FieldOfView, FieldOfAttack, scaleIndex;
    [Range(10, 15)] public float DangerosityIndex;
    public float Damage;
    public int _hP = 25;
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
        DangerosityIndex = Random.Range(10, 15);
        FieldOfAttack = DangerosityIndex;
        Damage = DangerosityIndex - 5;
        FieldOfView = DangerosityIndex * 1.5f;
        scaleIndex = DangerosityIndex / 2 + 1;
        this.transform.localScale = new Vector3(scaleIndex, scaleIndex, scaleIndex);
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

    public List<MyFSMAI> MyFsmaiInFieldOfView()
    { List<MyFSMAI> inFOV = new List<MyFSMAI>();
        foreach (MyFSMAI fsmai in MyFSMAI.FSMAIs)
        { if (Vector3.Distance(fsmai.transform.position, transform.position) <= FieldOfView) inFOV.Add(fsmai) ; }
        inFOV = inFOV.OrderBy(fsmai => Vector3.Distance(fsmai.transform.position, transform.position)).ToList();
        return inFOV;
    }
    public List<MyFSMAI> MyFsmaiInRange()
    { List<MyFSMAI> inRange = new List<MyFSMAI>();
        foreach (MyFSMAI fsmai in MyFSMAI.FSMAIs)
        { if (Vector3.Distance(fsmai.transform.position, transform.position) <= FieldOfAttack) inRange.Add(fsmai) ; }
        inRange = inRange.OrderBy(fsmai => Vector3.Distance(fsmai.transform.position, transform.position)).ToList();
        return inRange;
    }
    
    public List<Blue> BluesInFieldOfView()
    { List<Blue> inFOV = new List<Blue>();
        foreach (Blue blues in Blue.Blues)
        { if (Vector3.Distance(blues.transform.position, transform.position) <= FieldOfView) inFOV.Add(blues) ; }
        inFOV = inFOV.OrderBy(blues => Vector3.Distance(blues.transform.position, transform.position)).ToList();
        return inFOV;
    }
    public List<Blue> BlueInRange()
    { List<Blue> inRange = new List<Blue>();
        foreach (Blue blue in Blue.Blues)
        { if (Vector3.Distance(blue.transform.position, transform.position) <= FieldOfAttack) inRange.Add(blue) ; }
        inRange = inRange.OrderBy(blue => Vector3.Distance(blue.transform.position, transform.position)).ToList();
        return inRange;
    }
    
    public void TakeDamage(int damage)
    {
        _hP -= damage;
        if (_hP <= 0)
        { Destroy(gameObject);
        }
    }
}