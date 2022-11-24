using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Predator : MonoBehaviour
{
    public static List<Predator> Predators = new List<Predator>();
    [SerializeField] int FieldOfView, FieldOfAttack;
    [Range(1, 10)] public int DangerosityIndex;

    private void Awake()
    {
        Predators.Add(this);
        DangerosityIndex = Random.Range(1, 10);
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