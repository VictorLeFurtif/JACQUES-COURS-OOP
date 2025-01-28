using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
 public abstract class NPC : Entity
{
   // [SerializeField] private Slider pvSlider;
    
    protected override void ModifyPV(int newPv)
    {
        base.ModifyPV(newPv);
       // pvSlider.value = m_pv; // Canva modifier
        Die();
    }

    public void Update()
    {
        UpdateDeplacement();
        UpdateBehavior();
    }

    protected override void Die() //au cas où
    {
        base.Die();
    }

    protected virtual void UpdateDeplacement()
    {
        
    }

    protected virtual void UpdateBehavior()
    {
        
    }
    
}
