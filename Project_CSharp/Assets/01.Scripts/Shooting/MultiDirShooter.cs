using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiDirShooter : BasicShooter
{
    public int bulletCount = 4;
    public float shootingAngle = 40f;

    protected override void CreateBullet()
    {
        float firstAngle = -shootingAngle / 2f;
        float angle = shootingAngle / (bulletCount - 1);

        for(int i = 0; i < bulletCount; i++)
        {
            GameObject _bullet = Instantiate(bullet, shootPos.position, bullet.transform.rotation);

            _bullet.GetComponent<PlayerBullet>().moveDir = Quaternion.Euler(0f, 0f, firstAngle + angle * i) * Vector3.up;
        }
    }
}
