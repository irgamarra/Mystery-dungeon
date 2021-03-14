using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public void Awake()
    {
        currentHealth = maxHealth;
    }
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy Attack")
        {
            if (currentHealth > 0)
            {
                currentHealth--;
            }
        }

        GameObject.Find("Canvas/Hearts").GetComponent<HeartContainers>().DrawHearts();
    }
}
