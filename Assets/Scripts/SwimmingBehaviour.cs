using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SwimmingBehaviour : BaseBehaviour
{
    InputAction _leftPaddle;
    InputAction _rightPaddle;

    private int neededPress;

    public Rigidbody2D _rigidbody;

    protected override void Start()
    {
        
    }


    public override void BehaviourUpdate()
    {
        if (_leftPaddle == null)
        {
            _leftPaddle = InputSystem.actions.FindAction("PaddleLeft");
            _rightPaddle = InputSystem.actions.FindAction("PaddleRight");

            neededPress = -1;
        }
        
        
        if (_rightPaddle.WasPressedThisFrame())
        {
            if (neededPress == 0 || neededPress == -1)
            {
                neededPress = 1;
                PropelBear();
            }
        }
        
        if (_leftPaddle.WasPressedThisFrame())
        {
            if (neededPress == 1 || neededPress == -1)
            {
                neededPress = 0;
                PropelBear();
            }
        }
        
        
    }

    private void PropelBear()
    {
        _rigidbody.AddForce(Vector2.right * 100);
    }
}
