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
    public Button passDialogueButton;

    public int currentSetence;

    [Header("Pontos pra passar de dia")]
    [Tooltip("Quantos pacientes pra trocar de dia")]
    public int personTokens;
    [HideInInspector]public int storedTokens;

    [Header("Quantidade de dias")]
    [Range(0, 5)]
    public int days;


    [Header("Lista dos Casos/Pessoas")]
    public List<PersonBehaviour> personCases = new List<PersonBehaviour>();
    PersonBehaviour activeCase;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentSetence = 0;
        storedTokens = personTokens;
        chooseNewCase();
    }

    public void chooseNewCase() 
    {   
        if (personCases.Count <= 0 || personTokens <= 0 || days <=0 ) 
        {
            GameManager.Instance.EndGame();
            days--;
            personTokens = storedTokens;
            Debug.Log("GameEnd");
            return;
        }
        activeCase = personCases[Random.Range(0, personCases.Count - 1)];
        personCases.Remove(activeCase);
        int currentSentenceIncremented = currentSetence + 1;

        if (currentSentenceIncremented < activeCase.setences.Length)
        {
            passDialogueButton.interactable = true;
        }
        else
        {
            Debug.Log("CurrentSetence ++ = " + currentSetence+1 + "\n Sentences Lenght = " + activeCase.setences.Length);
            foreach (Button b in gameButtons)
            {
                b.interactable = true;
            }
            
        }

        dialogueName.text = activeCase.name;
        StopAllCoroutines();
        StartCoroutine(TypeLetters(activeCase.setences[0]));
        dialogueSprite.sprite = activeCase.personFace;

        personTokens--;
    }

    public void AIPointDistribution(bool aproveButton) 
    {

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

    public void PassDialogue()
    {
        int currentSentenceIncremented = currentSetence + 1;

        if (currentSentenceIncremented < activeCase.setences.Length - 1)
        {
           
        }
        else
        {
            foreach (Button b in gameButtons)
            {
                b.interactable = true;
            }
            passDialogueButton.interactable = false;
        }

        currentSetence++;
        StopAllCoroutines();
        StartCoroutine(TypeLetters(activeCase.setences[currentSetence]));
    }


    public void ChangePerson() 
    {
        currentSetence = 0;
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
