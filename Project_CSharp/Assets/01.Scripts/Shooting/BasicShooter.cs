using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicShooter : Shooter
{
    public GameObject bullet;

    public Transform shootPos;

    protected float time = 0f;

    protected override void Init()
    {
        base.Init();

        time = 0f;
    }

    protected override void ShootingUpdate()
    {
        time += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && time >= shootingDelay &&player.isShootingGaugeExist)
        {
            CreateBullet();

            time = 0f;
        }
    }

    protected virtual void CreateBullet()
    {
        GameObject _bullet = Instantiate(bullet,shootPos.position,bullet.transform.rotation);
    }
}
