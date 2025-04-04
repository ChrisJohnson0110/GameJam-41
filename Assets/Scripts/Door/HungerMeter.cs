using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerMeter : MonoBehaviour
{
    [SerializeField] private Slider HungerSlider;

    private void Start()
    {
        HungerSlider.maxValue = 100;
        HungerSlider.value = 0;
    }

    public void DecreaseHunger(int a_amount)
    {
        HungerSlider.value += a_amount;
    }
}
