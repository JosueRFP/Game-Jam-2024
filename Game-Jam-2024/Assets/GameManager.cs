using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance;

    public GameObject endgame;

    private void Awake()
    {
        Instance = this;
    }

    public void EndGame() 
    {
        //endgame.GetComponent<Animator>().SetTrigger("");
        if (AIPoints.Instance.eviPoints >= AIPoints.Instance.goodPoints) 
        { 
            //evilEnding
        }
        else 
        {
            //goodEnding
        }


    }


}
