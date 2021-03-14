using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFunctions : MonoBehaviour
{
    private GameObject indicator;
    private void Start()
    {
        indicator = GameObject.FindGameObjectWithTag("Indicator");
    }
    public void SwordAttack()
    {
        indicator.transform.parent.Find("Weapon").GetComponent<Animator>().SetTrigger("Attack");
    }
    public void ChangeCharacter()
    {
        GameObject currentCharacter = indicator.transform.parent.gameObject;

        currentCharacter.GetComponent<Movement>().enabled = false;

        foreach (GameObject character in GameObject.FindGameObjectsWithTag("Characters"))
        {
            if (currentCharacter.name != character.name)
            {
                indicator.transform.SetParent(character.transform);
                indicator.transform.localPosition = new Vector3(0, 1, 0);

                character.GetComponent<Movement>().enabled = true;

                break;
            }
        }

        //Draw hearts
        GameObject.Find("Canvas/Hearts").GetComponent<HeartContainers>().DrawHearts();
    }
}
