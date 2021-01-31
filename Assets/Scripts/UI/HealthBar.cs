using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Health bar displayer
public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public PlayerShip player;

    private void Start()
    {
        slider = GetComponent<Slider>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShip>();

        slider.maxValue = player.initialLife;
        slider.value = player.initialLife;
    }

    private void Update()
    {
        slider.value = player.initialLife;
    }
}