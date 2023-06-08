using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int hp = 3;

    public float speed = 2f;
    public float fowardSpeedAmount = 0.2f;

    Vector2 moveDir = new Vector2();

    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()//Player Moving
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        if (v > 0) v *= fowardSpeedAmount;

        moveDir.Set(h, v);
        if (moveDir.sqrMagnitude > 1f) moveDir.Normalize();

        rb.MovePosition(rb.position + moveDir * speed * Time.deltaTime);
    } 

    public void Damage()
    {

        hp -= 1;
    }
}
