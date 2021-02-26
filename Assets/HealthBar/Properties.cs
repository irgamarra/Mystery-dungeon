using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Properties : MonoBehaviour
{
    [SerializeField]
    public int maxHP = 100;

    private int currentHP = 100;

    public event Action<float> OnHealthPctChanged = delegate { };
    void Start()
    {

    }

    public void ModifyHP(int amount)
    {
        currentHP += amount;

        float currentHPPct = (float)currentHP / (float)maxHP;
        OnHealthPctChanged(currentHPPct);

    }

    public void OnTriggerEnter(Collider collider)
    {
        ModifyHP(-10);
    }
}
