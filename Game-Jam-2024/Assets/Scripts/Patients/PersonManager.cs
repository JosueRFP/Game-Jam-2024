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

    int currentSetence;

    [Header("Pontos pra passar de dia")]
    [Tooltip("Quantos pacientes pra trocar de dia")]
    public int personTokens;
    int storedTokens;

    [Header("Quantidade de dias")]
    [Range(1, 5)]
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
        chooseNewCase();
        storedTokens = personTokens;
    }

    public void chooseNewCase() 
    {   
        Debug.Log("Caso novo");
        if (personCases.Count <= 0 || personTokens <= 0 ) 
        {
            GameManager.Instance.EndGame();
            personTokens = storedTokens;
            Debug.Log("GameEnd");
            return;
        }
        activeCase = personCases[Random.Range(0, personCases.Count - 1)];
        personCases.Remove(activeCase);

        if (currentSetence > 0 && currentSetence++ > activeCase.setences.Length)
        {
            foreach (Button b in gameButtons)
            {
                b.interactable = true;
            }
        }
        else
        {
            passDialogueButton.interactable = true;
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
        if (currentSetence > 0 && currentSetence++ > activeCase.setences.Length)
        {
            passDialogueButton.interactable |= false;
            foreach (Button b in gameButtons)
            {
                b.interactable = true;
            }
            currentSetence = 0;
            return;
        }
        currentSetence++;
        Debug.Log(currentSetence);
        StopAllCoroutines();
        StartCoroutine(TypeLetters(activeCase.setences[currentSetence]));

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
