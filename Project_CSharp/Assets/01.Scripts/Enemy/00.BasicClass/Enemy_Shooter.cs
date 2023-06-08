using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooter : EnemyController
{
    public GameObject bullet;

    public Transform shootPos;

    public float shootDelay = 2f;

    protected override void Init()
    {
        base.Init();

        StartCoroutine("Shooting");
    }

    protected virtual IEnumerator Shooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootDelay);

            Shoot();
        }
    }

    protected virtual void Shoot()
    {
        CEnemyBullet bulletComponent =  Instantiate(bullet,shootPos.position,Quaternion.identity).GetComponent<CEnemyBullet>();

        bulletComponent.movePos = Vector3.down;
    }
    
}
