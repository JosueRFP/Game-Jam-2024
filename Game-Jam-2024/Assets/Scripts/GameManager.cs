using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject endgame, dialoguePanel;

    private void Awake()
    {
        Instance = this;
    }

    public void EndGame() 
    {
        dialoguePanel.SetActive(false);
        endgame.GetComponent<Animator>().SetTrigger("EndGameT");
        if (AIPoints.Instance.eviPoints >= AIPoints.Instance.goodPoints) 
        { 

            if (PersonManager.Instance.days <= 0) 
            { 
                //badEnding
            }
        }
        else 
        {
            if (PersonManager.Instance.days <= 0)
            {
                //goodEnding
            }
        }


    }


}
