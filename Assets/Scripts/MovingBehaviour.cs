using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;



public class MovingBehaviour : BaseBehaviour
{
    InputAction _moveAction;
    InputAction _jumpAction;

    [SerializeField]
    private float moveForce;
    [SerializeField]
    private float jumpForce;
    
    [SerializeField]
    GroundCheck _groundCheck;
    
    public Rigidbody2D _rigidbody;

    protected override void Start()
    {
        base.Start();
        _moveAction = InputSystem.actions.FindAction("Move");
        _jumpAction = InputSystem.actions.FindAction("Jump");
    }

    public override void BehaviourUpdate()
    {
        if (_moveAction.IsPressed())
        {
            _rigidbody.AddForce(new Vector2(_moveAction.ReadValue<Vector2>().x * moveForce,0), ForceMode2D.Force);
        }

        if (_jumpAction.WasPressedThisFrame() && _groundCheck.onGround)
        {
            _rigidbody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }
}
