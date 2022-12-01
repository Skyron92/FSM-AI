using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Alpha : MonoBehaviour
{

    public AlphaState CurrentState;
    public static Transform _transform;
    public static List<Alpha> Alphas = new List<Alpha>();
    private static float FieldOfAlpha;
    [SerializeField] private float FieldOfAttack, AlphaRange;
    [SerializeField] public GameObject prefabBlue;
    public int chance;
    public NavMeshAgent NavMeshAgent { get; private set; }
    public Vector3 AlphaPosition;
    public List<GameObject> Mates = new List<GameObject>();
    public List<Blue> MesMates = new List<Blue>();
    private void Awake()
    {
        FieldOfAlpha = AlphaRange;
        NavMeshAgent = GetComponent<NavMeshAgent>();
        _transform = GetComponent<Transform>();
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
        AlphaPosition = transform.position;
        CurrentState.Transition();
        if (!CurrentState.setUpDone)
        { CurrentState.SetUp();
            CurrentState.setUpDone = true; }
        CurrentState.Do(); }

    private void OnDrawGizmos()
    { Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, AlphaRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, FieldOfAttack); }


    public static List<Blue> Meute()
    { List<Blue> BlueInGroup = new List<Blue>();
        foreach (Blue blue in Blue.Blues)
        { if (Vector3.Distance(blue.transform.position, _transform.position) <= FieldOfAlpha)BlueInGroup.Add(blue); }
            BlueInGroup = BlueInGroup.OrderBy(blue => Vector3.Distance(blue.transform.position, _transform.position)).ToList();
            return BlueInGroup;}
    
    
    public List<Predator> PredatorsInRange()
    { List<Predator> inRange = new List<Predator>();
        foreach (Predator predator in Predator.Predators)
        {if(Vector3.Distance(predator.transform.position, transform.position) <= FieldOfAlpha) inRange.Add(predator); }
        inRange = inRange.OrderBy(predator => Vector3.Distance(predator.transform.position, transform.position))
            .ToList();
        return inRange;
    }
}