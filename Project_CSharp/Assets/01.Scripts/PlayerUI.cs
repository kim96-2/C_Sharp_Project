using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public Slider[] shootingGaugeUI;

    public Image[] hpUI;

    PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();

        foreach (Slider gauge in shootingGaugeUI)
            gauge.maxValue = player.MaxShootingGauge;
    }

    // Update is called once per frame
    void Update()
    {
        ShootingGaugeUISetting();

        HpUISetting();
    }

    void ShootingGaugeUISetting()
    {
        foreach (Slider gauge in shootingGaugeUI)
            gauge.value = player.ShootingGauge;
    }

    void HpUISetting()
    {
        for(int i = 0; i < hpUI.Length; i++)
        {
            if (player.hp >= i + 1) hpUI[i].enabled = true;
            else hpUI[i].enabled = false;
        }
    }
}
