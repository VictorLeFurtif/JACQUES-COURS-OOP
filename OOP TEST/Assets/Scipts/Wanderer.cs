using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class Wanderer : NPC
{
    public bool rightMovement;
    [SerializeField] private float speed;

    protected override void UpdateDeplacement()
    {
        base.UpdateDeplacement();
        transform.position += new Vector3(rightMovement ? speed : -speed, 0, 0);
    }

    protected override void ManageCollisionWithObstacle(Collider2D other)
    {
        base.ManageCollisionWithObstacle(other);
        rightMovement = !rightMovement;
    }
}
