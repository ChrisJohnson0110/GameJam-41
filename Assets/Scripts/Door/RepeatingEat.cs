using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingEat : MonoBehaviour
{
    [SerializeField] private float EatCooldown;
    private float cooldown = 1;
    private void Update()
    {
        cooldown -= Time.deltaTime;

        if (cooldown <= 0)
        {
            cooldown = EatCooldown;
            GameObject.FindAnyObjectByType<EatAnimation>().Eat();
        }
    }
}
