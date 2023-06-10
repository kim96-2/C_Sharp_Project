using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterItem : MonoBehaviour
{
    public GameObject shooterPrefab;

    public float speed = 3f;

    PlayerController player;

    bool isUsed = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.down * speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            UseItem();
        }
    }

    void UseItem()
    {
        if (isUsed) return;
        isUsed = true;

        player.AddShooter(shooterPrefab);

        Destroy(this.gameObject);
    }
}
