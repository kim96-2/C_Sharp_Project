using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_MultiShooter : Enemy_Shooter
{
    public int bulletCount = 2;
    public float bulletAngle = 20f;

    protected override void Shoot()
    {
        if(bulletCount <= 1)
        {
            base.Shoot();
            return;
        }

        float startAngle = -bulletAngle / 2f;
        float angleAmount = bulletAngle / (bulletCount - 1);

        for(int i = 0; i < bulletCount; i++)
        {
            CEnemyBullet bulletComponent = Instantiate(bullet, shootPos.position, Quaternion.identity).GetComponent<CEnemyBullet>();

            bulletComponent.movePos = Quaternion.Euler(0, 0, startAngle + angleAmount * i) * Vector3.down;
        }
    }
}
