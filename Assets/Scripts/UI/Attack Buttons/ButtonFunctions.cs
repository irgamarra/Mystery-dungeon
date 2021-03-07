using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFunctions : MonoBehaviour
{
    public Animator sword = null;
    private void Start()
    {
        if(sword == null)
        {
            sword = GameObject.Find("Player/Sword").GetComponent<Animator>();
        }
    }
    public void SwordAttack()
    {
        sword?.SetTrigger("Attack");
    }
}
