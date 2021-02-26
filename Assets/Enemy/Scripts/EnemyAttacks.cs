using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    public Transform attackIndicator;
    public int timeOfIndicator = 10;
    public Transform player = null;
    Animator paw1 = null;
    Animator body = null;

    // Start is called before the first frame update
    void Start()
    {
        if(player == null)
            player = GameObject.Find("Player").transform;
        if (paw1 == null)
            paw1 = GameObject.Find("Enemy/Paws/Paw1").GetComponent<Animator>();
        if (body == null)
            body = GameObject.Find("Enemy/Body").GetComponent<Animator>();

        StartCoroutine(ChooseAttack());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator ChooseAttack()
    {
        yield return new WaitForSeconds(3);
        // To choose an attack each 3 seconds
        //Random.Range(0, numberOfAttacks);

        //If player is too close, bite him
        if (player.position.x < 1 &&
            player.position.x > -1 &&
            player.position.z > -2 &&
            player.position.z < -1)
        {
            StartCoroutine(Bite());
        }
        else
        {
            StartCoroutine(Attack1());
        }

        //To loop
        StartCoroutine(ChooseAttack());
    }
    IEnumerator Bite()
    {
        body.SetTrigger("Bite");
        Transform Attack = Instantiate(attackIndicator, new Vector3(0.07f, 0, -0.7f), Quaternion.identity, this.transform);

        yield return new WaitForSeconds(1.20f);

        Destroy(Attack.gameObject);
    }

    IEnumerator Attack1()
    {

        paw1.SetTrigger("Attack1");
        body.SetTrigger("Paw Attack 1");
        Transform Attack = Instantiate(attackIndicator, new Vector3(1.86f, 0, -2.40f), Quaternion.identity, this.transform);

        yield return new WaitForSeconds(1.25f);

        Destroy(Attack.gameObject);
    }
}
