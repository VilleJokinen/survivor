using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Transform gunTransform;

    public float moveSpeed = 5f;


    private Vector2 moveInput;
    private Master controls;
    private Rigidbody2D body;
    void Awake()
    {
        controls = new Master();
        body = GetComponent<Rigidbody2D>();
    }
    
    private void OnEnable(){
        controls.Enable();
    }    
    
    private void OnDisable(){
        controls.Disable();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        moveInput = controls.Player.Move.ReadValue<Vector2>();
        Vector2 movement = new Vector2(moveInput.x, moveInput.y) * moveSpeed * Time.fixedDeltaTime;
        body.MovePosition(body.position + movement);
    }

    private void Update()
    {
        Shoot();
    }

    void Shoot()
    {
        if (controls.Player.Shoot.triggered)
        {
            GameObject bullet = BulletPoolManager.Instance.GetBullet();
            bullet.transform.position = gunTransform.position;
            bullet.transform.rotation = gunTransform.rotation;

        }
    }
}
