using UnityEngine;

public class AlphaPatroi : AlphaState
{
    private float _rangeX, _rangeZ;
    private Vector3 _target;
    public AlphaPatroi(Alpha context) : base(context)
    {
    }

    public override void Transition()
    {
        
    }

    public override void SetUp()
    {
        _rangeX = Random.Range(1, 15);
        _rangeZ = Random.Range(1, 15);
        _target = new Vector3(_rangeX, AlphaContext.transform.position.y, _rangeZ);
    }

    public override void Do()
    {
        AlphaContext.NavMeshAgent.SetDestination(_target);
        InvokeRepeating("Spawn", 2, 1);
    }

    public void Spawn()
    { float chance = Random.Range(0, 1);
        if (chance >= 0.7)
        { Instantiate(AlphaContext.prefabBlue);
        Debug.Log("Bonjour !");
        } }
}