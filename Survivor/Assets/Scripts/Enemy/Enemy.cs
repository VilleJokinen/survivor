using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float currentSpeed = 3f;
    public Transform playerTransform;
    private Rigidbody2D body;
    private Vector2 direction;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if(playerTransform == null)
        {
            return;
        }
        direction = (playerTransform.position - transform.position).normalized;
        body.MovePosition(body.position + direction * currentSpeed * Time.fixedDeltaTime);
    }
}
