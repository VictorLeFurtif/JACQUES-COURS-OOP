using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    protected int m_pv = 100;
    private int pv => m_pv;
    
    protected virtual void ModifyPV(int newPv)
    {
        m_pv += newPv;
        m_pv = Mathf.Clamp(m_pv, 0, 100);
    }

    protected virtual void Die()
    {
        if (pv <= 0)Debug.Log("Entity dead");
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Collectible"))
        {
            var collectible = other.GetComponent<Collectible>();
            if (collectible != null)
            {
                ManageCollisionWithCollectible(collectible);
            } 
            return; 
        }

        if (other.CompareTag("Player"))
        {
            ManageCollisionWithPlayer(other.GetComponent<NPC>());
            return;
        }

        if (other.CompareTag("obstacle"))
        {
            ManageCollisionWithObstacle(other.GetComponent<Collider2D>());
        }
    }
    protected virtual void ManageCollisionWithPlayer(NPC other)
    {
        Debug.Log("Collision NPC");
    }
    protected virtual void ManageCollisionWithCollectible(Collectible other)
    {
        Debug.Log("Collision collectible");
    }
    
    protected virtual void ManageCollisionWithObstacle(Collider2D other)
    {
        Debug.Log("Collision Obstacle");
    }
}
