using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathFinding : MonoBehaviour
{
    [SerializeField] float _speed;

    private Rigidbody2D rb;
    private Vector2 moveDir;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb.MovePosition(rb.position+ moveDir*_speed*Time.deltaTime);
    }

    public void GetMoveDir(Vector2 dir)
    {
        moveDir = dir;
    }
}
