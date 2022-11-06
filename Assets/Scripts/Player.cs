using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity
{
    private Rigidbody2D _rb;
    private GameInput _input;
    [SerializeField]private float _jumpForce;
    private Vector2 _dir = Vector2.zero;
    private void Awake()
    {
        _input = new GameInput();
        _input.Enable();
        _rb = GetComponent<Rigidbody2D>();
        _input.Player.Move.performed += context => _dir = context.ReadValue<Vector2>();
        _input.Player.Move.canceled += context => _dir = Vector2.zero;
        _input.Player.Jump.performed += context => Jump();
    }

    private void FixedUpdate()
    {
        Move(_dir);
    }

    private void Move(Vector2 dir)
    {
        _rb.velocity = new Vector2(dir.x * speed, _rb.velocity.y);
    }

    private void Jump()
    {
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
    }
}
