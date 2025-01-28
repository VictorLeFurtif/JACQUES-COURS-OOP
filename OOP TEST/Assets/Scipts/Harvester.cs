using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Harvester : NPC
{
    [SerializeField] private float speed;
    private HarvesterState currentHarverState;
    private void Start()
    {
        currentHarverState = HarvesterState.SearchAndGoToTree;
    }

    enum HarvesterState
    {
        SearchAndGoToTree,
        Harvest,
        BackToBase
    }

   

    protected override void ManageCollisionWithCollectible(Collectible other)
    {
        base.ManageCollisionWithCollectible(other);
        Destroy(other.gameObject,1);
        currentHarverState = HarvesterState.Harvest;
    }

    private void SearchAndGoToTree()
    {
        var nextPosition = transform.position.GetNearest();
        Vector3 direction = EntityManager.GetDirectionFromTwoVector(transform.position,nextPosition);
        direction.y = 0;
        transform.position += direction * speed;
    }
    
    protected override void UpdateBehavior()
    {
        base.UpdateBehavior();
        switch (currentHarverState)
        {
            case HarvesterState.SearchAndGoToTree : SearchAndGoToTree();
                break;
            case HarvesterState.Harvest : break;
            case HarvesterState.BackToBase : break;
        }
    }

    protected override void UpdateDeplacement()
    {
        base.UpdateDeplacement();
        if (currentHarverState == HarvesterState.Harvest)
        {
            return;
        }
        
        
    }

    
}
