using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text CountdownDisplay;
    [SerializeField] private float startingCooldown;
    private float cooldown;

    void Start()
    {
        cooldown = startingCooldown;
    }

    void Update()
    {
        cooldown -= Time.deltaTime;
        if (cooldown <= 0)
        {
            GameObject.FindObjectOfType<StateManager>().Lose();
        }
        UpdateCooldownDisplay();
    }

    private void UpdateCooldownDisplay()
    {
        int minutes = Mathf.FloorToInt(cooldown / 60);
        int seconds = Mathf.FloorToInt(cooldown % 60);

        string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

        CountdownDisplay.text = formattedTime;
    }
}
