using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameObject endgame, dialoguePanel;
    public TMP_Text DaysTransitioningText;

    public string[] goodSetences, badSetences;

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
                Debug.Log("BadEnding");
                return;
            }
            Debug.Log("BacktoGame");
            DaysTransitioningText.text = badSetences[Random.Range(0, badSetences.Length - 1)];
            endgame.GetComponent<Animator>().SetTrigger("BackToGame");
            
        }
        else 
        {
            if (PersonManager.Instance.days <= 0)
            {
                //goodEnding
                Debug.Log("GoodEnding");
                return;
            }
            Debug.Log("BacktoGame");
            DaysTransitioningText.text = goodSetences[Random.Range(0, goodSetences.Length - 1)];
            endgame.GetComponent<Animator>().SetTrigger("BackToGame");
           
        }


    }


}
