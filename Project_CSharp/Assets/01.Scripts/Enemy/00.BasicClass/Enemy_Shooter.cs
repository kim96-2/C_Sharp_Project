using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooter : EnemyController
{
    public GameObject bullet;

    public Transform shootPos;

    public float shootDelay = 2f;

    protected Transform playerPos;

    protected override void Init()
    {
        base.Init();

        StartCoroutine("Shooting");

        playerPos = GameObject.FindWithTag("Player").transform;
    }

    protected virtual IEnumerator Shooting()
    {
        yield return new WaitForSeconds(Random.Range(0f,shootDelay/2f));

        while (true)
        {
            yield return new WaitForSeconds(shootDelay);

            if(playerPos.position.y < transform.position.y - 5f) Shoot();

        }
    }

    protected virtual void Shoot()
    {
        Vector3 dir = playerPos.position - transform.position;
        dir.z = 0;
        dir.Normalize();

        CEnemyBullet bulletComponent =  Instantiate(bullet,shootPos.position,Quaternion.identity).GetComponent<CEnemyBullet>();

        bulletComponent.movePos = dir;
    }
    
}
