using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iceberg : MonoBehaviour
{
    [SerializeField]
    List<float> stageTimers = new List<float>();

    [SerializeField]
    private int icebergLifeMax = 3;

    private int icebergLife;
    
    private float _activeTimer;

    
    public bool stoodUpon;

    private void Start()
    {
        icebergLife = icebergLifeMax;
        SetActiveTimer();
    }

    // Update is called once per frame
    void Update()
    {
        if (stoodUpon)
        {
            if (_activeTimer > 0)
            {
                _activeTimer -= Time.deltaTime;
            }
            else
            {
                icebergLife--;
                if (icebergLife > 0)
                {
                    SetActiveTimer();
                }
                else
                {
                    Destroy(gameObject);
                }
            }
        }
    }

    private void SetActiveTimer()
    {
        _activeTimer = stageTimers[icebergLifeMax-icebergLife];
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            stoodUpon = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            stoodUpon = false;
        }
    }
    
}
