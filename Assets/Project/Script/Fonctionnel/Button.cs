using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject prefabPredator, prefabPrey, prefabAlpha;
    private int prob;
    
    public void CreatePred()
    { Instantiate(prefabPredator); }

    public void CreatePrey()
    { Instantiate(prefabPrey); }

    public void CreateAlpha()
    { Instantiate(prefabAlpha); }

    public void CreateRandom()
    { prob = Random.Range(1, 4);
        Debug.Log(prob);
        if (prob == 1)
        { CreateAlpha(); }
        if (prob == 2)
        { CreatePrey(); }
        if (prob == 3)
        { CreatePred(); }
    }
}
