using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : Entity
{
   private void Awake()
   {
      EntityManager.myListOfTree.Add(gameObject);
   }

   protected override void ManageCollisionWithPlayer(NPC other)
   {
      base.ManageCollisionWithPlayer(other);
      Destroy(gameObject);
   }
}
