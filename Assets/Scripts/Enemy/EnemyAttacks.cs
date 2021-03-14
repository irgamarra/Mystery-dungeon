using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    public Transform attackIndicator;
    public int timeOfIndicator = 10;
    private GameObject [] characters = null;
    Animator paw1 = null;
    Animator body = null;

    // Start is called before the first frame update
    void Start()
    {
        characters = GameObject.FindGameObjectsWithTag("Characters");
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
        bool tooClose = false;
        foreach(GameObject character in characters)
        {
            if (character.transform.position.x < 1 &&
            character.transform.position.x > -1 &&
            character.transform.position.z > -2 &&
            character.transform.position.z < -1)
            {
                tooClose = true;
            }
        }
        if (tooClose)
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

    Collider ToInstantiateAttack(Vector3 v3)
    {
        Transform t = Instantiate(attackIndicator, v3, Quaternion.identity, this.transform);
        Collider attackCollider = t.GetComponent<Collider>();
        attackCollider.enabled = false;

        return attackCollider;
    }
    IEnumerator Bite()
    {
        body.SetTrigger("Bite");
        Collider attackCollider = ToInstantiateAttack(new Vector3(0.07f, 0, -0.7f));

        //To wait until the attack lands
        yield return new WaitForSeconds(1.15f);

        attackCollider.enabled = true;

        //To wait a few frames before destroying the GameObject
        yield return new WaitForSeconds(0.02f);

        Destroy(attackCollider.gameObject);
    }

    IEnumerator Attack1()
    {

        paw1.SetTrigger("Attack1");
        body.SetTrigger("Paw Attack 1");
        Collider attackCollider = ToInstantiateAttack(new Vector3(1.86f, 0, -2.40f));

        //To wait until the attack lands
        yield return new WaitForSeconds(1.35f);

        attackCollider.enabled = true;

        //To wait a few frames before destroying the GameObject
        yield return new WaitForSeconds(0.02f);

        Destroy(attackCollider.gameObject);
    }
}
