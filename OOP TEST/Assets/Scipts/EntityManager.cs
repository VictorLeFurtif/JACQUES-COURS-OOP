using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EntityManager 
{
   public static List<GameObject> myListOfTree = new List<GameObject>();

   public static Vector3 GetDirectionFromTwoVector(Vector3 from, Vector3 to)
   {
      var direction = to - from;
      return direction.normalized;
   }
   
   
   
   public static Vector3 GetNearest(this Vector3 harvesterPos)
   {
      Vector3 finalPosition = Vector3.zero;
      float dist = float.MaxValue;
      foreach (var tree in EntityManager.myListOfTree)
      {
         var currentdist = Vector3.Distance(tree.transform.position,harvesterPos);
         if (currentdist < dist)
         {
            dist = currentdist;
            finalPosition = tree.transform.position;
         }
      }
      return finalPosition;
   }
   public static Vector3 GetNearest(Transform harvesterPos)
   {
      return GetNearest(harvesterPos.position);
   }
   
   public static Vector3 GetNearest(Entity harvesterPos)
   {
      return GetNearest(harvesterPos.transform.position);
   }
}
