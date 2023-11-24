using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

    public static List<Monster> Monsters = new List<Monster>();

    private int _hp = 10;

    public void Damage(int damage) {
        _hp -= damage;
        if (_hp <= 0) Destroy(gameObject);
    }
    
    private void Awake() {
        Monsters.Add(this);
    }

    private void OnDestroy() {
        Monsters.Remove(this);
    }

}
