using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spawner : EnemyController
{
    public GameObject spawnEnemy;

    public int spawnEnemyCount = 2;

    public float spawnEnemyDis = 1f;

    protected override void DestroyEnemy()
    {
        if (isDestroyed) return;
        isDestroyed = true;

        GameObject effect = Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(effect, 2f);

        Vector3 offset = Vector3.zero;

        offset.x += -spawnEnemyDis * spawnEnemyCount / 2f;
        for(int i = 0; i < spawnEnemyCount; i++)
        {
            offset.x += spawnEnemyDis;

            Instantiate(spawnEnemy, transform.position + offset, spawnEnemy.transform.rotation);
        }

        Destroy(this.gameObject);
    }
}
