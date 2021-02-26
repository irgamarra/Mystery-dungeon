using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLooksAtCamera : MonoBehaviour
{
    void Update()
    {
        Vector3 oppositeCamera = transform.position - Camera.main.transform.position;
        Quaternion faceCamera = Quaternion.LookRotation(oppositeCamera);
        Vector3 euler = faceCamera.eulerAngles;
        euler.y = 0f;
        faceCamera.eulerAngles = euler;
        transform.rotation = faceCamera;
    }
}
