using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScreen : MonoBehaviour
{
    public Transform goodEndingCam, badEndingCam;
    public void StartOver() 
    {
        PersonManager.Instance.chooseNewCase();
        GameManager.Instance.dialoguePanel.SetActive(true);
    }

    public void NewCamPos(int i) 
    {
        if (i == 1) 
        { 
            Camera.main.transform.position = goodEndingCam.transform.position;
            Camera.main.transform.rotation = goodEndingCam.transform.rotation;
        }
        else 
        {
            Camera.main.transform.position = badEndingCam.transform.position;
            Camera.main.transform.rotation = badEndingCam.transform.rotation;
        }
    }
}
