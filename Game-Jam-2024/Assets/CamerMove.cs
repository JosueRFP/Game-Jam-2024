using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMove : MonoBehaviour
{
    public float rotateSpeed;

    private void Update()
    {
        transform.rotation = new Quaternion(transform.rotation.x, rotateSpeed * Time.deltaTime, 0,0);
    }

}
