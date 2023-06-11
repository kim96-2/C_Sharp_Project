using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public List<GameObject> Enemy_Normal;
    public List<GameObject> Enemy_Shooter;

    public List<GameObject> items;

    public float createOffset = 10f;

    public float maxCreateTime = 5f;
    public float minCreateTime = 3f;

    public float itemCreateTime = 8f;

    public int maxEnemyNum = 4;

    public GameObject GameOverUI;
    public TMP_Text scoreText;

    protected float score = 0;
    public float Score
    {
        get { return score; }
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("CreateEnemys");

        StartCoroutine("CreateItems");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator CreateEnemys()
    {
        float time = maxCreateTime;

        float createNum = 1f;

        while (true)
        {
            float offset = Random.Range(-3f, 3f);

            int num = Random.Range(1, (int)createNum + 1);

            float start = offset - (num - 1) / 2f;

            Vector3 pos = new Vector3();

            for(int i=0;i<num; i++)
            {
                pos.Set(start +  i, createOffset, 0);

                CreateEnemy_Normal(pos);
            }

            yield return new WaitForSeconds(1.2f);

            num = Random.Range(1, (int)createNum + 1);
            start = offset - (num - 1) / 2f;

            for (int i = 0; i < num; i++)
            {
                pos.Set(start + i, createOffset, 0);

                CreateEnemy_Shooter(pos);
            }

            yield return new WaitForSeconds(time);

            time = (time - 0.5f) < minCreateTime ? minCreateTime : (time - 0.5f);

            createNum = (createNum + 0.5f) > maxEnemyNum ? maxEnemyNum : (createNum + 0.5f);

           
        }
    }

    IEnumerator CreateItems()
    {
        Vector3 pos = new Vector3();
        while (true)
        {
            pos.Set(Random.Range(-4f, 4f), createOffset, 0);
            CreateItem(pos);

            yield return new WaitForSeconds(itemCreateTime);
        }
    }

    void CreateEnemy_Normal(Vector3 pos)
    {
        GameObject enemy = Enemy_Normal[Random.Range(0, Enemy_Normal.Count)];

        Instantiate(enemy, pos, enemy.transform.rotation);
    }

    void CreateEnemy_Shooter(Vector3 pos)
    {
        GameObject enemy = Enemy_Shooter[Random.Range(0, Enemy_Shooter.Count)];

        Instantiate(enemy, pos, enemy.transform.rotation);
    }

    void CreateItem(Vector3 pos)
    {
        GameObject item = items[Random.Range(0, items.Count)];

        Instantiate(item, pos, item.transform.rotation);
    }

    public void EnemyDestroyed(float score)
    {
        this.score += score;

    }

    public void GameOver()
    {
        StopCoroutine("CreateEnemys");

        StopCoroutine("CreateItems");

        scoreText.text = "SCORE : " + score.ToString();

        GameOverUI.SetActive(true);
    }
}
