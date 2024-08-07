using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingScreen : MonoBehaviour
{
    public void StartOver() 
    {
        PersonManager.Instance.chooseNewCase();
        GameManager.Instance.dialoguePanel.SetActive(true);
    }

    public void EndGame(bool goodEnding) 
    { 
    //if true final bom, else final ruim
    }
}
