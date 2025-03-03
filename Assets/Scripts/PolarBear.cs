using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PolarBear : MonoBehaviour
{
    enum BearState
    {
        Running,
        Swimming,
        Hunting
    };


    private BearState bearState = BearState.Running;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch (bearState)
        {
            case BearState.Running:
                break;
            case BearState.Swimming:
                break;
            case BearState.Hunting:
                break;
            
        }
        
    }
}
