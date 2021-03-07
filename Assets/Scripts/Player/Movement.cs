using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        //Touchscreen
        Vector3 direction = Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal;

        //rb.AddForce(direction * speed * Time.fixedDeltaTime, ForceMode.VelocityChange);

        transform.Translate(direction * speed * Time.fixedDeltaTime, Space.World);

        //WASD
        Vector3 Movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        transform.Translate(Movement * speed * Time.fixedDeltaTime, Space.World);
    }
}
