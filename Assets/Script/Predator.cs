using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Predator : MonoBehaviour
{
    public static List<Predator> Predators = new List<Predator>();
    [SerializeField] int FieldOfView, FieldOfAttack;
    [Range(5, 15)] public int DangerosityIndex;

    private void Awake()
    {
        Predators.Add(this);
        DangerosityIndex = Random.Range(1, 10);
        FieldOfAttack = DangerosityIndex / 2;
        FieldOfView = DangerosityIndex + 2;
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