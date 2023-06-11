using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float hp = 10f;

    public float speed = 2f;

    public float destroyedScore = 10f;

    public GameObject destroyEffect;

    GameManager gameManager;

    Rigidbody2D rb;

    Material mt;

    protected bool isDestroyed = false;

    // Start is called before the first frame update
    protected void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        gameManager = GameObject.FindWithTag("GameController").GetComponent<GameManager>();

        rb = GetComponent<Rigidbody2D>();
        mt = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        CheckEndOfArea();
    }

    protected virtual void FixedUpdate()
    {
        Move();
    }

    protected void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<PlayerController>().Damage();

            DestroyEnemy();
        }
    }

    protected virtual void Move()
    {
        rb.MovePosition(rb.position + Vector2.down * speed * Time.deltaTime);
    }

    protected void CheckEndOfArea()
    {
        if(transform.position.y < -12f)
        {
            Destroy(this.gameObject);
            isDestroyed = true;
        }
    }

    public void Damage(float damage)
    {
        hp -= damage;

        if (hp <= 0) DestroyEnemy();

        StopCoroutine("DamageEffect");
        StartCoroutine("DamageEffect");
    }

    protected virtual void DestroyEnemy()
    {
        if (isDestroyed) return;
        isDestroyed = true;

        gameManager.EnemyDestroyed(destroyedScore);

        GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);

        Destroy(this.gameObject);
    }

    IEnumerator DamageEffect()
    {
        mt.SetFloat("_Hit_Amount", 1f);

        yield return new WaitForSeconds(0.4f);

        mt.SetFloat("_Hit_Amount", 0f);
    }
}
