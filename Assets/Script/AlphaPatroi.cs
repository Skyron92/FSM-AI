using System;
using Unity.VisualScripting;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

public class AlphaPatroi : AlphaState
{
    private float _rangeX, _rangeZ;
    private Vector3 _target;
    
    private bool HasReachedDestination => Vector3.Distance(_target, AlphaContext.transform.position) < 0.1f;
    public AlphaPatroi(Alpha context) : base(context) {}

    public override void Transition()
    { //Loop
        if (HasReachedDestination)
        {
            AlphaContext.CurrentState = new AlphaPatroi(AlphaContext);
        }
        //Transition vers Alpha
        if (AlphaContext.PredatorsInRange().Count > 0)
        {
            AlphaContext.CurrentState = new AlphaRun(AlphaContext);
            foreach (Blue VARIABLE in AlphaContext.MesMates)
            {
                VARIABLE.CurrentState = new BlueRunAway(VARIABLE);
            }
        }
    }

    public override void SetUp()
    {
        _rangeX = Random.Range(1, 15);
        _rangeZ = Random.Range(1, 15);
        _target = new Vector3(_rangeX, AlphaContext.transform.position.y, _rangeZ);
    }

    public override void Do() {
        if (AlphaContext.chance >= 9990) { 
            GameObject newkid = GameObject.Instantiate(AlphaContext.prefabBlue, AlphaContext.transform.position, Quaternion.identity); 
            AlphaContext.Mates.Add(newkid);
            foreach (GameObject BlueGO in AlphaContext.Mates) { 
                Blue blue = BlueGO.GetComponent<Blue>();
                AlphaContext.MesMates.Add(blue);
            } 
        }
        foreach (Blue VARIABLE in AlphaContext.MesMates) {
            VARIABLE.AlphaCreator = AlphaContext;
        }
        AlphaContext.NavMeshAgent.SetDestination(_target); 
    }
    
}