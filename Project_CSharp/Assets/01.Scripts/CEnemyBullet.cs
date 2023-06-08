using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemyBullet : MonoBehaviour
{
    public Vector3 movePos = Vector3.down;

    public float speed;

    protected bool isDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected void Move()
    {
        transform.position = transform.position + movePos * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().Damage();

            DestroyBullet();
        }
    }

    protected void DestroyBullet()
    {
        if (isDestroyed) return;
        isDestroyed = true;

        Destroy(this.gameObject);
    }

    protected void CheckEndOfArea()
    {
        if (transform.position.y < -12f)
        {
            Destroy(this.gameObject);
            isDestroyed = true;
        }
    }
}
