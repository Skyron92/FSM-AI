using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject prefabPredator, prefabBase, prefabAlpha;
    private int prob;

    public void CreatePred()
    { Instantiate(prefabPredator); }

    public void CreateBase()
    { Instantiate(prefabBase); }

    public void CreateAlpha()
    { Instantiate(prefabAlpha); }

    public void CreateRandom()
    { prob = Random.Range(1, 3);
        if (prob == 1)
        { CreateAlpha(); }
        if (prob == 2)
        { CreateBase(); }
        if (prob == 3)
        { CreatePred(); } }
}
