using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public Animator anim;
    public KeyCode key;
    public string weaponType;
    public GameObject bulletStaff;
    public float bulletSpeed;
    public float bulletDistance;

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(key))
            ToAttack();
    }
    public void ToAttack()
    {
        //To check what is the current animation
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            anim.SetTrigger("Attack");
            switch (weaponType)
            {
                case "Sword":
                    SwordAttack();
                    break;
                case "Staff":
                    StartCoroutine(StaffAttack());
                    break;
            }
        }
    }
    
    private void SwordAttack()
    {

    }

    private IEnumerator StaffAttack()
    {
        //To sync up with the animation
        yield return new WaitForSeconds(1.25f);

        GameObject bullet = Instantiate(bulletStaff);
        bullet.transform.SetParent(transform.parent);
        bullet.transform.localPosition = new Vector3(0.2f, 0.4f, 0.4f);

        //To not move with the character (it's an ugly fix)
        bullet.transform.SetParent(transform.parent.parent);

        //To move the bullet
        bullet.transform.LookAt(GameObject.Find("Enemy/Body").transform);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bullet.transform.forward * bulletSpeed);
    }
}
