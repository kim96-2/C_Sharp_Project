using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public Vector3 moveDir = Vector3.up;

    public float speed = 2f;

    public float damage = 3f;

    protected bool isDestroyed = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckEndOfArea();

        Move();
    }

    protected void Move()
    {
        transform.position = transform.position + moveDir * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<EnemyController>().Damage(damage);

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
        if (transform.position.y < -12f || transform.position.y > 12f)
        {
            Destroy(this.gameObject);
            isDestroyed = true;
        }
    }
}
