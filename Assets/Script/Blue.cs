using System.Collections.Generic;
using UnityEngine;

public class Blue : MonoBehaviour
{
   public BlueState CurrentState;
   public static List<Blue> Blues = new List<Blue>();
   [SerializeField] private float FieldOfView, FieldOfAttack;

   private void Awake()
   { Blues.Add(this);
   }

   private void OnDestroy()
   { Blues.Remove(this);
   }

   private void OnDrawGizmos()
   {
      Gizmos.color = Color.cyan;
      Gizmos.DrawWireSphere(transform.position, FieldOfView);

      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position, FieldOfAttack);
   }
}