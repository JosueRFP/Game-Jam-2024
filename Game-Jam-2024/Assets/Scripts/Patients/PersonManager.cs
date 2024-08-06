using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PersonManager : MonoBehaviour
{
    public static PersonManager Instance;

    [Header("Componentes de Texto")]
    public TMP_Text dialogueName,dialogueSetence;
    public SpriteRenderer dialogueSprite;
    public Button[] gameButtons;


    [Header("Lista dos Casos/Pessoas")]
    public List<PersonBehaviour> personCases = new List<PersonBehaviour>();
    PersonBehaviour activeCase;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        chooseNewCase();
    }

    public void chooseNewCase() 
    {
        foreach(Button b in gameButtons) 
        {
            b.interactable = true;
        }
        Debug.Log("Caso novo");
        if (personCases.Count <= 0) 
        {
            GameManager.Instance.EndGame();
            Debug.Log("GameEnd");
            return;
        }
        activeCase = personCases[Random.Range(0, personCases.Count - 1)];
        personCases.Remove(activeCase);

        dialogueName.text = activeCase.name;
        StopAllCoroutines();
        StartCoroutine(TypeLetters(activeCase.setence));
        dialogueSprite.sprite = activeCase.personFace;
    }

    public void AIPointDistribution(bool aproveButton) 
    {
        Debug.Log("pointDistribution");
        foreach (Button b in gameButtons)
        {
            b.interactable = false;
        }

        if (aproveButton && activeCase.goodBehaviour) 
        {
            AIPoints.Instance.goodPoints++;
            ChangePerson();
            return;
        }
        else if(aproveButton && !activeCase.goodBehaviour) 
        { 
            AIPoints.Instance.eviPoints++;
            ChangePerson();
            return;
        }

        if(!aproveButton && !activeCase.goodBehaviour) 
        { 
            AIPoints.Instance.goodPoints++;
            ChangePerson();
            return;
        }
        else if(!aproveButton && activeCase.goodBehaviour) 
        {
            AIPoints.Instance.eviPoints++;
            ChangePerson();
            return;
        }    
    }

    public void ChangePerson() 
    {
        dialogueSprite.gameObject.GetComponent<Animator>().SetTrigger("Changing");
    }

    
      IEnumerator TypeLetters(string sentence)
    {
        dialogueSetence.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueSetence.text += letter;
            yield return null;
        }
    } 
     

}
