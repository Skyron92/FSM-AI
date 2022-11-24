using System;
using UnityEngine;

public class FSMAI : MonoBehaviour {
    
    [SerializeField] private StateEnum _currentState;
    [SerializeField] private bool _enemyNear;
    
    private float _moveTime;

    private void Update() {
        switch (_currentState) {
            case StateEnum.Wait:
                // Etat Wait
                Debug.Log("J'attends");
                // Transition vers Move
                if (Input.GetButtonDown("Fire1"))
                {
                    _currentState = StateEnum.Move;
                    _moveTime = 3f;
                }
                // Transition vers Attack
                if (_enemyNear)
                {
                    _currentState = StateEnum.Attack;
                }
                break;
            case StateEnum.Move:
                // Etat Move
                Debug.Log("Je me déplace");
                _moveTime -= Time.deltaTime;
                // Transition vers Wait
                if (_moveTime <= 0)
                {
                    _currentState = StateEnum.Wait;
                }
                break;
            case StateEnum.Attack:
                // Etat Attack
                Debug.Log("Je lui défonce sa gueule");
                // Transition vers Wait
                if (!_enemyNear)
                {
                    _currentState = StateEnum.Wait;
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
    
}