using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour
{
    public GameObject playerUI;
    GameObject player;

    public GameObject anyKeyUI;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");

        player.SetActive(false);

        playerUI.SetActive(false);

        StartCoroutine("AnyKeyClicker");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) StartGame();
    }

    void StartGame()
    {
        player.SetActive(true);
        playerUI.SetActive(true);

        GameObject.FindWithTag("GameController").GetComponent<GameManager>().StartGame();

        Destroy(this.gameObject);

    }

    IEnumerator AnyKeyClicker()
    {
        while (true)
        {
            anyKeyUI.SetActive(false);

            yield return new WaitForSeconds(0.8f);

            anyKeyUI.SetActive(true);

            yield return new WaitForSeconds(0.8f);
        }
    }
}
