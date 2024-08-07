using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamerMove : MonoBehaviour
{
    public float rotateSpeed;

    private void Update()
    {

        this.gameObject.transform.localEulerAngles += new Vector3(0, rotateSpeed*Time.deltaTime, 0);
    }

}
