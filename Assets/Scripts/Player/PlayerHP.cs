using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int heartContainersNumber = 0;
    public int currentHealth;
    public GameObject heartContainerGO;
    public Sprite fullHeart;
    public Sprite damagedHeart;
    public WinLoseCondition wlCondition;

    List<GameObject> hcList = new List<GameObject>();

    // Start is called before the first frame update
    void Awake()
    {
        if(heartContainersNumber == 0)
        {
            heartContainersNumber = 3;
            currentHealth = heartContainersNumber;
        }

        for(int i = 0; i < heartContainersNumber; i++)
        {
            GameObject hc = Instantiate(heartContainerGO) as GameObject;
            hc.transform.SetParent(GameObject.Find("Canvas/Hearts").transform);

            float x = hc.transform.parent.position.x + (40*i);
            float y = hc.transform.parent.position.y;
            hc.transform.position = new Vector2(x, y);

            hcList.Add(hc);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy Attack")
        {
            if (currentHealth > 0)
            {
                hcList[currentHealth - 1].GetComponent<Image>().sprite = damagedHeart;
                currentHealth--;
            }
        }
    }
}
