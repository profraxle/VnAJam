using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwimmingBehaviour : BaseBehaviour
{
    InputAction _leftPaddle;
    InputAction _rightPaddle;
    
    [SerializeField,Tooltip("Force per paddle")]
    private float _swimForce = 100;

    private int neededPress;

    public Rigidbody2D _rigidbody;

    [SerializeField, Tooltip("Seconds before input resets")]
    private float resetTimerAmount = 2f;
    
    private float _resetTimer;
    
    protected override void Start()
    {
        _resetTimer = 0;
        
        if (_leftPaddle == null)
        {
            _leftPaddle = InputSystem.actions.FindAction("PaddleLeft");
            _rightPaddle = InputSystem.actions.FindAction("PaddleRight");

            neededPress = -1;
        }
    }


    public override void BehaviourUpdate()
    {
        if (_resetTimer > 0)
        {
            _resetTimer -= Time.deltaTime;
        }
        else
        {
            if (neededPress != -1)
            {
                neededPress = -1;
            }
        }
        
        
        if (_rightPaddle.WasPressedThisFrame())
        {
            _resetTimer = resetTimerAmount;
            if (neededPress == 0 || neededPress == -1)
            {
                neededPress = 1;
                PropelBear();
            }
        }
        
        if (_leftPaddle.WasPressedThisFrame())
        {
            _resetTimer = resetTimerAmount;
            if (neededPress == 1 || neededPress == -1)
            {
                neededPress = 0;
                PropelBear();
            }
        }
        
        
    }

    private void PropelBear()
    {
        _rigidbody.AddForce(Vector2.right * _swimForce);
    }
}
