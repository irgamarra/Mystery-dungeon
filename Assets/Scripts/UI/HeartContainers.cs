using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartContainers : MonoBehaviour
{
    GameObject indicator;

    public GameObject heartContainerGO;
    public Sprite fullHeart;
    public Sprite damagedHeart;

    public List<GameObject> hcList;

    private void Awake()
    {
        indicator = GameObject.FindGameObjectWithTag("Indicator");

        hcList = new List<GameObject>();
        DrawEmptyHearts();
    }

    private void Start()
    {
        DrawHearts();
    }

    public void DrawHearts()
    {
        PlayerHP hp = indicator.GetComponentInParent<PlayerHP>();

        for (int i = 0; i < hp.maxHealth; i++)
        {
            hcList[i].GetComponent<Image>().color = Color.white;
            if (i > hp.currentHealth-1)
                hcList[i].GetComponent<Image>().sprite = damagedHeart;
            else
                hcList[i].GetComponent<Image>().sprite = fullHeart;
        }
    }

    private void DrawEmptyHearts()
    {
        for (int i = 0; i < 6; i++)
        {
            GameObject hc = Instantiate(heartContainerGO) as GameObject;
            hc.transform.SetParent(GameObject.Find("Canvas/Hearts").transform);

            float x = hc.transform.parent.position.x + (40 * i);
            float y = hc.transform.parent.position.y;
            hc.transform.position = new Vector2(x, y);

            hc.GetComponent<Image>().sprite = null;
            hc.GetComponent<Image>().color = Color.clear;

            hcList.Add(hc);
        }
    }

}
