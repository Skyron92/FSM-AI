using System.Collections.Generic;
using UnityEngine;

public class Ennemy : MonoBehaviour
{
    private int _hP = 10;
    private float rangeX, rangeY, rangeZ;

    public static List<Ennemy> Ennemies = new List<Ennemy>();

    public void Damage(int damage)
    {
        _hP -= damage;
        if (_hP <= 0)
        { Destroy(gameObject);
        }
    }
    private void Awake()
    {
        Ennemies.Add(this);
    }

    private void OnDestroy()
    {
        Ennemies.Remove(this);
    }
}
