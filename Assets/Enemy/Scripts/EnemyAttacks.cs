using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacks : MonoBehaviour
{
    public Transform attackIndicator;
    public int timeOfIndicator = 10;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChooseAttack());
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator ChooseAttack()
    {
        yield return new WaitForSeconds(3);
        // To choose an attack each 5 seconds
        //Random.Range(0, numberOfAttacks);

        StartCoroutine(Attack1());

        //To loop
        StartCoroutine(ChooseAttack());
    }

    IEnumerator Attack1()
    {
        Animator paw1 = GameObject.Find("Enemy/Paws/Paw1").GetComponent<Animator>();

        paw1.SetTrigger("Attack1");
        Transform Attack = Instantiate(attackIndicator, new Vector3(1.86f, 0, -2.40f), Quaternion.identity, this.transform);

        yield return new WaitForSeconds(1.25f);

        Destroy(Attack.gameObject);
    }
}
