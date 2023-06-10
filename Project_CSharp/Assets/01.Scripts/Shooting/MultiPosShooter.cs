using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiPosShooter : BasicShooter
{
    public List<Transform> shootPoss = new List<Transform>();

    protected override void CreateBullet()
    {
        foreach(Transform pos in shootPoss)
        {
            GameObject _bullet = Instantiate(bullet, pos.position, bullet.transform.rotation);
        }
    }
}
